namespace ObjectModeling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //    School school = new School("Mukand Lal Public School");
            //    Student student1 = new Student("Vishvas", 1082);
            //    Teacher teacher1 = new Teacher("Amol Goswami", 1234);
            //    Course course1 = new Course("Introduction to OOPS in C#",teacher1);
            //    Course course2 = new Course("Basics of C#", teacher1);

            //    school.AddCourse(course1);
            //    school.AddCourse(course2);

            //    course1.enrollStudent(student1, teacher1);
            //    course2.enrollStudent(student1, teacher1);


            ////    public void displayStudentDetails(Student student1,Teacher teacher1,Course course1)
            ////{

            ////}
            ////Console.WriteLine(student1.name + " ");
            //Console.WriteLine($"Student {student1.name} is currently being tought by {teacher1.name} in Course : {course1.CourseName} and studies in {school.SchoolName}");


            //Association (weakest relationship) both knows each other but are independent doesnt depden on each other 
            //Student1 s = new Student1("Vishvas");
            //Teacher1 t = new Teacher1("Amol");

            //t.Teach(s);

            //Aggregation - Parent has a child but child can live without Parent (weak relationship)

            //Teacher2 teacher = new Teacher2("Mr. Pankaj");
            //Department dept = new Department("Computer Science", teacher);

            //dept.display();

            Engine e = new Engine("V8 turbo-charged");
            Car car = new Car("Mercedes Gwagon (brabus kit)",e);
            //e.Start();

            car.StartCar();








        }
    }
}
