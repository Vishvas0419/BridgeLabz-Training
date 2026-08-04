using System.Collections.Concurrent;
using System.Diagnostics;

namespace _03Keywords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");

            //BankAccount acc = new BankAccount("Vishvas",1234567890);
            //BankAccount acc2 = new BankAccount("Rahul", 1234567980);

            //if(acc is BankAccount)
            //{
            //    Console.WriteLine("This is a valid bank account object");

            //}
            //else
            //{
            //    Console.WriteLine("This is not a valid bank account object");
            //}

            //acc.display();
            //acc.GetTotalAccounts();

            //acc2.display();
            //acc2.GetTotalAccounts();

            //Product prod = new Product("Sunscreen", 3939.0, 2, 001);
            //prod.display();

            //Product.UpdateDiscount(20);

            //prod.display();
            //Product.ProcessItem(prod);

            //Patient p1 = new Patient("Vishvas",22,"Disease",1);
            //Patient.ProcessPatient(p1);
            //Patient p2 = new Patient("vishu", 22, "Disease", 1);
            //Patient.ProcessPatient(p2);

            //Patient p3 = new Patient("Amol", 33, "Disease", 1);
            //Patient.ProcessPatient(p3);



            //with static variable
            //Counter c1 = new Counter();
            //Counter c2 = new Counter();
            //Counter c3 = new Counter();

            //c1.displayCount();
            //c2.displayCount();
            //c3.displayCount();

            //Console.WriteLine(Counter.count);// 03
            ////Why access with class name?

            ////Because it belongs to class. Student.count not s1.count
            ////without static variable
            //Counter2 cnt1 = new Counter2();
            //Counter2 cnt2 = new Counter2();
            //Counter2 cnt3 = new Counter2();

            ////Console.WriteLine(Counter2.count); 

            //cnt3.displayCount();    //1


            //Practise p = new Practise();

            Animal a = new Dog();
            Console.WriteLine(a is Dog); //true because a is refering to Dog class Object

            Console.WriteLine(a is Animal); //because (a IS A Animal) and Animal inherits properties to Dog





        }
    }
}
