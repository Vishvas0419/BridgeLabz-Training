using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Collections_Streams
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



            //==============================
            //JSON_DataHandling 

            //JSON_DataHandling handler = new JSON_DataHandling();

            //JArray jsonMatches = handler.ReadJson("ipl_data.json");
            //JArray censoredJson = handler.CensorJson(jsonMatches);
            //handler.WriteJson("ipl_data_censored.json", censoredJson);

            //List<Dictionary<string, string>> csvMatches = handler.ReadCsv("ipl_data.csv");
            //List<Dictionary<string, string>> censoredCsv = handler.CensorCsv(csvMatches);
            //handler.WriteCsv("ipl_data_censored.csv", censoredCsv);

            //Console.WriteLine("Censorship complete.");

            //=================================
            //CSV_DataHandling 
            CSV_DataHandling handler = new CSV_DataHandling();

            List<Dictionary<string, string>> employees = handler.ReadCsv("employees.csv");
            List<Dictionary<string, string>> updatedEmployees = handler.IncreaseSalaryForDepartment(employees, "IT", 10m);

            string[] headers = { "id", "name", "department", "salary" };
            handler.WriteCsv("employees_updated.csv", updatedEmployees, headers);

            Console.WriteLine("Salary update complete.");

        }
    }
}
