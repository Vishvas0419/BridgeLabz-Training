using static Reviews.Week2;

namespace Reviews
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //employee management system-week2


            //Problem 1
            Developer developer =
                new Developer(101, "Vishvas", 24, "IT");

            Manager manager =
                new Manager(102, "Rahul", 35, "Management", 10);

            HRRepresentative hr =
                new HRRepresentative(103, "USER", 30, "HR");


            // Developer overtime
            developer.AddOvertimeShift();
            developer.AddOvertimeShift();


            // Developer
            developer.DisplayDetails();
            developer.ClockIn();
            developer.WriteCode();
            developer.ReviewCode();
            developer.PerformEvaluation();
            developer.ProcessPayment();


            Console.WriteLine();


            // Manager
            manager.DisplayDetails();
            manager.AssignTask();
            manager.ApproveLeave();
            manager.ConductMeeting();
            manager.PerformEvaluation();
            manager.ProcessPayment();


            Console.WriteLine();


            // HR
            hr.DisplayDetails();
            hr.OnboardEmployee();
            hr.ConductInterview();
            hr.PerformEvaluation();
            hr.ProcessPayment();

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

            RegexParse parser = new RegexParse();

            ProfileStore<ViewingSession> store = new ProfileStore<ViewingSession>();

            string record = "USER:Alice|TITLE:Mission: Impossible - Fallout (2018)|GENRES:sci-fi,drama,thriller|WATCHED:80%|TS:2026-08-14T21:10:00";

            ViewingSession session = parser.Parse(record);
            session.display();

            //store is object to use the ProfileStore generic class methods
            store.AddSession(session);

            Dictionary<string, double> profile = store.GetProfile("Alice");
            foreach (var pair in profile)
            {
                Console.WriteLine(pair.Key + " : " + pair.Value);
            }

            List<ViewingSession> highWatchedSessions = store.GetHighlyWatchedSessions(80);
            Console.WriteLine("highly watched sessions : ");

            foreach(ViewingSession s in  highWatchedSessions)
            {
                Console.WriteLine(s.Title + " : " + s.WatchedPercentage + "%");
            }


            //==============================================================
            //Pyramid Arrangement
            int[] input = { 1, 4, 3, 6, 8, 7, 9, 2, 5, 0, 12, 23, -1 };
            int n = input.Length;
            int[] output = Week3.pyramid(input, n);
            for (int i = 0; i < output.Length; i++)
            {
                Console.Write(output[i] + " ");
            }












        }
    }
}