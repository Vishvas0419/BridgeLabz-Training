using System;
using System.Collections.Generic;
using System.Text;

namespace Basics
{
        /*
        1. Program to Display Employee Details 
        Problem Statement: Write a program to create an Employee class with attributes name, id, and salary. Add a method to display the details.
        */
    internal class Employee
    {
        private string Name { get; set; }
        private int EmployeeId { get; set; }
        private double Salary { get; set; }

        public Employee(string name, int id, long salary)
        {
            this.Name = name;
            this.EmployeeId = id;
            this.Salary = salary;
        }
        public void displayDetails()
        {
            Console.WriteLine("============= Employee Details ===============");
            Console.WriteLine($"Name : {Name}");
            Console.WriteLine($"Employee Id : {EmployeeId}");
            Console.WriteLine($"Salary : {Salary}");
        }


    }
}
