using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace _04_OOPS_Inheritance
{
    internal class Assignment
    {

    }
    class AnimalClass
    {
        private string Name { get; set; }
        private int Age { get; set; }

        public virtual void MakeSound()
        {
            Console.WriteLine("Animal Makes sound");
        }
        
    }
    class DogClass : AnimalClass
    {
        public override void MakeSound()
        {
            Console.WriteLine("Dog barks");
        }
    }

    class CatClass : AnimalClass
    { 
        public override void MakeSound()
        {
            Console.WriteLine("Cat Meows");
        }
    }


    class BirdClass : AnimalClass
    {
        public override void MakeSound()
        {
            Console.WriteLine("Bird Chirps");
        }
    }

    

}
