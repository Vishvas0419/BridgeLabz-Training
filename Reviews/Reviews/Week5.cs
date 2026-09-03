using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Reviews
{
    public class AccessEvent
    {
        public int EmployeeId { get; set; }
        public string ZoneId { get; set; } = "";
        public DateTime Timestamp { get; set; }
        public bool Success { get; set; }
    }

    public class Employee
    {
        public int EmployeeId { get; set; }
        public int ClearanceLevel { get; set; }

        public Employee(int EmployeeId, int ClearanceLevel, int FailureCount = 0)
        {
            this.EmployeeId = EmployeeId;
            this.ClearanceLevel = ClearanceLevel;
        }
    }

    public class AccessAuditEngine
    {
        private AccessEvent accessEvent;

        //closures

        public Predicate<AccessEvent> CreateOffHoursRule(int startHour, int endHour)
        {
            return e => e.Timestamp.Hour < startHour || e.Timestamp.Hour >= endHour;
        }

        public Predicate<AccessEvent> CreateClearanceRule(int requiredLevel)
        {
            return e =>
            {
                Employee employee = Employees.FirstOrDefault(x => x.EmployeeId == e.EmployeeId);

                if (employee == null)
                {
                    return false;
                }

                if (employee.ClearanceLevel < requiredLevel)
                {
                    ZoneInfo zoneInfo = GetZoneInfo(e.ZoneId);

                    if (zoneInfo.IsSensitive && zoneInfo.RequiredLevel > 0)
                    {
                        throw new UnauthorizedZoneAccessException(
                            employee.EmployeeId,
                            e.ZoneId);
                    }

                    throw new UnauthorizedAccessException(
                        $"Employee {employee.EmployeeId} does not have sufficient access.");
                }

                return false;
            };
        }

        public Predicate<AccessEvent> CreateClearanceRule(Employee employee, int requiredLevel)
        {
            return e =>
            {
                if (employee.ClearanceLevel < requiredLevel)
                {
                    ZoneInfo zoneInfo = GetZoneInfo(e.ZoneId);

                    if (zoneInfo.IsSensitive && zoneInfo.RequiredLevel > 0)
                    {
                        throw new UnauthorizedZoneAccessException(
                            employee.EmployeeId,
                            e.ZoneId);
                    }

                    throw new UnauthorizedAccessException(
                        $"Employee {employee.EmployeeId} does not have sufficient access.");
                }

                return false;
            };
        }

        public Predicate<AccessEvent> CreateFailureThresholdRule(int maxFailures, TimeSpan window)
        {
            return currentEvent =>
                GetFailureCount(
                    AllEvents,
                    currentEvent,
                    window) >= maxFailures;
        }

        public Predicate<AccessEvent> CreateFailureThresholdRule(
            List<AccessEvent> events,
            int maxFailures,
            TimeSpan window)
        {
            return currentEvent =>
                GetFailureCount(events, currentEvent, window) >= maxFailures;
        }

        public Predicate<AccessEvent> CombineRules(
            Predicate<AccessEvent> rule1,
            Predicate<AccessEvent> rule2,
            Predicate<AccessEvent> rule3)
        {
            return e => rule1(e) || rule2(e) || rule3(e);
        }

        //event

        public event EventHandler<AnomalyEventArgs>? AnomalyDetected;

        public void DetectAnomaly(string reason)
        {
            AnomalyDetected?.Invoke(
                this,
                new AnomalyEventArgs(reason));
        }

        public event EventHandler<AnomalyEventArgs>? AnomalyDetectedWithDetails;

        //using predicate and action for filtering and side effect logging

        public Predicate<AccessEvent> IsValidEvent()
        {
            return e => e != null;
        }

        public Action<AccessEvent> LogEvent()
        {
            return e =>
            {
                Console.WriteLine(
                    $"Employee: {e.EmployeeId}, Zone: {e.ZoneId}");
            };
        }

        public void ProcessEvent(AccessEvent accessEvent)
        {
            Predicate<AccessEvent> filter = IsValidEvent();
            Action<AccessEvent> logger = LogEvent();

            if (filter(accessEvent))
            {
                logger(accessEvent);
            }
        }

        //using lambda exp to find rolling failure counts

        public int GetFailureCount(
            List<AccessEvent> events,
            AccessEvent currentEvent,
            TimeSpan window)
        {
            return events
                .Where(e =>
                    e.EmployeeId == currentEvent.EmployeeId &&
                    !e.Success &&
                    e.Timestamp <= currentEvent.Timestamp &&
                    currentEvent.Timestamp - e.Timestamp <= window)
                .Count();
        }

        //LINQ

        public List<string> GroupAnomaliesByReason(List<Anomaly> anomalies)
        {
            return anomalies
                .SelectMany(a => a.Reasons)
                .GroupBy(reason => reason)
                .Select(g => $"{g.Key}: {g.Count()}")
                .ToList();
        }

        public List<string> RankByAnomalyCount(List<Anomaly> anomalies)
        {
            return anomalies
                .GroupBy(a => a.AccessEvent.EmployeeId)
                .OrderByDescending(g => g.Count())
                .Select(g => $"Employee {g.Key}: {g.Count()} anomalies")
                .ToList();
        }

        public List<string> GetHourlyAnomalyFrequency(List<Anomaly> anomalies)
        {
            return anomalies
                .GroupBy(a => new
                {
                    Date = a.AccessEvent.Timestamp.Date,
                    Hour = a.AccessEvent.Timestamp.Hour
                })
                .OrderBy(g => g.Key.Date)
                .ThenBy(g => g.Key.Hour)
                .Select(g =>
                    $"{g.Key.Date:yyyy-MM-dd} {g.Key.Hour:00}:00 - {g.Count()}")
                .ToList();
        }

        public List<Anomaly> AnalyzeEvents(
            List<AccessEvent> events,
            List<Employee> employees,
            AuditSession session)
        {
            if (events == null)
            {
                throw new ArgumentNullException(nameof(events));
            }

            if (events.Count < 20 || events.Count > 500)
            {
                throw new ArgumentException(
                    "An audit run must contain between 20 and 500 events.");
            }

            Employees = employees;
            AllEvents = events;

            ValidateEventOrder(events);

            List<Anomaly> anomalies = new List<Anomaly>();

            foreach (AccessEvent currentEvent in events)
            {
                Anomaly? anomaly = null;

                try
                {
                    anomaly = EvaluateEvent(
                        currentEvent,
                        session);

                    if (anomaly.Reasons.Count > 0)
                    {
                        anomalies.Add(anomaly);
                    }
                }
                catch (UnauthorizedZoneAccessException ex)
                {
                    Console.WriteLine(
                        $"CRITICAL: {ex.Message}");

                    anomaly = new Anomaly(currentEvent);

                    anomaly.Reasons.Add("InsufficientClearance");

                    anomaly.Severity = GetSeverity(currentEvent);

                    anomalies.Add(anomaly);

                    DetectAnomaly(
                        $"{anomaly.Severity}:InsufficientClearance");
                }
                catch (UnauthorizedAccessException ex)
                {
                    Console.WriteLine(
                        $"WARNING: {ex.Message}");

                    anomaly = new Anomaly(currentEvent);

                    anomaly.Reasons.Add("InsufficientClearance");

                    anomaly.Severity = "Warning";

                    anomalies.Add(anomaly);

                    DetectAnomaly(
                        "Warning:InsufficientClearance");
                }
                catch (AuditLogCorruptionException ex)
                {
                    Console.WriteLine(
                        $"Audit corruption detected: {ex.Message}");
                }
                finally
                {
                    string auditMessage;

                    if (anomaly != null && anomaly.Reasons.Count > 0)
                    {
                        auditMessage =
                            $"Employee {currentEvent.EmployeeId}, " +
                            $"Zone {currentEvent.ZoneId}, " +
                            $"Reasons: {string.Join(",", anomaly.Reasons)}, " +
                            $"Severity: {anomaly.Severity}";
                    }
                    else
                    {
                        auditMessage =
                            $"Employee {currentEvent.EmployeeId}, " +
                            $"Zone {currentEvent.ZoneId}, " +
                            $"Result: Normal";
                    }

                    try
                    {
                        session.WriteAuditEntry(auditMessage);
                    }
                    catch (AuditLogCorruptionException ex)
                    {
                        Console.WriteLine(
                            $"Audit log corruption: {ex.Message}");

                        session.WriteAuditEntry(
                            $"Recovery audit entry for Employee {currentEvent.EmployeeId}");
                    }
                }
            }

            return anomalies;
        }

        public Anomaly EvaluateEvent(
            AccessEvent currentEvent,
            AuditSession session)
        {
            Employee? employee =
                Employees.FirstOrDefault(
                    e => e.EmployeeId == currentEvent.EmployeeId);

            if (employee == null)
            {
                throw new ArgumentException(
                    $"Employee {currentEvent.EmployeeId} was not found.");
            }

            Predicate<AccessEvent> offHoursRule =
                CreateOffHoursRule(8, 18);

            Predicate<AccessEvent> clearanceRule =
                CreateClearanceRule(employee, GetRequiredClearanceLevel(currentEvent.ZoneId));

            Predicate<AccessEvent> failureRule =
                CreateFailureThresholdRule(
                    AllEvents,
                    3,
                    TimeSpan.FromMinutes(30));

            Predicate<AccessEvent> combinedRule =
                CombineRules(
                    offHoursRule,
                    clearanceRule,
                    failureRule);

            Anomaly anomaly =
                new Anomaly(currentEvent);

            if (offHoursRule(currentEvent))
            {
                anomaly.Reasons.Add("OffHours");
            }

            try
            {
                if (clearanceRule(currentEvent))
                {
                    anomaly.Reasons.Add("InsufficientClearance");
                }
            }
            catch (UnauthorizedZoneAccessException)
            {
                anomaly.Reasons.Add("InsufficientClearance");
                anomaly.Severity = GetSeverity(currentEvent);

                throw;
            }
            catch (UnauthorizedAccessException)
            {
                anomaly.Reasons.Add("InsufficientClearance");
                anomaly.Severity = "Warning";

                throw;
            }

            if (failureRule(currentEvent))
            {
                anomaly.Reasons.Add("RepeatedFailure");
            }

            if (combinedRule(currentEvent))
            {
                if (anomaly.Reasons.Count == 0)
                {
                    anomaly.Reasons.Add("Anomaly");
                }
            }

            if (anomaly.Reasons.Count > 0)
            {
                if (anomaly.Severity == "")
                {
                    anomaly.Severity = GetSeverity(currentEvent);
                }

                foreach (string reason in anomaly.Reasons)
                {
                    DetectAnomaly(
                        $"{anomaly.Severity}:{reason}");
                }
            }

            return anomaly;
        }

        public void ValidateEventOrder(List<AccessEvent> events)
        {
            Dictionary<int, DateTime> lastEventTime =
                new Dictionary<int, DateTime>();

            foreach (AccessEvent e in events)
            {
                if (lastEventTime.ContainsKey(e.EmployeeId))
                {
                    if (e.Timestamp < lastEventTime[e.EmployeeId])
                    {
                        throw new ArgumentException(
                            $"Out-of-order event for Employee {e.EmployeeId}.");
                    }
                }

                lastEventTime[e.EmployeeId] = e.Timestamp;
            }
        }

        public string GetSeverity(AccessEvent accessEvent)
        {
            ZoneInfo zoneInfo = GetZoneInfo(accessEvent.ZoneId);

            if (zoneInfo.RequiredLevel > 0 &&
                zoneInfo.IsSensitive)
            {
                return "Critical";
            }

            return "Warning";
        }

        public int GetRequiredClearanceLevel(string zoneId)
        {
            ZoneInfo zoneInfo = GetZoneInfo(zoneId);

            return zoneInfo.RequiredLevel;
        }

        public bool IsSensitiveZone(string zoneId)
        {
            ZoneInfo zoneInfo = GetZoneInfo(zoneId);

            return zoneInfo.IsSensitive;
        }

        private ZoneInfo GetZoneInfo(string zoneId)
        {
            Type? zoneType = null;

            if (zoneId.Equals(
                "ServerRoom",
                StringComparison.OrdinalIgnoreCase))
            {
                zoneType = typeof(ServerRoom);
            }
            else if (zoneId.Equals(
                "RestrictedRoom",
                StringComparison.OrdinalIgnoreCase))
            {
                zoneType = typeof(RestrictedRoom);
            }
            else if (zoneId.Equals(
                "Office",
                StringComparison.OrdinalIgnoreCase))
            {
                zoneType = typeof(Office);
            }

            if (zoneType == null)
            {
                return new ZoneInfo(0, false);
            }

            ClearanceRequiredAttribute? clearanceAttribute =
                zoneType.GetCustomAttribute<ClearanceRequiredAttribute>();

            SensitiveZoneAttribute? sensitiveAttribute =
                zoneType.GetCustomAttribute<SensitiveZoneAttribute>();

            int requiredLevel = 0;

            if (clearanceAttribute != null)
            {
                requiredLevel = clearanceAttribute.Level;
            }

            bool isSensitive =
                sensitiveAttribute != null;

            return new ZoneInfo(
                requiredLevel,
                isSensitive);
        }

        public List<Employee> Employees { get; set; } =
            new List<Employee>();

        public List<AccessEvent> AllEvents { get; set; } =
            new List<AccessEvent>();
    }


    public class AnomalyEventArgs : EventArgs
    {
        public string Reason { get; }

        public AnomalyEventArgs(string reason)
        {
            Reason = reason;
        }
    }


    public class Anomaly
    {
        public AccessEvent AccessEvent { get; set; }

        public List<string> Reasons { get; set; } =
            new List<string>();

        public string Severity { get; set; } = "";

        public Anomaly(AccessEvent accessEvent)
        {
            AccessEvent = accessEvent;
        }
    }


    //custom attributes

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class ClearanceRequiredAttribute : Attribute
    {
        public int Level { get; set; }
    }

    [ClearanceRequired(Level = 3)]
    [SensitiveZone]
    public class ServerRoom
    {
    }

    [ClearanceRequired(Level = 4)]
    [SensitiveZone]
    public class RestrictedRoom
    {
    }

    [ClearanceRequired(Level = 2)]
    public class Office
    {
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class SensitiveZoneAttribute : Attribute
    {
        public SensitiveZoneAttribute()
        {
        }
    }


    public class ZoneInfo
    {
        public int RequiredLevel { get; set; }
        public bool IsSensitive { get; set; }

        public ZoneInfo(int requiredLevel, bool isSensitive)
        {
            RequiredLevel = requiredLevel;
            IsSensitive = isSensitive;
        }
    }


    //custom exceptions

    public class UnauthorizedZoneAccessException : Exception
    {
        public int EmployeeId { get; }
        public string ZoneId { get; }

        public UnauthorizedZoneAccessException(
            int employeeId,
            string zoneId)
            : base(
                $"Employee {employeeId} is not authorized to access zone {zoneId}.")
        {
            EmployeeId = employeeId;
            ZoneId = zoneId;
        }

        public UnauthorizedZoneAccessException(
            string message,
            int employeeId,
            string zoneId)
            : base(message)
        {
            EmployeeId = employeeId;
            ZoneId = zoneId;
        }
    }


    public class AuditLogCorruptionException : Exception
    {
        public AuditLogCorruptionException()
            : base("Audit log integrity check failed.")
        {
        }

        public AuditLogCorruptionException(string message)
            : base(message)
        {
        }
    }


    public class EncryptionContext : IDisposable
    {
        private readonly List<string> trace;
        private bool disposed;

        public EncryptionContext(List<string> trace)
        {
            this.trace = trace;
            trace.Add("EncryptionContext created");
        }

        public void Dispose()
        {
            if (!disposed)
            {
                trace.Add("EncryptionContext disposed");
                disposed = true;
            }
        }
    }


    public class AuditSession : IDisposable
    {
        private StreamWriter? writer;
        private EncryptionContext? encryptionContext;
        private readonly List<string> trace;
        private bool disposed;

        public AuditSession(
            string fileName,
            List<string> trace)
        {
            this.trace = trace;

            writer = new StreamWriter(
                fileName,
                false);

            encryptionContext =
                new EncryptionContext(trace);

            trace.Add("AuditSession created");
        }

        public void WriteAuditEntry(
            string message,
            bool simulateCorruption = false)
        {
            if (disposed)
            {
                throw new ObjectDisposedException(
                    nameof(AuditSession));
            }

            if (simulateCorruption)
            {
                throw new AuditLogCorruptionException(
                    "Simulated audit log corruption.");
            }

            writer!.WriteLine(message);
            writer.Flush();
        }

        public void WriteAuditEntryWithIntegrityCheck(
            string message,
            bool integrityCheckFails)
        {
            try
            {
                if (integrityCheckFails)
                {
                    throw new AuditLogCorruptionException(
                        "Simulated integrity check failure.");
                }

                WriteAuditEntry(message);
            }
            finally
            {
                if (integrityCheckFails)
                {
                    try
                    {
                        WriteAuditEntry(
                            "Recovery: audit integrity check failed.");
                    }
                    catch
                    {
                    }
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~AuditSession()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (encryptionContext != null)
            {
                encryptionContext.Dispose();
                encryptionContext = null;
            }

            if (writer != null)
            {
                trace.Add("StreamWriter disposed");
                writer.Dispose();
                writer = null;
            }

            disposed = true;
        }
    }
}