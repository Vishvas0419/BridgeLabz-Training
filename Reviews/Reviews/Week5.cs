using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace Reviews
{
    internal class Week5
    {
    }

    interface IDisposable
    {
        public string EncryptionContext();
    }

    public class AccessEvent
    {
        public int EmployeeId { get; set; }
        public string ZoneId { get; set; } = "";
        public DateTime Timestamp { get; set; }
        public int ClearanceLevel { get; set; }

        public int FailureCount { get; set; }

        public TimeSpan FailureWindow { get; set; }

        public bool Success { get; set; }
    }

    public class Employee
    {
        private int EmployeeId { get; set; }
        public int ClearanceLevel { get; set; }

        public Employee(int EmployeeId,int ClearanceLevel,int FailureCount)
        {
            this.EmployeeId = EmployeeId;
            this.ClearanceLevel = ClearanceLevel;
        }
    }

    public class AccessAuditEngine
    {
        //private AccessEvent accessEvent { get; set; }
        public Employee e;

        //closures

        public Predicate<AccessEvent> CreateOffHoursRule(int startHour, int endHour)
        {
            return e => e.Timestamp.Hour < startHour ||
                        e.Timestamp.Hour >= endHour;
        }

        public Predicate<AccessEvent> CreateClearanceRule(int requiredLevel)
        {
            return e => e.ClearanceLevel < requiredLevel;
        }

        public Predicate<AccessEvent> CreateFailureThresholdRule(
            int maxFailures,
            TimeSpan window)
        {
            return e => e.FailureCount >= maxFailures &&
                        e.FailureWindow <= window;
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



        //using predicate and action for filtering and side effect logging

        public Predicate<AccessEvent> IsValidEvent()
        {
            return e => e.Success;
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
        public int GetFailureCount(List<AccessEvent> events,AccessEvent currentEvent,TimeSpan window)
        {
            return events
                .Where(e => e.EmployeeId == currentEvent.EmployeeId && !e.Success && e.Timestamp <= currentEvent.Timestamp && currentEvent.Timestamp - e.Timestamp <= window)
                .Count();
        }





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
        public Dictionary<int, int> GetHourlyFrequency(
            List<Anomaly> anomalies)
        {
            return anomalies
                .GroupBy(a => a.AccessEvent.Timestamp.Hour)
                .ToDictionary(
                    group => group.Key,
                    group => group.Count());
        } 



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
        public List<string> Reasons { get; set; } = new();
    }

    //custom attributes
    [AttributeUsage(AttributeTargets.Method)]
    internal class ClearanceRequiredAttribute : Attribute
    {
        public int Level {  get; set; }
    }


    internal class SensitiveZoneAttribute : Attribute
    {
        public SensitiveZoneAttribute() { }

    }

    public class UnauthorizedZoneAccessException : Exception
    {
        public int EmployeeId { get; }
        public string ZoneId { get; }

        public UnauthorizedZoneAccessException(
            int employeeId,
            string zoneId)
            : base($"Employee {employeeId} is not authorized to access zone {zoneId}.")
        {
            EmployeeId = employeeId;
            ZoneId = zoneId;
        }
    }


}
