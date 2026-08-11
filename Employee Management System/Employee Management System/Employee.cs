using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Management_System
{
    internal interface IPayable
    {
        double CalculateSalary();
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
        private double salary;

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
            private set {  age = value; }
        }
        public int NumberOfOvertimeShifts
        {
            get { return numberOfOvertimeShifts; }
            private set { numberOfOvertimeShifts = value; }
        }
        public double Salary
        {
            get { return salary; }
            private set { salary = value; }
        }

        public string Department
        {
            get { return department; }
            private set { department = value; }
        }

        public Employee(int employeeID, string name, int age,string Department)
        {
            this.employeeID = employeeID;
            this.name = name;
            this.age = age;
            this.department = Department;
        }
        public abstract double CalculateSalary();
        public abstract double CalculateBonus();
        public virtual void DisplayDetails()
        {
            Console.WriteLine($"Employee ID: {employeeID}, Name: {name}, Age: {age}, Department: {department}");
        }
        public void ClockIn()
        {
            Console.WriteLine($"{name} has clocked in.");
        }
        public void ClockOut()
        {
            Console.WriteLine($"{name} has clocked out.");
        }
    }
    internal class Developer : Employee, IBonusable
    {
        public Developer(int employeeID, string name, int age, string department) : base(employeeID, name, age, department){}


        public void writeCode()
        {
            Console.WriteLine("Writing code...");
        }
        public void reviewCode()
        {
            Console.WriteLine("Reviewing code...");
        }

        public override double CalculateBonus()
        {
            // Implementation for calculating developer bonus
            double bonus = 1;
            return NumberOfOvertimeShifts * bonus;
        }

        public override double CalculateSalary()
        {
            double baseSalary = 50000; 
            double overtimePay = NumberOfOvertimeShifts * 50;
            return baseSalary + overtimePay;
        }
        public override void DisplayDetails()
        {
            //base.DisplayDetails();
            Console.WriteLine($"Salary: {CalculateSalary()}");
        }
    }
    internal class Manager : Employee
    {
        private int employeeID;
        private string name;
        private int age;
        private string department;
        //private string designation;
        private int workingHours;

        public Manager(int employeeID, string name, int age, string department, int workingHours) : base(employeeID, name, age, department) {
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
        public override double CalculateBonus()
        {
            return 5000;
        }

    }
    internal class HRRepresentative : Employee
    {
        
        public HRRepresentative(int employeeID, string name, int age, string department) : base(employeeID, name, age, department) { }
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
        public override double CalculateBonus()
        {
            return 2000; 
        }
    }