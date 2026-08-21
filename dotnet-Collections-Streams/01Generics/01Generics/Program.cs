using System.Collections;
using System.Numerics;

namespace _01Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Storage<Electronics> electronicsStorage = new Storage<Electronics>();
            //electronicsStorage.AddItem(new Electronics(1, "Laptop", 55000m, 10, 24));
            //electronicsStorage.AddItem(new Electronics(2, "Smartphone", 25000m, 20, 12));

            //Storage<Groceries> groceriesStorage = new Storage<Groceries>();
            //groceriesStorage.AddItem(new Groceries(1, "Rice Bag", 1200m, 50, DateTime.Now.AddMonths(6)));
            //groceriesStorage.AddItem(new Groceries(2, "Wheat Flour", 450m, 30, DateTime.Now.AddMonths(3)));

            //Storage<Furniture> furnitureStorage = new Storage<Furniture>();
            //furnitureStorage.AddItem(new Furniture(1, "Office Chair", 3500m, 15, "Leather"));
            //furnitureStorage.AddItem(new Furniture(2, "Wooden Table", 8000m, 8, "Wood"));

            //Console.WriteLine("Electronics Inventory:");
            //electronicsStorage.DisplayAllItems();

            //Console.WriteLine();
            //Console.WriteLine("Groceries Inventory:");
            //groceriesStorage.DisplayAllItems();

            //Console.WriteLine();
            //Console.WriteLine("Furniture Inventory:");
            //furnitureStorage.DisplayAllItems();

            //Console.WriteLine();
            //WarehouseOperations.ApplyDiscount(electronicsStorage.GetItemAt(0), 10m);
            //Console.WriteLine("After 10% discount on Laptop:");
            //electronicsStorage.GetItemAt(0).DisplayDetails();

            //Console.WriteLine();
            //WarehouseOperations.RestockItem(groceriesStorage.GetItemAt(1), 20);
            //Console.WriteLine("After restocking Wheat Flour:");
            //groceriesStorage.GetItemAt(1).DisplayDetails();

            //Console.WriteLine();
            //Console.WriteLine("Electronics above 20000:");
            //List<Electronics> expensiveElectronics = electronicsStorage.GetItemsAbovePrice(20000m);
            //int i = 0;
            //while (i < expensiveElectronics.Count)
            //{
            //    expensiveElectronics[i].DisplayDetails();
            //    i++;
            //}


            //practise program for generics 

            //Box<int> box1 = new Box<int>();
            //box1.Value = 20;
            //Console.WriteLine(box1.Value);
            //Box<string> box2 = new Box<string>();
            //box2.Value = "Hello this is box2 object which contains string datatype";

            //Box<int> box3 = new Box<int>();
            //box3.Value = 30;
            //box3.PrintInt(box1);


            ArrayList list = new ArrayList(); //in c#
            //ArrayList<Integer> list = new ArrayList<>(); // in java also using generics
            list.Add(1);
            list.Add("vishvas");
            int num = (int)list[0];
            Console.WriteLine(num);

            //for(int i=0;i<list.Count;i++)
            //{

            //}


            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}
            Box<int> b1 = new Box<int>();
            b1.Value = 90;
            b1.Print(b1);
        }
    }
}
