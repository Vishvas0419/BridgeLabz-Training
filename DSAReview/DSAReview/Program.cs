using System;

namespace DSAReview
{
    public class Program
    {
        public static void Main(string[] args)
        {
            FlightSystem fs = new FlightSystem();

            Flight flight1 = new Flight(101,"Air India", TimeOnly.Parse("09:00 AM"));
            Flight flight2 = new Flight(102,"IndiGo", TimeOnly.Parse("10:00 AM"));
            Flight flight3 = new Flight(103,"Vistara", TimeOnly.Parse("11:00 AM"));
            fs.AddFlight(flight1);
            fs.AddFlight(flight2);
            fs.AddFlight(flight3);

            //Console.WriteLine("Flight Details");
            fs.DisplayFlightDetails(flight1);

            Console.WriteLine("\nRunway Boarding");
            fs.RunwayBoarding();

            Console.WriteLine("\nFlight Cancellation");
            fs.FlightCancellation(102);

            Console.WriteLine("\nForward Navigation");
            FlightNode nextFlight = fs.NavigateFlightForward(TimeOnly.Parse("10:00 AM"));

            if (nextFlight != null)
            {
                Console.WriteLine("Next Flight: " + nextFlight.Data.Code + " - " + nextFlight.Data.Name + " "+nextFlight.Data.BoardingTime);
            }
            else
            {
                Console.WriteLine("No next flight");
            }

            Console.WriteLine("\nBackward Navigation");
            FlightNode previousFlight = fs.NavigateFlightBackward(TimeOnly.Parse("10:00 AM"));

            if (previousFlight != null)
            {
                Console.WriteLine("Previous Flight: " + previousFlight.Data.Code + " - " + previousFlight.Data.Name + " "+previousFlight.Data.BoardingTime);
            }
            else
            {
                Console.WriteLine("No previous flight");
            }

            Console.WriteLine("\nFlight Lookup");
            fs.FlightLookup(103);

            Console.WriteLine("\nSorting Flights");
            fs.SortFlights();

            Console.WriteLine("\nBinary Search");
            fs.BinarySearch(flight2);
        }
    }
}