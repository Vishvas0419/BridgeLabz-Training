using System;

namespace DSAReview
{
    public class Program
    {
        public static void Main(string[] args)
        {
            FlightSystem fs = new FlightSystem();

            
            // 1. Add Runways
            

            fs.AddRunway(1);
            fs.AddRunway(2);
            fs.AddRunway(3);


            
            // 2. Create Flights
            

            Flight flight1 =
                new Flight(101, "Air India", TimeOnly.Parse("09:00 PM"));

            Flight flight2 =
                new Flight(102, "IndiGo", TimeOnly.Parse("10:00 AM"));

            Flight flight3 =
                new Flight(103, "Vistara", TimeOnly.Parse("11:00 AM"));

            Flight flight4 =
                new Flight(104, "SpiceJet", TimeOnly.Parse("12:00 PM"));


            
            // 3. Add Flights
            

            fs.AddFlight(flight1);
            fs.AddFlight(flight2);
            fs.AddFlight(flight3);
            fs.AddFlight(flight4);


            
            // 4. Add Passengers
            

            fs.AddPassenger(
                flight1.Code,
                new Passenger(1, "Rahul", false)
            );

            fs.AddPassenger(
                flight1.Code,
                new Passenger(2, "Aman", true)
            );

            fs.AddPassenger(
                flight1.Code,
                new Passenger(3, "Rohit", false)
            );

            fs.AddPassenger(
                flight2.Code,
                new Passenger(4, "Simran", true)
            );


            
            // 5. Runway Allocation
            

            Console.WriteLine("\nRunway Allocation");

            fs.RunwayAllocation();


            
            // 6. Boarding
            

            Console.WriteLine("\nFlight 101 Boarding");

            fs.RunwayBoarding(flight1.Code);


            
            // 7. Flight Details
            

            //Console.WriteLine("\nFlight Details");

            fs.DisplayFlightDetails(flight1);


            
            // 8. Flight Cancellation
            

            Console.WriteLine("\nFlight Cancellation");

            fs.FlightCancellation(flight2.Code);


            
            // 9. Forward Navigation
            

            Console.WriteLine("\nForward Navigation");

            FlightNode nextFlight =
                fs.NavigateFlightForward(flight2.BoardingTime);

            if (nextFlight != null)
            {
                Console.WriteLine(
                    "Next Flight: " +
                    nextFlight.Data.Code +
                    " - " +
                    nextFlight.Data.Name +
                    " " +
                    nextFlight.Data.BoardingTime
                );
            }
            else
            {
                Console.WriteLine("No next flight");
            }


            
            // 10. Backward Navigation
            

            Console.WriteLine("\nBackward Navigation");

            FlightNode previousFlight =
                fs.NavigateFlightBackward(flight2.BoardingTime);

            if (previousFlight != null)
            {
                Console.WriteLine(
                    "Previous Flight: " +
                    previousFlight.Data.Code +
                    " - " +
                    previousFlight.Data.Name +
                    " " +
                    previousFlight.Data.BoardingTime
                );
            }
            else
            {
                Console.WriteLine("No previous flight");
            }


            
            // 11. Flight Lookup
            

            Console.WriteLine("\nFlight Lookup");

            fs.FlightLookup(flight3.Code);


            
            // 12. Sorting
            

            Console.WriteLine("\nSorting Flights");

            fs.SortFlightsByCode();


            
            // 13. Binary Search
            

            Console.WriteLine("\nBinary Search");

            fs.BinarySearch(flight2.Code);
        }
    }
}