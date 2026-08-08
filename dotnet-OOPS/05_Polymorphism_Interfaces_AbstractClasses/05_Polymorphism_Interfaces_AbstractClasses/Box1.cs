using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace _05_Polymorphism_Interfaces_AbstractClasses
{

    //Operator Overloading
    internal class Box1
    {
        private int length;

        public int Length
        {
            get { return length; }
        }
        public Box1(int length)
        {
            this.length = length;
        }

        public Box1 Add(Box1 Other)
        {
            return new Box1(this.length +  Other.length);
        }

        public void displayLength()
        {
            Console.WriteLine("Length : ");
        }
    }
}
