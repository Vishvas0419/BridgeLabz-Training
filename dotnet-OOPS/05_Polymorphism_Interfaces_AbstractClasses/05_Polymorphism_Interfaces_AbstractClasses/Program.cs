namespace _05_Polymorphism_Interfaces_AbstractClasses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FullTimeEmployee fte1 = new FullTimeEmployee(1, "Aman Sharma", 40000, 5000);
            fte1.AssignDepartment("Engineering");

            FullTimeEmployee fte2 = new FullTimeEmployee(2, "Riya Kapoor", 45000, 6000);
            fte2.AssignDepartment("Finance");

            PartTimeEmployee pte1 = new PartTimeEmployee(3, "Karan Mehta", 80, 250);
            pte1.AssignDepartment("Support");

            PartTimeEmployee pte2 = new PartTimeEmployee(4, "Neha Verma", 60, 300);
            pte2.AssignDepartment("Marketing");

            List<Employee> employees = new List<Employee>
            {
                fte1, fte2, pte1, pte2
            };

            int index = 0;
            while (index < employees.Count)
            {
                Employee emp = employees[index];
                emp.DisplayDetails();

                if (emp is IDepartment deptEmp)
                {
                    Console.WriteLine(deptEmp.GetDepartmentDetails());
                }

                Console.WriteLine(new string('-', 30));
                index++;
            }
        }
    }
}
