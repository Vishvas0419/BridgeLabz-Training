using NUnit.Framework;
using NUnit.Framework.Internal;
using Reviews;
using System.Collections.Generic;

namespace TestProjectReview
{
    internal class Week6Tests
    {
        Week6 week6;
        Product product;

        [SetUp]
        public void Setup()
        {
            week6 = new Week6();

            product = new Product
            {
                BillId = "BILL1",
                Item = "Notebook",
                Qty = 5,
                UnitPrice = 40,
                Category = "STATIONERY"
            };
        }

        [Test]
        public void CorrectSubtotal()
        {
            double result = week6.CalculateSubTotal(product);

            Assert.That(result, Is.EqualTo(200));
        }

        [Test]
        public void CorrectTaxCalculation()
        {
            double result = week6.CalculateTax(product, "tax_config.json");

            Assert.That(result, Is.EqualTo(10));
        }

        [Test]
        public void CorrectFinalAmount()
        {
            double result = week6.CalculateFinalAmount(product, "tax_config.json");

            Assert.That(result, Is.EqualTo(210));
        }

        [Test]
        public void ZeroQuantity()
        {
            var products = new List<Product>
            {
                new Product
                {
                    BillId = "BILL1",
                    Qty = 0,
                    UnitPrice = 40,
                    Category = "STATIONERY"
                }
            };

            Assert.Throws<InvalidQuantityException>(() => week6.ValidateQuantity(products));
        }

        [Test]
        public void NegativeQuantity()
        {
            var products = new List<Product>
            {
                new Product
                {
                    BillId = "BILL1",
                    Qty = -5,
                    UnitPrice = 40,
                    Category = "STATIONERY"
                }
            };

            Assert.Throws<InvalidQuantityException>(() => week6.ValidateQuantity(products));
        }

        [Test]
        public void ZeroPrice()
        {
            var products = new List<Product>
            {
                new Product
                {
                    BillId = "BILL1",
                    Qty = 5,
                    UnitPrice = 0,
                    Category = "STATIONERY"
                }
            };

            Assert.Throws<InvalidPriceException>(() => week6.ValidatePrice(products));
        }

        [Test]
        public void NegativePrice()
        {
            var products = new List<Product>
            {
                new Product
                {
                    BillId = "BILL1",
                    Qty = 5,
                    UnitPrice = -40,
                    Category = "STATIONERY"
                }
            };

            Assert.Throws<InvalidPriceException>(() => week6.ValidatePrice(products));
        }

        [Test]
        public void UnknownCategory()
        {
            var products = new List<Product>
            {
                new Product
                {
                    BillId = "BILL1",
                    Qty = 5,
                    UnitPrice = 40,
                    Category = "CLOTHES"
                }
            };

            Assert.Throws<UnknownCategoryException>(() => week6.ValidateCategory(products, "tax_config.json"));
        }
    }
}