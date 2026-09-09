using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using Newtonsoft.Json.Linq;

namespace Reviews
{
    public class Product
    {
        public string BillId { get; set; }
        public string Item { get; set; }
        public int Qty { get; set; }
        public decimal UnitPrice { get; set; }
        public string Category { get; set; }
    }

    public class TaxCategory
    {
        public string Code { get; set; }
        public decimal TaxPercent { get; set; }
    }

    public class Week6
    {
        public List<Product> ReadProducts(string filepath)
        {
            using (var reader = new StreamReader(filepath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var products = csv.GetRecords<Product>().ToList();
                return products;
            }
        }
        public void ValidateBillId(List<Product> products)
        {
            foreach (var product in products)
            {
                if (string.IsNullOrWhiteSpace(product.BillId))
                {
                    throw new PosException("Invalid BillId");
                }
            }
        }
        public void ValidateQuantity(List<Product> products)
        {
            foreach (var product in products)
            {
                if (product.Qty <= 0)
                {
                    throw new InvalidQuantityException("Invalid Quantity");
                }
            }
        }
        public void ValidatePrice(List<Product> products)
        {
            foreach (var product in products)
            {
                if (product.UnitPrice <= 0)
                {
                    throw new InvalidPriceException("Invalid Price");
                }
            }
        }
        public void ValidateCategory(List<Product> products, string jsonfilepath)
        {
            var categories = GetCategories(jsonfilepath);
            foreach (var product in products)
            {
                bool found = categories.Any(x => x.Code == product.Category);
                if (!found)
                {
                    throw new UnknownCategoryException("Unknown Category");
                }
            }
        }
        public void DetectDuplicateBillID(List<Product> products)
        {
            var billIds = new HashSet<string>();

            foreach (var product in products)
            {
                if (!billIds.Add(product.BillId))
                {
                    throw new DuplicateBillException("Duplicate BillId");
                }
            }
        }
        public List<TaxCategory> GetCategories(string jsonfilepath)
        {
            string json = File.ReadAllText(jsonfilepath);
            JObject jsonObject = JObject.Parse(json);
            var categories = jsonObject["categories"].ToObject<List<TaxCategory>>();
            return categories;
        }

        public decimal CalculateSubTotal(Product product)
        {
            return product.Qty * product.UnitPrice;
        }

        public decimal CalculateTax(Product product, string jsonfilepath)
        {
            var categories = GetCategories(jsonfilepath);
            var category = categories.FirstOrDefault(x => x.Code==product.Category);
            if (category == null)
            {
                throw new UnknownCategoryException("Unknown Category");
            }
            decimal subtotal = CalculateSubTotal(product);
            return subtotal * category.TaxPercent / 100;
        }

        public decimal CalculateFinalAmount(Product product, string jsonfilepath)
        {
            decimal subtotal = CalculateSubTotal(product);
            decimal tax = CalculateTax(product, jsonfilepath);
            return subtotal + tax;
        }

        public void CategoryTotals(List<Product> products)
        {
            int stationeryCount = 0;
            int groceryCount = 0;
            int electronicsCount = 0;

            foreach (var product in products)
            {
                if (product.Category == "STATIONERY")
                {
                    stationeryCount++;
                }
                else if (product.Category == "GROCERY")
                {
                    groceryCount++;
                }
                else if (product.Category == "ELECTRONICS")
                {
                    electronicsCount++;
                }
            }
            Console.WriteLine($"STATIONERY products : {stationeryCount}, " + $"Grocery products : {groceryCount}, " +$"Electronics Products : {electronicsCount}");
        }
    }

    public class PosException : Exception
    {
        public PosException(string message) : base(message)
        {
        }
    }

    public class InvalidQuantityException : PosException
    {
        public InvalidQuantityException(string message) : base(message)
        {
        }
    }

    public class InvalidPriceException : PosException
    {
        public InvalidPriceException(string message) : base(message)
        {
        }
    }

    public class UnknownCategoryException : PosException
    {
        public UnknownCategoryException(string message) : base(message)
        {
        }
    }

    public class DuplicateBillException : PosException
    {
        public DuplicateBillException(string message) : base(message)
        {
        }
    }
}