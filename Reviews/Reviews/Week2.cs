using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Reviews
{
    //Employee Management System (OOPS)
    internal class Week2
    {
        internal interface IPayable
        {
            void ProcessPayment();
        }
        internal interface IBonusable
        {
            double CalculateBonus();
        }
        internal interface IEvaluable
        {
            void PerformEvaluation();
        }
        internal abstract class Employee
        {
            private int employeeID;
            private string name;
            private int age;
            private string department;
            private int numberOfOvertimeShifts;

            public int EmployeeID
            {
                get { return employeeID; }
                private set
                {
                    employeeID = value;
                }
            }

            public string Name
            {
                get { return name; }
                private set
                {
                    name = value;
                }
            }

            public int Age
            {
                get { return age; }
                private set
                {
                    age = value;
                }
            }

            public int NumberOfOvertimeShifts
            {
                get { return numberOfOvertimeShifts; }
                private set
                {
                    numberOfOvertimeShifts = value;
                }
            }

            public string Department
            {
                get { return department; }
                private set
                {
                    department = value;
                }
            }

            public Employee(
                int employeeID,
                string name,
                int age,
                string department)
            {
                this.employeeID = employeeID;
                this.name = name;
                this.age = age;
                this.department = department;
            }

            public void AddOvertimeShift()
            {
                NumberOfOvertimeShifts++;
            }



            public abstract double CalculateSalary();

            public virtual void DisplayDetails()
            {
                Console.WriteLine(
                    $"Employee ID: {EmployeeID}, " + $"Name: {Name}, " + $"Age: {Age}, " + $"Department: {Department}");
            }


            public void ClockIn()
            {
                Console.WriteLine($"{Name} has clocked in.");
            }


            public void ClockOut()
            {
                Console.WriteLine($"{Name} has clocked out.");
            }
        }
        internal class Developer : Employee, IPayable, IBonusable, IEvaluable
        {
            public Developer(
                int employeeID,
                string name,
                int age,
                string department)
                : base(employeeID, name, age, department) { }

            public void WriteCode()
            {
                Console.WriteLine("Writing code...");
            }

            public void ReviewCode()
            {
                Console.WriteLine("Reviewing code...");
            }

            public override double CalculateSalary()
            {
                double baseSalary = 50000;
                double overtimePay = NumberOfOvertimeShifts * 50;

                return baseSalary + overtimePay;
            }

            public double CalculateBonus()
            {
                double bonus = 1;
                return NumberOfOvertimeShifts * bonus;
            }

            public void ProcessPayment()
            {
                Console.WriteLine($"Payment processed for {Name}. " + $"Salary: {CalculateSalary()}");
            }


            public void PerformEvaluation()
            {
                Console.WriteLine($"Performance evaluation completed for Developer {Name}.");
            }


            public override void DisplayDetails()
            {
                base.DisplayDetails();

                Console.WriteLine($"Salary: {CalculateSalary()}");
                Console.WriteLine($"Bonus: {CalculateBonus()}");
            }
        }
        internal class Manager : Employee, IPayable, IBonusable, IEvaluable
        {
            private int workingHours;

            public Manager(
                int employeeID,
                string name,
                int age,
                string department,
                int workingHours)
                : base(employeeID, name, age, department)
            {
                this.workingHours = workingHours;
            }


            public void AssignTask()
            {
                Console.WriteLine("Assigning task to team members...");
            }
            public void ApproveLeave()
            {
                Console.WriteLine("Approving leave request...");
            }
            public void ConductMeeting()
            {
                Console.WriteLine("Conducting team meeting...");
            }
            public override double CalculateSalary()
            {
                double baseSalary = 80000;
                double overtimePay = workingHours * 100;

                return baseSalary + overtimePay;
            }
            public double CalculateBonus()
            {
                return 5000;
            }
            public void ProcessPayment()
            {
                Console.WriteLine($"Payment processed for Manager {Name}. " + $"Salary: {CalculateSalary()}");
            }
            public void PerformEvaluation()
            {
                Console.WriteLine($"Performance evaluation completed for Manager {Name}.");
            }
            public override void DisplayDetails()
            {
                base.DisplayDetails();
                Console.WriteLine($"Salary: {CalculateSalary()}");
                Console.WriteLine($"Bonus: {CalculateBonus()}");
                Console.WriteLine($"Working Hours: {workingHours}");
            }
        }
        internal class HRRepresentative : Employee, IPayable, IBonusable, IEvaluable
        {
            public HRRepresentative(
                int employeeID,
                string name,
                int age,
                string department)
                : base(employeeID, name, age, department)
            {
            }
            public void OnboardEmployee()
            {
                Console.WriteLine("Onboarding new employee...");
            }
            public void ConductInterview()
            {
                Console.WriteLine("Conducting interview...");
            }
            public override double CalculateSalary()
            {
                return 60000;
            }
            public double CalculateBonus()
            {
                return 2000;
            }
            public void ProcessPayment()
            {
                Console.WriteLine(
                    $"Payment processed for HR Representative {Name}. " + $"Salary: {CalculateSalary()}");
            }
            public void PerformEvaluation()
            {
                Console.WriteLine(
                    $"Performance evaluation completed for HR Representative {Name}.");
            }
            public override void DisplayDetails()
            {
                base.DisplayDetails();

                Console.WriteLine($"Salary: {CalculateSalary()}");
                Console.WriteLine($"Bonus: {CalculateBonus()}");
            }
        }


        //======================================================================

        //problem 2 
        // Develop a program to get next day of a given date.
        // Expected Output:
        // Input a year: 2020
        // Input a month [1-12]: 08
        // Input a day [1-31]: 23
        // The next date is [yyyy-mm-dd] 2020-8-24
        public void FindNextDay()
        {
            Console.WriteLine("Enter a year : ");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter a month between 1 to 12 : ");

            int month = int.Parse(Console.ReadLine());
            if (month < 1 && month > 12) Console.WriteLine("Please Enter month between 1 to 12");

            Console.WriteLine("Enter a day between 1 to 31 : ");
            int date = int.Parse(Console.ReadLine());
            if (date < 0 && date > 31)
            {
                Console.WriteLine("Please Enter day between 1 to 31");
            }

            if (date == 31 && month == 12)
            {
                date = 1;
                month = 1;
                year++;

            }
            else if (date == 31)
            {
                month++;
                date = 1;
            }
            else date++;

            Console.WriteLine($"The Next Date is : {year}-{month}-{date}");
        }









        //======================================================================
        //Problem 3 - Find Length of the longest substring without repeating characters





        public static int LongestSubWithoutRepChar(string str)
        {
            int maxLen = int.MinValue;
            HashSet<char> set = new HashSet<char>();
            int i = 0; int j = 0;
            while (j < str.Length)
            {
                char ch = str[j];
                if (!set.Contains(ch))
                {
                    set.Add(ch);
                    maxLen = Math.Max(maxLen, j - i + 1);
                    j++;
                }
                else //if char not present in the set than 
                {
                    set.Remove(str[i]);
                    i++;
                }
            }
            return maxLen;
        }




        //==============================================================================


        // Problem 4 - Write a C# Sharp program that calculates the smallest gap between the numbers in an array of integers. Go to the editor
        // Sample Data:
        // ({ 7, 5, 8, 9, 11, 23, 18 }) -> 1 (diff btw 8,9)
        // ({ 200, 300, 250, 151, 162 }) -> 11 (diff btw 151, 162)   



        public static int SmallestGap(int[]arr,int n)
        {
            Array.Sort(arr);
            int minDiff = int.MaxValue;
            for (int i = 1; i < n; i++)
            {
                int diff = Math.Abs(arr[i] - arr[i - 1]);
                minDiff = Math.Min(diff, minDiff);
            }
            return minDiff;
        }


    }
}
