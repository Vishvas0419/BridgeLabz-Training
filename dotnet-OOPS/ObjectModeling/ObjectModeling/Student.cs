using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Text;

namespace ObjectModeling
{
    internal class Student
    {
        public string name;
        public int studentId;
        public Student(string name, int studentId)
        {
            this.name = name;
            this.studentId = studentId;
        }

        //public void displayStudentDetails(Student student,Teacher teacher,Course course,School school)
        //{
        //    Console.WriteLine($"Student {student.name} is currently being tought by {teacher.name} in Course : {course.CourseName} and studies in {school.SchoolName}");
        //}


    }

    
    
}
