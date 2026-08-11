using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Management_System
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
                $"Employee ID: {EmployeeID}, " +$"Name: {Name}, " + $"Age: {Age}, " + $"Department: {Department}");
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
            : base(employeeID, name, age, department){}

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
}