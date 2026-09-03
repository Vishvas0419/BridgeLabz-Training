using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Reviews.Tests
{
    [TestFixture]
    public class Week5Tests
    {
        private AccessAuditEngine engine = null!;

        [SetUp]
        public void Setup()
        {
            engine = new AccessAuditEngine();
        }

        [Test]
        public void NormalAccessNotFlagged()
        {
            Employee employee =
                new Employee(101, 5);

            AccessEvent accessEvent =
                new AccessEvent
                {
                    EmployeeId = 101,
                    ZoneId = "Office",
                    Timestamp =
                        new DateTime(2026, 9, 3, 10, 0, 0),
                    Success = true
                };

            engine.Employees =
                new List<Employee> { employee };

            engine.AllEvents =
                new List<AccessEvent> { accessEvent };

            string file =
                Path.GetTempFileName();

            List<string> trace =
                new List<string>();

            using (AuditSession session =
                new AuditSession(file, trace))
            {
                Anomaly anomaly =
                    engine.EvaluateEvent(
                        accessEvent,
                        session);

                Assert.That(
                    anomaly.Reasons,
                    Is.Empty);
            }

            File.Delete(file);
        }

        [Test]
        public void OffHoursAccessFlagged()
        {
            Employee employee =
                new Employee(101, 5);

            AccessEvent accessEvent =
                new AccessEvent
                {
                    EmployeeId = 101,
                    ZoneId = "Office",
                    Timestamp =
                        new DateTime(2026, 9, 3, 2, 0, 0),
                    Success = true
                };

            engine.Employees =
                new List<Employee> { employee };

            engine.AllEvents =
                new List<AccessEvent> { accessEvent };

            string file =
                Path.GetTempFileName();

            List<string> trace =
                new List<string>();

            using (AuditSession session =
                new AuditSession(file, trace))
            {
                Anomaly anomaly =
                    engine.EvaluateEvent(
                        accessEvent,
                        session);

                Assert.That(
                    anomaly.Reasons,
                    Does.Contain("OffHours"));
            }

            File.Delete(file);
        }

        [Test]
        public void RestrictedZoneWithoutClearanceThrowsCustomException()
        {
            Employee employee =
                new Employee(101, 2);

            AccessEvent accessEvent =
                new AccessEvent
                {
                    EmployeeId = 101,
                    ZoneId = "RestrictedRoom",
                    Timestamp =
                        new DateTime(2026, 9, 3, 10, 0, 0),
                    Success = true
                };

            Predicate<AccessEvent> rule =
                engine.CreateClearanceRule(
                    employee,
                    4);

            Assert.Throws<UnauthorizedZoneAccessException>(
                () => rule(accessEvent));
        }

        [Test]
        public void RepeatedFailuresWithinWindowTriggerAnomaly()
        {
            List<AccessEvent> events =
                new List<AccessEvent>();

            DateTime time =
                new DateTime(2026, 9, 3, 10, 0, 0);

            events.Add(new AccessEvent
            {
                EmployeeId = 101,
                ZoneId = "Office",
                Timestamp = time,
                Success = false
            });

            events.Add(new AccessEvent
            {
                EmployeeId = 101,
                ZoneId = "Office",
                Timestamp = time.AddMinutes(5),
                Success = false
            });

            events.Add(new AccessEvent
            {
                EmployeeId = 101,
                ZoneId = "Office",
                Timestamp = time.AddMinutes(10),
                Success = false
            });

            Predicate<AccessEvent> rule =
                engine.CreateFailureThresholdRule(
                    events,
                    3,
                    TimeSpan.FromMinutes(30));

            Assert.That(
                rule(events[2]),
                Is.True);
        }

        [Test]
        public void RepeatedFailuresOutsideWindowDoNotTriggerAnomaly()
        {
            List<AccessEvent> events =
                new List<AccessEvent>();

            DateTime time =
                new DateTime(2026, 9, 3, 10, 0, 0);

            events.Add(new AccessEvent
            {
                EmployeeId = 101,
                ZoneId = "Office",
                Timestamp = time,
                Success = false
            });

            events.Add(new AccessEvent
            {
                EmployeeId = 101,
                ZoneId = "Office",
                Timestamp = time.AddMinutes(40),
                Success = false
            });

            events.Add(new AccessEvent
            {
                EmployeeId = 101,
                ZoneId = "Office",
                Timestamp = time.AddMinutes(80),
                Success = false
            });

            Predicate<AccessEvent> rule =
                engine.CreateFailureThresholdRule(
                    events,
                    3,
                    TimeSpan.FromMinutes(30));

            Assert.That(
                rule(events[2]),
                Is.False);
        }

        [Test]
        public void DifferentClosuresProduceDifferentThresholdResults()
        {
            List<AccessEvent> events =
                new List<AccessEvent>();

            DateTime time =
                new DateTime(2026, 9, 3, 10, 0, 0);

            for (int i = 0; i < 3; i++)
            {
                events.Add(
                    new AccessEvent
                    {
                        EmployeeId = 101,
                        ZoneId = "Office",
                        Timestamp =
                            time.AddMinutes(i * 5),
                        Success = false
                    });
            }

            Predicate<AccessEvent> rule1 =
                engine.CreateFailureThresholdRule(
                    events,
                    2,
                    TimeSpan.FromMinutes(30));

            Predicate<AccessEvent> rule2 =
                engine.CreateFailureThresholdRule(
                    events,
                    4,
                    TimeSpan.FromMinutes(30));

            Assert.That(
                rule1(events[2]),
                Is.True);

            Assert.That(
                rule2(events[2]),
                Is.False);
        }

        [Test]
        public void CombinedAttributeSeverityIsCritical()
        {
            AccessEvent accessEvent =
                new AccessEvent
                {
                    EmployeeId = 101,
                    ZoneId = "ServerRoom",
                    Timestamp =
                        new DateTime(2026, 9, 3, 10, 0, 0),
                    Success = true
                };

            Assert.That(
                engine.GetRequiredClearanceLevel(
                    "ServerRoom"),
                Is.EqualTo(3));

            Assert.That(
                engine.IsSensitiveZone(
                    "ServerRoom"),
                Is.True);

            Assert.That(
                engine.GetSeverity(accessEvent),
                Is.EqualTo("Critical"));
        }

        [Test]
        public void CombinedAttributeSeverityIsWarning()
        {
            AccessEvent accessEvent =
                new AccessEvent
                {
                    EmployeeId = 101,
                    ZoneId = "Office",
                    Timestamp =
                        new DateTime(2026, 9, 3, 10, 0, 0),
                    Success = true
                };

            Assert.That(
                engine.GetRequiredClearanceLevel(
                    "Office"),
                Is.EqualTo(2));

            Assert.That(
                engine.IsSensitiveZone(
                    "Office"),
                Is.False);

            Assert.That(
                engine.GetSeverity(accessEvent),
                Is.EqualTo("Warning"));
        }

        [Test]
        public void HourlyFrequencyBucketingWorks()
        {
            List<Anomaly> anomalies =
                new List<Anomaly>
                {
                    new Anomaly(
                        new AccessEvent
                        {
                            EmployeeId = 101,
                            ZoneId = "Office",
                            Timestamp =
                                new DateTime(2026, 9, 3, 10, 10, 0)
                        })
                    {
                        Reasons =
                            new List<string>
                            {
                                "OffHours"
                            }
                    },

                    new Anomaly(
                        new AccessEvent
                        {
                            EmployeeId = 102,
                            ZoneId = "Office",
                            Timestamp =
                                new DateTime(2026, 9, 3, 10, 40, 0)
                        })
                    {
                        Reasons =
                            new List<string>
                            {
                                "OffHours"
                            }
                    },

                    new Anomaly(
                        new AccessEvent
                        {
                            EmployeeId = 103,
                            ZoneId = "Office",
                            Timestamp =
                                new DateTime(2026, 9, 3, 11, 10, 0)
                        })
                    {
                        Reasons =
                            new List<string>
                            {
                                "RepeatedFailure"
                            }
                    }
                };

            List<string> result =
                engine.GetHourlyAnomalyFrequency(
                    anomalies);

            Assert.That(
                result[0],
                Does.Contain("10:00 - 2"));

            Assert.That(
                result[1],
                Does.Contain("11:00 - 1"));
        }

        [Test]
        public void AnomalyRankingWorks()
        {
            List<Anomaly> anomalies =
                new List<Anomaly>
                {
                    new Anomaly(
                        new AccessEvent
                        {
                            EmployeeId = 101
                        }),

                    new Anomaly(
                        new AccessEvent
                        {
                            EmployeeId = 101
                        }),

                    new Anomaly(
                        new AccessEvent
                        {
                            EmployeeId = 102
                        })
                };

            List<string> result =
                engine.RankByAnomalyCount(
                    anomalies);

            Assert.That(
                result[0],
                Is.EqualTo(
                    "Employee 101: 2 anomalies"));

            Assert.That(
                result[1],
                Is.EqualTo(
                    "Employee 102: 1 anomalies"));
        }

        [Test]
        public void DisposeReleasesEncryptionBeforeLog()
        {
            string file =
                Path.GetTempFileName();

            List<string> trace =
                new List<string>();

            AuditSession session =
                new AuditSession(
                    file,
                    trace);

            session.Dispose();

            int encryptionIndex =
                trace.IndexOf(
                    "EncryptionContext disposed");

            int streamIndex =
                trace.IndexOf(
                    "StreamWriter disposed");

            Assert.That(
                encryptionIndex,
                Is.GreaterThanOrEqualTo(0));

            Assert.That(
                streamIndex,
                Is.GreaterThanOrEqualTo(0));

            Assert.That(
                encryptionIndex,
                Is.LessThan(streamIndex));

            File.Delete(file);
        }

        [Test]
        public void CorruptionExceptionPathStillDisposesSession()
        {
            string file =
                Path.GetTempFileName();

            List<string> trace =
                new List<string>();

            AuditSession session =
                new AuditSession(
                    file,
                    trace);

            Assert.Throws<AuditLogCorruptionException>(
                () =>
                    session.WriteAuditEntry(
                        "Bad entry",
                        true));

            session.Dispose();

            Assert.That(
                trace,
                Does.Contain(
                    "EncryptionContext disposed"));

            Assert.That(
                trace,
                Does.Contain(
                    "StreamWriter disposed"));

            File.Delete(file);
        }

        [Test]
        public void MultipleEventSubscribersReceiveAnomaly()
        {
            int consoleCount = 0;
            int ticketCount = 0;

            engine.AnomalyDetected +=
                (sender, args) =>
                {
                    consoleCount++;
                };

            engine.AnomalyDetected +=
                (sender, args) =>
                {
                    ticketCount++;
                };

            engine.DetectAnomaly(
                "OffHours");

            Assert.That(
                consoleCount,
                Is.EqualTo(1));

            Assert.That(
                ticketCount,
                Is.EqualTo(1));
        }

        [Test]
        public void OutOfOrderEventsThrowValidationException()
        {
            List<AccessEvent> events =
                new List<AccessEvent>
                {
                    new AccessEvent
                    {
                        EmployeeId = 101,
                        Timestamp =
                            new DateTime(
                                2026,
                                9,
                                3,
                                10,
                                0,
                                0)
                    },

                    new AccessEvent
                    {
                        EmployeeId = 101,
                        Timestamp =
                            new DateTime(
                                2026,
                                9,
                                3,
                                9,
                                0,
                                0)
                    }
                };

            Assert.Throws<ArgumentException>(
                () =>
                    engine.ValidateEventOrder(
                        events));
        }
    }
}