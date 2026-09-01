using static Reviews.Week2;

namespace Reviews
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //employee management system-week2


            //Problem 1
            //Developer developer =
            //    new Developer(101, "Vishvas", 24, "IT");

            //Manager manager =
            //    new Manager(102, "Rahul", 35, "Management", 10);

            //HRRepresentative hr =
            //    new HRRepresentative(103, "USER", 30, "HR");


            // Developer overtime
            //developer.AddOvertimeShift();
            //developer.AddOvertimeShift();


            // Developer
            //developer.DisplayDetails();
            //developer.ClockIn();
            //developer.WriteCode();
            //developer.ReviewCode();
            //developer.PerformEvaluation();
            //developer.ProcessPayment();


            //Console.WriteLine();


            // Manager
            //manager.DisplayDetails();
            //manager.AssignTask();
            //manager.ApproveLeave();
            //manager.ConductMeeting();
            //manager.PerformEvaluation();
            //manager.ProcessPayment();


            //Console.WriteLine();


            // HR
            //hr.DisplayDetails();
            //hr.OnboardEmployee();
            //hr.ConductInterview();
            //hr.PerformEvaluation();
            //hr.ProcessPayment();

            //======================================================================

            //problem 2 
            // Develop a program to get next day of a given date.
            // Expected Output:
            // Input a year: 2020
            // Input a month [1-12]: 08
            // Input a day [1-31]: 23
            // The next date is [yyyy-mm-dd] 2020-8-24









            //======================================================================
            //Problem 3 - Find Length of the longest substring without repeating characters

            //Console.WriteLine("Enter a string to find Length of the longest substring without repeating characters : ");
            //string str = Console.ReadLine();
            //Console.WriteLine("Length of the longest substring without repeating characters is : " + LongestSubWithoutRepChar(str));


            ////==============================================================================
            //// Problem 4 - Write a C# Sharp program that calculates the smallest gap between the numbers in an array of integers. Go to the editor
            //// Sample Data:
            //// ({ 7, 5, 8, 9, 11, 23, 18 }) -> 1 (diff btw 8,9)
            //// ({ 200, 300, 250, 151, 162 }) -> 11 (diff btw 151, 162) 


            //Console.WriteLine("Enter size of array to calculate the smallest gap between the numbers in the array : ");
            //int n = int.Parse(Console.ReadLine());
            //Console.WriteLine("Now Enter Array Elements : ");
            //int[]arr = new int[n];
            //for (int i = 0; i < n; i++)
            //{
            //    arr[i] = int.Parse(Console.ReadLine());
            //}
            //Console.WriteLine("Result : " + SmallestGap(arr,n));

            //project 2 moview streaming platform

            //RegexParse parser = new RegexParse();

            //ProfileStore<ViewingSession> store = new ProfileStore<ViewingSession>();

            //string record = "USER:Alice|TITLE:Mission: Impossible - Fallout (2018)|GENRES:sci-fi,drama,thriller|WATCHED:80%|TS:2026-08-14T21:10:00";

            //ViewingSession session = parser.Parse(record);
            //session.display();

            ////store is object to use the ProfileStore generic class methods
            //store.AddSession(session);

            //Dictionary<string, double> profile = store.GetProfile("Alice");
            //foreach (var pair in profile)
            //{
            //    Console.WriteLine(pair.Key + " : " + pair.Value);
            //}

            //List<ViewingSession> highWatchedSessions = store.GetHighlyWatchedSessions(80);
            //Console.WriteLine("highly watched sessions : ");

            //foreach(ViewingSession s in  highWatchedSessions)
            //{
            //    Console.WriteLine(s.Title + " : " + s.WatchedPercentage + "%");
            //}


            //==============================================================
            //Pyramid Arrangement
            //int[] input = { 1, 4, 3, 6, 8, 7, 9, 2, 5, 0, 12, 23, -1 };
            //int n = input.Length;
            //int[] output = Week3.pyramid(input, n);
            //for (int i = 0; i < output.Length; i++)
            //{
            //    Console.Write(output[i] + " ");
            //}


            //===================================
            //Week 4 DSA review
            //===================================

            //Problem Statement 1 - Flight Management System

            //FlightSystem fs = new FlightSystem();

            //fs.AddRunway(1); //add to cll
            //fs.AddRunway(2);
            //fs.AddRunway(3);

            //Flight flight1 = new Flight(101, "Air India", TimeOnly.Parse("09:00 PM"));
            //Flight flight2 = new Flight(102, "IndiGo", TimeOnly.Parse("10:00 AM"));
            //Flight flight3 = new Flight(103, "Vistara", TimeOnly.Parse("11:00 AM"));
            //Flight flight4 = new Flight(104, "SpiceJet", TimeOnly.Parse("12:00 PM"));

            //fs.AddFlight(flight1); // dll
            //fs.AddFlight(flight2);
            //fs.AddFlight(flight3);
            //fs.AddFlight(flight4);

            //fs.AddPassenger(flight1.Code, new Passenger(1, "Rahul", false));
            //fs.AddPassenger(flight1.Code, new Passenger(2, "Aman", true));
            //fs.AddPassenger(flight1.Code, new Passenger(3, "Rohit", false));
            //fs.AddPassenger(flight2.Code, new Passenger(4, "Simran", true));

            //Console.WriteLine("\nRunway Allocation");
            //fs.RunwayAllocation(); //cll

            //Console.WriteLine("\nFlight 101 Boarding");
            //fs.RunwayBoarding(flight1.Code); // acc to priority

            //fs.DisplayFlightDetails(flight1);

            //Console.WriteLine("\nFlight Cancellation");
            //fs.FlightCancellation(flight2.Code); //stack

            //Console.WriteLine("\nForward Navigation");
            //FlightNode nextFlight = fs.NavigateFlightForward(flight2.BoardingTime); //dll

            //if (nextFlight != null)
            //{
            //    Console.WriteLine("Next Flight: " + nextFlight.Data.Code + " - " + nextFlight.Data.Name + " " + nextFlight.Data.BoardingTime);
            //}
            //else
            //{
            //    Console.WriteLine("No next flight");
            //}

            //Console.WriteLine("\nBackward Navigation");
            //FlightNode previousFlight = fs.NavigateFlightBackward(flight2.BoardingTime); //dll

            //if (previousFlight != null)
            //{
            //    Console.WriteLine("Previous Flight: " + previousFlight.Data.Code + " - " + previousFlight.Data.Name + " " + previousFlight.Data.BoardingTime);
            //}

            //else
            //{
            //    Console.WriteLine("No previous flight");
            //}

            //Console.WriteLine("\nFlight Lookup");
            //fs.FlightLookup(flight3.Code); //dictionary flights

            //Console.WriteLine("\nSorting Flights");
            //fs.SortFlightsByCode();//bubble sort

            //Console.WriteLine("\nBinary Search");
            //fs.BinarySearch(flight2.Code); //search according to flight code


            //problem statement 2 - Product of array except self
            //int[] arr = { 1, 2, 3, 4 };
            //int[] result = new int[arr.Length];
            //result = ProductExceptSelf.productExceptSelf(arr);
            //for (int i = 0; i < result.Length; i++)
            //{
            //    Console.Write(result[i] + " ");
            //}
            //Console.WriteLine();
            //int[] arr2 = { -1, 1, 0, -3, 3 };
            //int[] result2 = new int[arr2.Length];
            //result2 = ProductExceptSelf.productExceptSelf(arr2);
            //for (int i = 0; i < result2.Length; i++)
            //{
            //    Console.Write(result2[i] + " ");
            //}





            //============================
            // week 5 review main file

            var engine = new AccessAuditEngine();

            engine.AnomalyDetected += (sender, e) =>
            {
                Console.WriteLine($"Security Console: {e.Reason}");
            };

            engine.AnomalyDetected += (sender, e) =>
            {
                Console.WriteLine($"Incident Ticket: {e.Reason}");
            };

            engine.DetectAnomaly("OffHours");


        }
    }
}