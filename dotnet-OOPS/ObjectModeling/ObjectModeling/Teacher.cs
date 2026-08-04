using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectModeling
{
    internal class Teacher
    {
        public string name;
        public int teacherId;
        public Teacher(string name, int teacherId)
        {
            this.name = name;
            this.teacherId = teacherId;
        }

        public void displayTeacher(School school)
        {
            Console.WriteLine($"Teachers enrolled in {school} ");
        }

    }
}
