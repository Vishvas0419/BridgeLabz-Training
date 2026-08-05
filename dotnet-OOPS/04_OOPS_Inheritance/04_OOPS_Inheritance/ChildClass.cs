using System;
using System.Collections.Generic;
using System.Text;

namespace _04_OOPS_Inheritance
{
    internal class ChildClass
    {
        //public int age { get; set; }
        public int age { get; set; }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public int getAge()
        {
            return age;
        }
        public void setAge(int age)
        {

            //exception handling also
            this.age = age;
        }

        public void display()
        {
            Console.WriteLine();
        }
    }
}
