using Reviews;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProjectReview
{
    public class FlightSystemTests
    {
        private FlightSystem fs;

        [SetUp]
        public void Setup()
        {
            fs = new FlightSystem();
            fs.AddFlight(new Flight(101, "Air India", TimeOnly.Parse("09:00 AM")));
            fs.AddFlight(new Flight(102, "IndiGo", TimeOnly.Parse("10:00 AM")));
            fs.AddFlight(new Flight(103, "Vistara", TimeOnly.Parse("11:00 AM")));
        }

        [Test]
        public void ShouldReturnNextFlight()
        {
            FlightNode result = fs.NavigateFlightForward(TimeOnly.Parse("10:00 AM"));
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Data.Code, Is.EqualTo(103));
        }

        [Test]
        public void ShouldReturnPreviousFlight()
        {
            FlightNode result = fs.NavigateFlightBackward(TimeOnly.Parse("10:00 AM"));
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Data.Code, Is.EqualTo(101));
        }
        [Test]
        public void LastFlight_ShouldReturnNull()
        {
            FlightNode result = fs.NavigateFlightForward(TimeOnly.Parse("11:00 AM"));
            Assert.That(result, Is.Null);
        }
        [Test]
        public void NavigateFlightBackward_FirstFlightShouldReturnNull()
        {
            FlightNode result = fs.NavigateFlightBackward(TimeOnly.Parse("09:00 AM"));
            Assert.That(result, Is.Null);
        }
        [Test]
        public void NavigateFlightForward_InvalidTime_ShouldReturnNull()
        {
            FlightNode result =
                fs.NavigateFlightForward(TimeOnly.Parse("12:00 PM"));
            Assert.That(result, Is.Null);
        }

        [Test] //Tests the runwayHead == null branch in RunwayAllocation().
        public void RunwayAllocation_NoRunway_ShouldNotAllocate()
        {
            Assert.DoesNotThrow(() => fs.RunwayAllocation());
        }

        [Test] //Tests that RunwayAllocation() works when runways have been added.
        public void RunwayAllocation_WithRunways_ShouldWork()
        {
            fs.AddRunway(1);
            fs.AddRunway(2);

            Assert.DoesNotThrow(() => fs.RunwayAllocation());
        }


        [Test] //Tests the AddFlight() method by adding a new flight and then checking that it appears in the DLL.
        public void AddFlight_ShouldAddNewFlight()
        {
            fs.AddFlight(
                new Flight(104, "SpiceJet", TimeOnly.Parse("12:00 PM"))
            );

            FlightNode result =
                fs.NavigateFlightBackward(TimeOnly.Parse("12:00 PM"));

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Data.Code, Is.EqualTo(103));
        }


        [Test] //Tests the RunwayBoarding() empty-queue handling.
        public void RunwayBoarding_EmptyQueue_ShouldNotThrow()
        {
            Assert.DoesNotThrow(() => fs.RunwayBoarding(101));
        }

        [Test] //Tests that FlightCancellation() can find an existing flight and process it.
        public void FlightCancellation_ExistingFlight_ShouldWork()
        {
            Assert.DoesNotThrow(() => fs.FlightCancellation(102));
        }
    }
}
