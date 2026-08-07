using System;
using System.Collections.Generic;
using System.Text;

//Console.WriteLine(age);
namespace _05_Polymorphism_Interfaces_AbstractClasses
{
    internal class Calculator
    {
        internal int age = 90;
        //Polymorphism
        //method overloading- multiple methods with the same name but different parameter lists in the same class.
        public int Add(int x, int y)
        {
            return x + y;
        }

        public double Add(double x, double y)
        {
            return x + y;
        }
        public int Add(double x, int y, int z)
        {
            return (int)x + y + z;
        }

    }


    //mehthod overriding - which method to call depends on Object type at runtime (dynamic method dispatch)
    internal class Animal
    {
        public virtual void Sound()
        {
            Console.WriteLine("Animal makes sound");
        }
    }

    internal class Dog : Animal
    {
        public override void Sound()
        {
            Console.WriteLine("Dog Barks");
        }
    }

    internal class Bird : Animal
    {
        public override void Sound()
        {
            Console.WriteLine("Bird Chirps");
        }
    }

    



}
