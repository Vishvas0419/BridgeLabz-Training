using System.ComponentModel;
using System.Runtime.InteropServices;

namespace _05_Polymorphism_Interfaces_AbstractClasses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //FullTimeEmployee fte1 = new FullTimeEmployee(1, "Aman Sharma", 40000, 5000);
            //fte1.AssignDepartment("Engineering");

            //FullTimeEmployee fte2 = new FullTimeEmployee(2, "Riya Kapoor", 45000, 6000);
            //fte2.AssignDepartment("Finance");

            //PartTimeEmployee pte1 = new PartTimeEmployee(3, "Karan Mehta", 80, 250);
            //pte1.AssignDepartment("Support");

            //PartTimeEmployee pte2 = new PartTimeEmployee(4, "Neha Verma", 60, 300);
            //pte2.AssignDepartment("Marketing");

            //List<Employee> employees = new List<Employee>
            //{
            //    fte1, fte2, pte1, pte2
            //};

            //int index = 0;
            //while (index < employees.Count)
            //{
            //    Employee emp = employees[index];
            //    emp.DisplayDetails();

            //    if (emp is IDepartment deptEmp)
            //    {
            //        Console.WriteLine(deptEmp.GetDepartmentDetails());
            //    }

            //    Console.WriteLine(new string('-', 30));
            //    index++;
            //}


            //encapsulation example
            //BankAccount1 acc1 = new BankAccount1("12345678990","Vishvas",100000.0);
            //acc1.displayAccountDetails();

            //Console.WriteLine(acc1.Balance);
            //Console.WriteLine(acc1.Balance = );
            //acc1.Balance = 20000.0; //using setter property of Balance
            //Console.WriteLine("Updated Balance: "+acc1.Balance); //using getter property of getter

            //acc1.displayAccountDetails();

            //acc1.Deposit(2000.0);
            //acc1.withdraw(1000000.0);

            //acc1.displayAccountDetails();

            //Console.WriteLine(acc1.AccountNumber); //using getter property
            //Console.WriteLine(acc1.);

            //method overloading
            //Calculator calc = new Calculator();
            //Console.WriteLine(calc.Add(5, 10));         // Calls Method 1
            //Console.WriteLine(calc.Add(5.5, 2.5));      // Calls Method 2
            //Console.WriteLine(calc.Add(1, 2, 3));       // Calls Method 3


            ////method overriding
            //Animal animal = new Animal();
            //Animal bird = new Bird();
            //Animal dog = new Dog();
            //animal.Sound(); //animal sound method called because Object type is of Animal clsss
            //dog.Sound();
            //bird.Sound();


            // Polymorphism with Interfaces

            //IShape shape1 = new Rectangle();
            //IShape shape2 = new Circle();


            //Rectangle rec = new Rectangle();

            //rec.Draw();

            //IShape shape = new Rectangle();
            //shape.display(); //default method of interfcase being called through a derived class

            //IShape.displayStatic(); //calling 



            //Rectangle rec2 = new Rectangle();
            //rec2.display(); //error because display() belongs to interface (IShape) , not to the derived class (Rectangle) and only the methods which are reqd to be implemented can be called by derived class

            //Rectangle rec2= new Rectangle();

            //rec2.Draw2();


            //Ecommerce platform
            //List<Product> products = new List<Product>();

            ////Product p = new Electronics(1, "Laptop", 60000.0);

            //products.Add(new Electronics(1, "Laptop", 60000.0));
            //products.Add(new Clothing(2, "Shirt", 1200.0));
            //products.Add(new Groceries(3, "Vegetables", 200.0));

            //foreach (Product item in products)
            //{
            //    item.DisplayDetails();
            //}

            //Banking Management System

            //List<BankAccount> accounts = new List<BankAccount>();

            //accounts.Add(new SavingsAccount("123456789", "Vishvas", 20000.0));
            //accounts.Add(new CurrentAccount("0987654321", "Vishu", 10000.0));

            //for(int i=0;i<accounts.Count;i++)
            //{
            //    BankAccount account = accounts[i];
            //    account.Deposit(2000.0);
            //    account.withdraw(5000.0);
            //    account.DisplayAcccountDetails();
            //}

            //Hospital Management System

            //List<Patient> patients = new List<Patient>();

            //InPatient inPatient1 = new InPatient(1, "Ravi Kumar", 45, 5, 2000, "Pneumonia");
            //inPatient1.AddRecord("Admitted with fever and cough");
            //inPatient1.AddRecord("X-Ray confirmed pneumonia");

            //OutPatient outPatient1 = new OutPatient(2, "Simran Kaur", 30, 800, "Seasonal Flu");
            //outPatient1.AddRecord("Prescribed antibiotics and rest");

            //patients.Add(inPatient1);
            //patients.Add(outPatient1);

            //int index = 0;
            //while (index < patients.Count)
            //{
            //    Patient currentPatient = patients[index];
            //    currentPatient.GetPatientDetails();
            //    index++;
            //}


            // Operator Overloading 

            Box1 box1 = new Box1(20);
            Box1 box2 = new Box1(30);

            Box1 result = box1.Add(box2);

            Console.WriteLine(result.Length); //50


        }
    }
}
