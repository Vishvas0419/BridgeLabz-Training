namespace Basics
{
    internal class Program
    { 
        static void Main(string[] args)
        {
            //Student student = new Student();
            //student.name = "Vishvas";
            //student.age = 22;

            //student.displayStudentDetails();
            //Console.WriteLine(student.name);
            //Console.WriteLine(student.age);

            //Console.WriteLine(Student.name); //Vishvas can only be accessed only if there is 
            //Student s = new Student("Vishvas", 22);

            //s.displayStudentDetails();

            //Employee emp = new Employee("Vishvas",1082,2000000);
            //emp.displayDetails();

            //Console.WriteLine("Enter radius : ");
            //int radius = int.Parse(Console.ReadLine());
            //Circle c = new Circle(radius);
            //c.display();

            Console.Write("Enter Book Title : ");
            string? title = Console.ReadLine();

            Console.WriteLine("Enter Book Author : ");
            string author = Console.ReadLine();

            Console.WriteLine("Enter Book price");
            double price = double.Parse(Console.ReadLine());

            Book book = new Book();
            book.Title = title;
            book.Author = author;
            book.Price = price;
            book.displayBookDetails();








        }
    }
}
