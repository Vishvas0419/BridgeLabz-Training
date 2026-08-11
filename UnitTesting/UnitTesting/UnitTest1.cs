using ClassLibrary1;

namespace UnitTesting
{
    [TestFixture] //to tell N unit to treat it as a class containing tests
    public class Tests
    {
        public Calculator calculator;

        [SetUp]
        //[OneTimeSetUp] // runs once before entering test fixture for eg to 
        public void Setup() // SetUp() runs before every test case, ensuring a fresh Calculator instance.   
        {
            calculator = new Calculator();
        }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            Console.WriteLine("I am Inside the OneTimeSetup ");
        }

        [Test]
        public void TestAddMethod()
        {
            int result = calculator.Add(2, 3);

            Assert.That(result, Is.EqualTo(5));
        }


        [TestCase(3,3,0)]
        //[TestCase(44,4,5)] // Runs the test three times with different inputs.
        public void TestSubtractMethod(int a, int b,int expected) //these params should match the (Testcase params)
        {
            //int result = calculator.Subtract();

            Assert.That(expected, Is.EqualTo(calculator.Subtract(a,b)));
        }

        [TearDown] //runs after each test

        public void TearDownMethod()  // TearDown() runs after each test case to clean up resources
        {
            Console.WriteLine("Hello i am Tear Down Method which runs after each test");
        }


        [TestCase(5,5,25)]
        public void TestMultiplyMethod(int a,int b,int expected)
        {
            Assert.That(expected, Is.EqualTo(calculator.Multiply(a, b)));
        }

        [Test]
        [Ignore("Feature not implemented yet")]
        public void FeatureNotReadyYet()
        {
            Console.WriteLine("Working upon on the feature....");
        }

        [TestCase(10,2,5)] //(expected,a,b)
        [Timeout(1000)] //to test if the test is done within and to check if the test is not unneccedarily taing longer 
        public void TestDivideMethod(int a,int b,int expected)
        {
            Assert.That(expected,Is.EqualTo(calculator.Divide(a,b)));
        }
    }
}
