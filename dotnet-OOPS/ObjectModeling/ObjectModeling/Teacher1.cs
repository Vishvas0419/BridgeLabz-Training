using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectModeling
{
    internal class Teacher1
    {
        public string name;
        public Teacher1(string name)
        {
            this.name = name;
        }
        public void Teach(Student1 student)
        {
            Console.WriteLine($"{name} teaches {student.name}");
        }

    }
}
