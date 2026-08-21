namespace Collections_Streams
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Storage<Electronics> electronicsStorage = new Storage<Electronics>();
            electronicsStorage.AddItem(new Electronics(1, "Laptop", 55000m, 10, 24));
            electronicsStorage.AddItem(new Electronics(2, "Smartphone", 25000m, 20, 12));

            Storage<Groceries> groceriesStorage = new Storage<Groceries>();
            groceriesStorage.AddItem(new Groceries(1, "Rice Bag", 1200m, 50, DateTime.Now.AddMonths(6)));
            groceriesStorage.AddItem(new Groceries(2, "Wheat Flour", 450m, 30, DateTime.Now.AddMonths(3)));

            Storage<Furniture> furnitureStorage = new Storage<Furniture>();
            furnitureStorage.AddItem(new Furniture(1, "Office Chair", 3500m, 15, "Leather"));
            furnitureStorage.AddItem(new Furniture(2, "Wooden Table", 8000m, 8, "Wood"));

            Console.WriteLine("Electronics Inventory:");
            electronicsStorage.DisplayAllItems();

            Console.WriteLine();
            Console.WriteLine("Groceries Inventory:");
            groceriesStorage.DisplayAllItems();

            Console.WriteLine();
            Console.WriteLine("Furniture Inventory:");
            furnitureStorage.DisplayAllItems();

            Console.WriteLine();
            WarehouseOperations.ApplyDiscount(electronicsStorage.GetItemAt(0), 10m);
            Console.WriteLine("After 10% discount on Laptop:");
            electronicsStorage.GetItemAt(0).DisplayDetails();

            Console.WriteLine();
            WarehouseOperations.RestockItem(groceriesStorage.GetItemAt(1), 20);
            Console.WriteLine("After restocking Wheat Flour:");
            groceriesStorage.GetItemAt(1).DisplayDetails();

            Console.WriteLine();
            Console.WriteLine("Electronics above 20000:");
            List<Electronics> expensiveElectronics = electronicsStorage.GetItemsAbovePrice(20000m);
            int i = 0;
            while (i < expensiveElectronics.Count)
            {
                expensiveElectronics[i].DisplayDetails();
                i++;
            }
        }
    }
}
