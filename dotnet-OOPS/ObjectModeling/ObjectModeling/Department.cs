using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectModeling
{
    internal class Department
    {
        public string name;
        public Teacher2 teacher;

        public Department(string name, Teacher2 teacher)
        {
            this.name = name;
            this.teacher = teacher;
        }
        public void display()
        {
            Console.WriteLine($"{teacher.name} teaches in {name} department");
        }
    }
}
