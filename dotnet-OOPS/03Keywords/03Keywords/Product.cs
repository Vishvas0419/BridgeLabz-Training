using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _03Keywords
{
    internal class Product
    {

        private readonly int ProductID;
        private string ProductName;
        private double Price;
        private int Quantity;
        private static double Discount;

        public Product(string productName, double price, int quantity, int productID)
        {
            ProductName = productName;
            Price = price;
            Quantity = quantity;
            ProductID = productID;
        }

        public static void UpdateDiscount(double newDiscount)
        {
            Discount = newDiscount;
        }

        public double GetFinalPrice()
        {
            double totalPrice = Price * Quantity;
            double discountAmount = (totalPrice * (Discount/100));

            return totalPrice - discountAmount;
        }
        public static void ProcessItem(object item)
        {
            if (item is Product p)   // checks type AND casts into 'p' in one step
            {
                Console.WriteLine("Valid Product detected. Processing...");
                p.display();
            }
            else
            {
                Console.WriteLine("This object is NOT a Product. Skipping...");
            }
        }
        public void display()
        {
            Console.WriteLine("Product id : "+ProductID);
            Console.WriteLine("Product Name : "+ProductName);
            Console.WriteLine("Product Price of one product : "+Price);
            Console.WriteLine("Quantity of Products : "+Quantity);

            Console.WriteLine("Discount on Product : "+Discount);
            Console.WriteLine("Price before discount : "+Price * Quantity);

            Console.WriteLine("=============");

            Console.WriteLine("Final Price of the Product after discount : "+GetFinalPrice());

        }


    }
}
