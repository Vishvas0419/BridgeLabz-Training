using System;
using System.Collections.Generic;
using System.Text;

namespace _05_Polymorphism_Interfaces_AbstractClasses
{
    internal abstract class Employee
    {
        private int employeeId;
        private string name;
        private double baseSalary;

        public int EmployeeId
        {
            get { return employeeId; }
            set { employeeId = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double BaseSalary
        {
            get { return baseSalary; }
            protected set { baseSalary = value; }
        }

        protected Employee(int employeeId, string name, double baseSalary)
        {
            this.employeeId = employeeId;
            this.name = name;
            this.baseSalary = baseSalary;
        }

        public abstract double CalculateSalary();

        public void DisplayDetails()
        {
            Console.WriteLine("Employee ID   : " + employeeId);
            Console.WriteLine("Name          : " + name);
            Console.WriteLine("Base Salary   : " + baseSalary);
            Console.WriteLine("Final Salary  : " + CalculateSalary());
        }
    }

    class FullTimeEmployee : Employee
    {
        private string department;
        private double monthlyBonus;

        public double MonthlyBonus
        {
            get { return monthlyBonus; }
            set { monthlyBonus = value; }
        }

        public FullTimeEmployee(int employeeId, string name, double baseSalary, double monthlyBonus)
            : base(employeeId, name, baseSalary)
        {
            this.monthlyBonus = monthlyBonus;
        }

        public override double CalculateSalary()
        {
            return BaseSalary + monthlyBonus;
        }

        public void AssignDepartment(string departmentName)
        {
            department = departmentName;
        }

        public string GetDepartmentDetails()
        {
            if (department == null)
            {
                return "No department assigned";
            }
            return "Department: " + department;
        }
    }

    class PartTimeEmployee : Employee
    {
        private string department;
        private double hoursWorked;
        private double hourlyRate;

        public double HoursWorked
        {
            get { return hoursWorked; }
            set { hoursWorked = value; }
        }

        public double HourlyRate
        {
            get { return hourlyRate; }
            set { hourlyRate = value; }
        }

        public PartTimeEmployee(int employeeId, string name, double hoursWorked, double hourlyRate)
            : base(employeeId, name, 0)
        {
            this.hoursWorked = hoursWorked;
            this.hourlyRate = hourlyRate;
        }

        public override double CalculateSalary()
        {
            return hoursWorked * hourlyRate;
        }

        public void AssignDepartment(string departmentName)
        {
            department = departmentName;
        }

        public string GetDepartmentDetails()
        {
            if (department == null)
            {
                return "No department assigned";
            }
            return "Department: " + department;
        }
    }

}
