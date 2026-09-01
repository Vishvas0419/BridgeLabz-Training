using Reviews;
using System;
using System.Collections.Generic;
using System.Text;




namespace TestProjectReview
    {
        internal class Week5Tests
        {
            [Test]
            public void NormalAccess_ShouldNotBeFlagged()
            {
                var engine = new AccessAuditEngine();

                var rule = engine.CreateOffHoursRule(8, 18);

                var accessEvent = new AccessEvent
                {
                    EmployeeId = 1,
                    ZoneId = "Office",
                    Timestamp = new DateTime(2026, 9, 1, 10, 0, 0),
                    Success = true
                };

                Assert.That(rule(accessEvent), Is.False);
            }

            [Test]
            public void OffHoursAccess_ShouldBeFlagged()
            {
                var engine = new AccessAuditEngine();

                var rule = engine.CreateOffHoursRule(8, 18);

                var accessEvent = new AccessEvent
                {
                    EmployeeId = 1,
                    ZoneId = "Office",
                    Timestamp = new DateTime(2026, 9, 1, 2, 0, 0),
                    Success = true
                };

                Assert.That(rule(accessEvent), Is.True);
            }
        }
    }
