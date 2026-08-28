using System;

namespace DSAReview
{
    public class Program
    {
        public static void Main(string[] args)
        {
            FlightSystem fs = new FlightSystem();

            fs.AddRunway(1); //add to cll
            fs.AddRunway(2);
            fs.AddRunway(3);

            Flight flight1 = new Flight(101, "Air India", TimeOnly.Parse("09:00 PM"));
            Flight flight2 = new Flight(102, "IndiGo", TimeOnly.Parse("10:00 AM"));
            Flight flight3 = new Flight(103, "Vistara", TimeOnly.Parse("11:00 AM"));
            Flight flight4 = new Flight(104, "SpiceJet", TimeOnly.Parse("12:00 PM"));
           
            fs.AddFlight(flight1); // dll
            fs.AddFlight(flight2);
            fs.AddFlight(flight3);
            fs.AddFlight(flight4);

            fs.AddPassenger(flight1.Code, new Passenger(1, "Rahul", false));
            fs.AddPassenger(flight1.Code,new Passenger(2, "Aman", true));
            fs.AddPassenger(flight1.Code,new Passenger(3, "Rohit", false));
            fs.AddPassenger(flight2.Code,new Passenger(4, "Simran", true));

            Console.WriteLine("\nRunway Allocation");
            fs.RunwayAllocation(); //cll

            Console.WriteLine("\nFlight 101 Boarding");
            fs.RunwayBoarding(flight1.Code); // acc to priority

            fs.DisplayFlightDetails(flight1);

            Console.WriteLine("\nFlight Cancellation");
            fs.FlightCancellation(flight2.Code); //stack

            Console.WriteLine("\nForward Navigation");
            FlightNode nextFlight = fs.NavigateFlightForward(flight2.BoardingTime); //dll

            if (nextFlight != null)
            {
                Console.WriteLine("Next Flight: " +nextFlight.Data.Code +" - " +nextFlight.Data.Name +" " +nextFlight.Data.BoardingTime);
            }
            else
            {
                Console.WriteLine("No next flight");
            }

            Console.WriteLine("\nBackward Navigation");
            FlightNode previousFlight = fs.NavigateFlightBackward(flight2.BoardingTime); //dll

            if (previousFlight != null)
            {
                Console.WriteLine("Previous Flight: " +previousFlight.Data.Code +" - " +previousFlight.Data.Name +" " + previousFlight.Data.BoardingTime);
            }
            else
            {
                Console.WriteLine("No previous flight");
            }

            Console.WriteLine("\nFlight Lookup");
            fs.FlightLookup(flight3.Code); //dictionary flights

            Console.WriteLine("\nSorting Flights");
            fs.SortFlightsByCode();//bubble sort

            Console.WriteLine("\nBinary Search");
            fs.BinarySearch(flight2.Code); //search according to flight code
        }
    }
}