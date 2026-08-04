using System;
using System.Collections.Generic;
using System.Text;

namespace _03Keywords
{
    internal class Practise
    {

        //this keyword
        private string name;
        private int marks;

        public Practise() : this("vishvas", 22) { }
        public Practise(string name, int marks)
        {
            this.name = name; //this.name is instance variable and name is parameter passed variable which is passed during object creation
            this.marks = marks;
        }

        public void display()
        {
            Console.WriteLine("Name : " + name);
            Console.WriteLine("marks: " + marks);
            this.display2(); //Calls another method in the same class
        }
        public void display2()
        {
            Console.WriteLine("Display 2 called");
        }

    }


    //static keyword
    internal class Counter
    {
        public static int count = 0; //with static variable
        public Counter()
        {
            count++;
        }

        public void displayCount()
        {
            Console.WriteLine("Count : " + count);
        }
    }

    internal class Counter2
    {
        public int count = 0; //without static variable
        public Counter2()
        {
            count++;
        }

        public void displayCount()
        {
            Console.WriteLine("Count : " + count);
        }
    }

    //sealed keyword in c#

    sealed public class SealedClass
    {
        private string name;
        private int age;
        public SealedClass(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        //public virtual void display()
        //{
        //    Console.WriteLine("Sealed Class");
        //}

    }

    //public class Try : SealedClass
    //{

    //}

    //public class Try : SealedClass
    //{
    //    public override void display()
    //    {

    //    }
    //}

    class Animal
    {

    }

    class Dog : Animal
    {

    }
}



