using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectModeling
{
    internal class Course
    {
        public string CourseName;
        public Teacher Instructor;
        public List<Student> enrolledStudents;

        public Course(string CourseName, Teacher Instructor)
        {
            this.CourseName = CourseName;
            this.Instructor = Instructor;
            enrolledStudents = new List<Student>();
        }

        public void enrollStudent(Student student,Teacher instructor)
        {
            enrolledStudents.Add(student);
            Console.WriteLine($"{student.name} has been enrolled in this Course successfully !");
        }

        public void displayStudents()
        {
            Console.WriteLine("Students enrolled in "+CourseName+" : ");
            foreach (var student in enrolledStudents)
            {
                Console.WriteLine(student.name);
            }
        }
    }
}
