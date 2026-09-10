using CsvHelper;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Reviews
{
    public class Product //sales.csv
    {
        public string BillId { get; set; }
        public string Item { get; set; }
        public int Qty { get; set; }
        public double UnitPrice { get; set; }
        public string Category { get; set; }
    }

    public class TaxCategory //tax_config.json
    {
        public string Code { get; set; }
        public double TaxPercent { get; set; }
    }

    public class Settlement //settlement.json
    {
      public double TotalSubtotal {  get; set; }
       public double TotalTax {  get; set; }
       public double TotalAmount {  get; set; }
       public Dictionary<string,double> CategoryTotals {  get; set; }
    }

    public class Week6
    {
        public List<Product> ReadProducts(string filepath) //reading csv file
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
                if (string.IsNullOrWhiteSpace(product.BillId) || !Regex.IsMatch(product.BillId, @"^BILL\d+$"))
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
        public List<TaxCategory> GetCategories(string jsonfilepath) //reading json file
        {
            string json = File.ReadAllText(jsonfilepath);
            JObject jsonObject = JObject.Parse(json);
            var categories = jsonObject["categories"].ToObject<List<TaxCategory>>();
            return categories;
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
      
        public double CalculateSubTotal(Product product)
        {
            return product.Qty * product.UnitPrice;
        }

        public double CalculateTax(Product product, string jsonfilepath)
        {
            var categories = GetCategories(jsonfilepath);
            var category = categories.FirstOrDefault(x => x.Code==product.Category);
            if (category == null)
            {
                throw new UnknownCategoryException("Unknown Category");
            }
            double subtotal = CalculateSubTotal(product);
            return subtotal * category.TaxPercent / 100;
        }

        public double CalculateFinalAmount(Product product, string jsonfilepath)
        {
            double subtotal = CalculateSubTotal(product);
            double tax = CalculateTax(product, jsonfilepath);
            return subtotal + tax;
        }

        public Dictionary<string, double> CategoryTotals(List<Product> products, string jsonfilepath)
        {
            Dictionary<string, double> totals = new Dictionary<string, double>();
            foreach (var product in products)
            {
                double amount = CalculateFinalAmount(product, jsonfilepath);
                if (totals.ContainsKey(product.Category))
                {
                    totals[product.Category] += amount;
                }
                else
                {
                    totals.Add(product.Category, amount);
                }
            }
            return totals;
        }

        public byte[] CreateRegisterTape(List<Product>products,string jsonfilepath) //for calculating running totals and store it in memory and return a byte array
        {
            using(MemoryStream ms = new MemoryStream())
            using(BinaryWriter writer = new BinaryWriter(ms))
            {
                double totalSubTotal = 0;
                double totalTax = 0;
                double totalAmount = 0;
                foreach(Product product in products)
                {
                    double tax = CalculateTax(product, jsonfilepath);
                    double subTotal = CalculateSubTotal(product);
                    double amount = CalculateFinalAmount(product, jsonfilepath);
                    totalTax += tax;
                    totalSubTotal += subTotal;  
                    totalAmount += amount;
                    writer.Write(totalSubTotal);
                    writer.Write(totalTax);
                    writer.Write(totalAmount);
                }
                writer.Flush();
                return ms.ToArray();
            }
        }

        public double[] ReadRegisterTape(byte[] tape) //reading the register tape and return sthe final running totals for the day
        {
            using (var ms = new MemoryStream(tape))
            using (var reader = new BinaryReader(ms))
            {
                double totalSubTotal = 0;
                double totalTax = 0;
                double totalAmount = 0;

                while (ms.Position < ms.Length) //just like (i < arr.Length)
                {
                    totalSubTotal = reader.ReadDouble(); //reads Subtotal as double
                    totalTax = reader.ReadDouble();
                    totalAmount = reader.ReadDouble();
                }

                return new double [] { totalSubTotal,totalTax,totalAmount };
            }
        }

        //settlement.json tells you how much money was generated using tap data
        public void GenerateSettlementJson(List<Product> products, string jsonfilepath, string outputFile)
        {
            byte[] tape = CreateRegisterTape(products, jsonfilepath);
            double[] totals = ReadRegisterTape(tape);
            Settlement settlement = new Settlement
            {
                TotalSubtotal = totals[0],
                TotalTax = totals[1],
                TotalAmount = totals[2],
                CategoryTotals = CategoryTotals(products, jsonfilepath)
            };
            //This converts the C# object into JSON string.
            string json = JsonConvert.SerializeObject(settlement,Formatting.Indented);
            //json is then written to, settlement.json
            File.WriteAllText(outputFile, json);
        }

        public void GenerateReceiptReport(List<Product>products, string jsonfilepath, string outputFile) //output is receipt_report.txt here
        {
            using ( var fs = new FileStream(outputFile, FileMode.Create,FileAccess.Write))
            using (var bs = new BufferedStream(fs))
            using ( var writer =  new StreamWriter(bs))
            {
                writer.WriteLine("Daily Settlement Receipt Report");
                foreach( var product in products )
                {
                    double subtotal = CalculateSubTotal(product);
                    double tax = CalculateTax(product, jsonfilepath);
                    double amount = CalculateFinalAmount(product, jsonfilepath);
                    double finalAmount = CalculateFinalAmount(product, jsonfilepath);
                    writer.WriteLine($"\nBill Id : {product.BillId}");
                    writer.WriteLine($"Item : {product.Item}");
                    writer.WriteLine($"Quantity : {product.Qty}");
                    writer.WriteLine($"Unit Price : {product.UnitPrice}");
                    writer.WriteLine($"Category : {product.Category}");
                    writer.WriteLine($"Subtotal : {subtotal}");
                    writer.WriteLine($"Tax : {tax}");
                    writer.WriteLine($"Final Amount : {finalAmount}");
                    Console.WriteLine();
                }
            }
        }

    }

    public class PosException : Exception
    {
        public PosException(string message) : base(message) { }
    }
    public class InvalidQuantityException : PosException
    {
        public InvalidQuantityException(string message) : base(message) { }
    }
    public class InvalidPriceException : PosException
    {
        public InvalidPriceException(string message) : base(message) { }
    }
    public class UnknownCategoryException : PosException
    {
        public UnknownCategoryException(string message) : base(message) { }
    }
    public class DuplicateBillException : PosException
    {
        public DuplicateBillException(string message) : base(message) { }
    }
}