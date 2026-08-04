using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectModeling
{
    internal class School
    {
        public string SchoolName;
        List<Course>courses;
        public School(string SchoolName)
        {
            this.SchoolName = SchoolName;
            courses = new List<Course>();
        }
        public void AddCourse(Course course)
        {
            courses.Add(course);
            Console.WriteLine($"{course.CourseName} course, added to School : {SchoolName}");
        }
    }
}
