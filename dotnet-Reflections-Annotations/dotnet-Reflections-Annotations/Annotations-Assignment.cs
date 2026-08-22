using System;
using System.Collections.Generic;
using System.Text;

namespace dotnet_Reflections_Annotations
{
    class Animal
    {
        public virtual void MakeSound()
        {
            Console.WriteLine("Animal makes a sound");
        }
    }

    class Dog : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Dog barks");
        }
    }

    internal class Annotations_Assignment
    {
        public static void MethodOverriding()
        {
            Dog dog = new Dog();

            dog.MakeSound();
        }
    }
   
}
