using static System.Net.Mime.MediaTypeNames;

namespace LinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //PractiseLL
            //Node head = new Node(10);
            //head.Next = new Node(20);
            //head.Next.Next = new Node(30);
            //head.Next.Next.Next = new Node(40);
            //PractiseLL.Display(head);

            //head = PractiseLL.InsertAtBegin(head,0);
            //PractiseLL.Display(head);
            //PractiseLL.InsertAtEnd(head, 50);
            //PractiseLL.Display(head);

            //head = PractiseLL.InsertAtPosition(head, 100, 1);
            //PractiseLL.Display(head);

            //Employee Management System

            EmployeeLL list = new EmployeeLL();

            list.InsertAtEnd(new Employee(1, "Vishvas", "Engineering", 50000));
            list.InsertAtEnd(new Employee(2, "Riya", "HR", 45000));
            list.InsertAtBegin(new Employee(3, "Aman", "Sales", 40000));
            list.InsertAtPosition(new Employee(4, "Priya", "Finance", 55000), 1);

            list.Display();

            var found = list.SearchById(2);
            Console.WriteLine(found != null ? $"Found: {found.Name}" : "Not found");

            list.DeleteById(1);
            list.Display();













        }
    }
}
