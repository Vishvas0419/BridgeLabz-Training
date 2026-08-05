using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace _04_OOPS_Inheritance
{
    internal class Animal
    {
        public Animal()
        {
            Console.WriteLine("Animal Contructor called");
        }
        public void Eat()
        {
            Console.WriteLine("Animal is Eating..");
        }
    }
    //single inheritance
    class Dog : Animal
    {
        public Dog()
        {
            Console.WriteLine("Cat Contructor called");
        }
        //method hiding
        //public new void Eat() //using new keyword here means that you are just hiding the Eat() method implementation in Parent (Animal class) and you intetionally want the dog Eat() method to have its own implpementation and hide base class Eat() method 
        //{
        //    Console.WriteLine("Dog is Eating");
        //}
        public void Bark()
        {
            Console.WriteLine("Dog is barking..");
        }
    }
    class Cat : Dog
    {
        public Cat()
        {
            Console.WriteLine("Cat Constructor called");
        }
        public void Meow()
        {
            Console.WriteLine("Cat says Meow");
        }
    }


    //hierarchical inheritance :  when one or more child classes inherits properties from the single parent class
    class Parent 
    {
        //private string name;
        public Parent()
        {
            Console.WriteLine("Parent class contructor called..");
        }

        public void display()
        {
            Console.WriteLine("Display method of parent class");
        }
    }

    class Child1 : Parent
    {
        //public string name;`
        public Child1() : base()
        {
            Console.WriteLine("Child1 class constructor called...");
        }

        public void display()
        {
            Console.WriteLine("Child1 overrided the parent display() method");
        }
    }

    class Child2 : Parent
    {
        //public string name;
        public Child2() : base()
        {
            Console.WriteLine("Child2 class constructor called...");
        }

        

        //public new void display()
        //{
        //    Console.WriteLine("Child2 class display using new keyword");
        //}

        public new void display()
        {
            Console.WriteLine("Child2 class diplay method using new keyword");
        }
    }

}
