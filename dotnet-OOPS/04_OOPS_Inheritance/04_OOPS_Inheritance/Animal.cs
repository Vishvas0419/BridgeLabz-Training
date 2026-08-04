using System;
using System.Collections.Generic;
using System.Net.WebSockets;
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

}
