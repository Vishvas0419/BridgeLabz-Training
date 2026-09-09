using Reviews;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace TestProjectReview
{
    internal class Week6Tests
    {
        Week6 week6 = new Week6();
        [Test]
        public void CorrectSubtotal()
        {
            Product product = new Product
            {
                BillId = "BILL1",
                Item = "Notebook",
                Qty = 5,
                UnitPrice = 40,
                Category = "STATIONERY"
            };
            decimal result = week6.CalculateSubTotal(product);
            Assert.That(result, Is.EqualTo(200));
        }

        [Test]
        public void CorrectTaxCalculation()
        {
            //Product product = new Product
            //{
            //    BillId = 
            //}
        }

    }
}
