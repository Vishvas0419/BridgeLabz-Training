using System;
using System.Collections.Generic;
using System.Text;

namespace _01Generics
{
    public abstract class WarehouseItem : IDisplayable
    {
        private int itemId;
        private string name;
        private decimal price;
        private int quantity;

        public int ItemId
        {
            get { return itemId; }
            set { itemId = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        protected WarehouseItem(int itemId, string name, decimal price, int quantity)
        {
            ItemId = itemId;
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public abstract void DisplayDetails();
    }


    public class Electronics : WarehouseItem
    {
        private int warrantyMonths;

        public int WarrantyMonths
        {
            get { return warrantyMonths; }
            set { warrantyMonths = value; }
        }

        public Electronics(int itemId, string name, decimal price, int quantity, int warrantyMonths)
            : base(itemId, name, price, quantity)
        {
            WarrantyMonths = warrantyMonths;
        }

        public override void DisplayDetails()
        {
            Console.WriteLine("Electronics -> Id: " + ItemId + ", Name: " + Name + ", Price: " + Price + ", Quantity: " + Quantity + ", Warranty: " + WarrantyMonths + " months");
        }
    }

    public class Groceries : WarehouseItem
    {
        private DateTime expiryDate;

        public DateTime ExpiryDate
        {
            get { return expiryDate; }
            set { expiryDate = value; }
        }

        public Groceries(int itemId, string name, decimal price, int quantity, DateTime expiryDate)
            : base(itemId, name, price, quantity)
        {
            ExpiryDate = expiryDate;
        }

        public override void DisplayDetails()
        {
            Console.WriteLine("Groceries -> Id: " + ItemId + ", Name: " + Name + ", Price: " + Price + ", Quantity: " + Quantity + ", Expiry: " + ExpiryDate.ToShortDateString());
        }
    }


    public class Furniture : WarehouseItem
    {
        private string material;

        public string Material
        {
            get { return material; }
            set { material = value; }
        }

        public Furniture(int itemId, string name, decimal price, int quantity, string material)
            : base(itemId, name, price, quantity)
        {
            Material = material;
        }

        public override void DisplayDetails()
        {
            Console.WriteLine("Furniture -> Id: " + ItemId + ", Name: " + Name + ", Price: " + Price + ", Quantity: " + Quantity + ", Material: " + Material);
        }
    }


    class Storage<T> : IReadOnlyStorage<T> where T : WarehouseItem
    {
        private List<T> items;

        public int Count
        {
            get { return items.Count; }
        }

        public Storage()
        {
            items = new List<T>();
        }

        public void AddItem(T item)
        {
            items.Add(item);
        }

        public bool RemoveItem(int itemId)
        {
            T itemToRemove = FindItem(itemId);
            if (itemToRemove != null)
            {
                items.Remove(itemToRemove);
                return true;
            }
            return false;
        }

        public T FindItem(int itemId)
        {
            int index = 0;
            while (index < items.Count)
            {
                if (items[index].ItemId == itemId)
                {
                    return items[index];
                }
                index++;
            }
            return null;
        }

        public T GetItemAt(int index)
        {
            return items[index];
        }

        public void DisplayAllItems()
        {
            int index = 0;
            while (index < items.Count)
            {
                items[index].DisplayDetails();
                index++;
            }
        }

        public List<T> GetItemsAbovePrice(decimal minPrice)
        {
            return items.Where(item => item.Price > minPrice).ToList();
        }
    }

    public static class WarehouseOperations
    {
        public static void ApplyDiscount<T>(T item, decimal percentage) where T : WarehouseItem
        {
            decimal discountAmount = item.Price * (percentage / 100m);
            item.Price = item.Price - discountAmount;
        }

        public static void RestockItem<T>(T item, int additionalQuantity) where T : WarehouseItem
        {
            item.Quantity = item.Quantity + additionalQuantity;
        }
    }
}
