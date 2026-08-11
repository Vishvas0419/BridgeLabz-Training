namespace Employee_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Developer(1, "Vishvas", 23, "IT");
            emp.DisplayDetails();
        }
    }
}
