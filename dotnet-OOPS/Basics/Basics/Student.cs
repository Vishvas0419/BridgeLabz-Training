using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Basics
{
    class Student
    {
        //public string name;
        //public int age;

        //public Student(string name, int age)
        //{
        //    this.name = name;
        //    this.age = age;
        //}

        //public void displayStudentDetails()
        //{
        //    Console.WriteLine($"Good Morning, my name is {name} and i am {age} years old");
        //}

        //static belongs to class can be accesed in other classes 

        //static string name = "Vishvas";

        //getters and setters 

        private int marks;
        private string name;
        private int rollNumber;

        public Student(int marks,string name,int rollNumber)
        {
            this.marks = marks;
            this.name = name;
            this.rollNumber = rollNumber;
        }

        //public int getMarks()
        //{
        //    return marks;
        //}

        public int Name { get; set; }

    }
    class Teacher
    {
        //static string name = "Ashok";
        //static int teacherId = 01;

    }
}
