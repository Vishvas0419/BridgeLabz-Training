using System;
using System.Collections.Generic;
using System.Text;


//2. Program to Compute Area of a Circle
//Problem Statement: Write a program to create a Circle class with an attribute radius.Add methods to calculate and display the area and circumference of the circle.

namespace Basics
{
    internal class Circle
    {
        private int Radius{ get; set; }

        public Circle(int radius)
        {
            Radius = radius;
        }

        public double calculateArea(int Radius)
        {
            return Math.PI * Radius * Radius;
        }

        public double calculateCircumference(int Radius)
        {
            return 2 * Math.PI * Radius;
        }

        public void display()
        {
            Console.WriteLine($"Area of circle : {calculateArea(Radius):F2}");
            Console.WriteLine($"Circumference of circle : {calculateCircumference(Radius):F2}");

        }

    }
}
