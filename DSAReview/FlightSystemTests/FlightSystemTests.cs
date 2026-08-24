using DSAReview;
using NUnit.Framework;
using System;

namespace DSAReview.Tests
{
    public class FlightSystemTests
    {
        private FlightSystem fs;

        [SetUp]
        public void Setup()
        {
            fs = new FlightSystem();
            fs.AddFlight(new Flight(101,"Air India",TimeOnly.Parse("09:00 AM")));
            fs.AddFlight(new Flight(102,"IndiGo",TimeOnly.Parse("10:00 AM")));
            fs.AddFlight(new Flight(103,"Vistara",TimeOnly.Parse("11:00 AM")));
        }
        [Test]
        public void ShouldReturnNextFlight()
        {
            FlightNode result = fs.NavigateFlightForward(TimeOnly.Parse("10:00 AM"));
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Data.Code,Is.EqualTo(103));
        }

        [Test]
        public void ShouldReturnPreviousFlight()
        {
            FlightNode result = fs.NavigateFlightBackward(TimeOnly.Parse("10:00 AM"));
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Data.Code,Is.EqualTo(101));
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
    }
}