using System;
using System.Collections.Generic;
using System.Text;

namespace Encapsulation_Practise
{
    internal class Student
    {
        private int age; //field

        public Student() { }
        public Student(int age)
        {
            this.age = age;
        }
        public int Age //property
        {
            get { return age; }

            set { age = value; }
        }

        public int GetAge()
        {
            return age;
        }

        public void SetAge(int age)
        {
            this.age = age;
        }

    }
    internal class Student2
    {
        private int age { get; set; } //property but age is field

    }

    internal class Student3
    {
        private int age;

        public int GetAge()
        {
            return age;
        }

        public void SetAge(int age)
        {
            this.age = age;
        }
    }
}
