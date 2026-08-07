using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace _05_Polymorphism_Interfaces_AbstractClasses
{
    //Polymorphism with Interfaces

    internal interface IShape
    {   
        void Draw();
        void display()
        {
            Console.WriteLine("This is a interface");
        }
        static void displayStatic() //by default they are public
        {
            Console.WriteLine("Calling a Static Method in Interface");
        }
    }

    internal interface IShape2
    {
        void Draw2();
    }

    class Rectangle : IShape, IShape2
    {
        public static void display()
        {
            Console.WriteLine("Rectangle display() method");
        }
        public Rectangle()
        {
            Console.WriteLine("You created object of Rectangle class");
        }
        public void Draw()
        {
            Console.WriteLine("Drawing Rectangle");
        }


        public void Draw2()
        {
            Console.WriteLine("this is draw2 method of Interface IShape2");
        }
    }

    class Circle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Drawing Circle");
        }
    }
}
