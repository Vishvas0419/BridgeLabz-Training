using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace _05_Polymorphism_Interfaces_AbstractClasses
{

    internal interface ITaxable
    {
        double CalculateTax();
        void GetTaxDetails();

    }
    internal abstract class Product
    {
        private int productId;
        private string name;
        private double price;

        public Product(int productId, string name, double price)
        {
            this.productId = productId;
            this.name = name;
            this.price = price;
        }

        public int ProductID
        {
            get {  return productId; }

            private set { productId = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public abstract double CalculateDiscount();

        public double CalculateFinalPrice()
        {
            double tax = 0;

            if (this is ITaxable taxableProduct)
            {
                tax = taxableProduct.CalculateTax();
            }
            return Price + tax - CalculateDiscount();
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"Product Id : {ProductID}");
            Console.WriteLine($"Product Name : {Name}");
            Console.WriteLine($"Product Price : {Price}");
            Console.WriteLine($"Discount : {CalculateDiscount()}");


            if (this is ITaxable taxableProduct)
            {
                taxableProduct.GetTaxDetails();
            }

            Console.WriteLine($"Final Price after discount and adding tax : {CalculateFinalPrice()}");

        }
    }

    internal class Electronics : Product, ITaxable
    {
        public Electronics(int productId, string name, double price) : base(productId, name, price) { }
        public override double CalculateDiscount()
        {
            return Price * 0.10;
        }

        public double CalculateTax()
        {
            return Price * 0.18;

        }
        public void GetTaxDetails()
        {
            Console.WriteLine($"Tax (18% GST) : {CalculateTax()}");
        }
    }
    internal class Clothing : Product, ITaxable
    {
        public Clothing(int productId, string name, double price) : base(productId, name, price) { }
        public override double CalculateDiscount()
        {
            return Price * 0.20;
        }

        public double CalculateTax()
        {
            return Price * 0.18;
        }

        public void GetTaxDetails()
        {
            Console.WriteLine($"Tax (18% GST) : {CalculateTax()}");
        }

        //public void DisplayDetails()
        //{
        //    Console.WriteLine($"Product Id : {ProductID}");
        //    Console.WriteLine($"Product Name : {Name}");
        //    Console.WriteLine($"Product Price : {Price}");
        //    Console.WriteLine($"Discount : {CalculateDiscount()}");
        //}
    }

    internal class Groceries : Product
    {
        public Groceries(int productId, string name, double price) : base(productId, name, price) { }
        public override double CalculateDiscount()
        {
            return Price * 0.20;
        }

        //public double CalculateTax()
        //{
        //    return Price * 0.18;
        //}

        //public void DisplayDetails()
        //{
        //    Console.WriteLine($"Product Id : {ProductID}");
        //    Console.WriteLine($"Product Name : {Name}");
        //    Console.WriteLine($"Product Price : {Price}");
        //    Console.WriteLine($"Discount : {CalculateDiscount()}");
        //}
    }
}
