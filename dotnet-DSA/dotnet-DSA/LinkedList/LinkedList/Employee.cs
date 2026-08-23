using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    internal class Employee
    {

        //ID, Name, Department, and Salary.

        public int Id { get; set; }
        public string Name { get; set; }
        public string Department {  get; set; }
        public double Salary {  get; set; }

        public Employee(int id, string name, string department, double salary)
        {
            Id = id;
            Name = name;
            Department = department;
            Salary = salary;
        }

    }
}
