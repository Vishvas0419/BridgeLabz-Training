using CheckPrime;
using ClassLibrary1;
using NUnit.Framework.Legacy;
namespace TestProject1
{
    public class Tests
    {
        private Calculator calculator;
        private IsPrime checkPrime;

        [SetUp]
        public void Setup()
        {
            calculator = new Calculator();
            checkPrime = new IsPrime();
        }
        [Test]
        public void TestAddMethod()
        {
            int result = calculator.add(7, 8);
            Assert.That(result, Is.EqualTo(15));
        }

        [Test]
        public void TestPrime_WhenNumberIsPrime_ReturnsTrue()
        {
            bool result = checkPrime.CheckPrimeNumber(29);
            ClassicAssert.IsTrue(result);
        }

        [Test]
        public void TestPrime_WhenNumberIsNotPrime_ReturnsFalse()
        {
            bool result = checkPrime.CheckPrimeNumber(28);
            ClassicAssert.IsFalse(result);
        }


    }
}
