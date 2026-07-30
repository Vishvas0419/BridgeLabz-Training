using System.Drawing;

namespace _02_ControlFlow
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //Switch.Calculator();
            //Loops.SumOfDigits();
            //Loops.CheckLeapYear();
            //Loops.CalculatePercentageGrade();

            //if(Loops.isPrime()) Console.WriteLine("Prime Number");
            //else Console.WriteLine("Not a Prime Number");

            //Console.WriteLine(Loops.isPrime());

            //Write a Program to find the factorial of an integer entered by the user.
            //Console.WriteLine("Enter a number to find its factorial : ");
            //int num = int.Parse(Console.ReadLine());
            //Console.WriteLine("Factorial : "+ Loops.Factorial(num));

            //Write a program FizzBuzz, take a number as user input, and if it is a positive integer loop from 0 to the number and print the number, but for multiples of 3 print "Fizz" instead of the number, for multiples of 5 print "Buzz", and for multiples of both print "FizzBuzz".
            Loops.FizBuzz();

            //Create a program to find the factors of a number taken as user input.
            //Console.WriteLine("Enter a number to find the factors of a number : ");
            //int n = int.Parse(Console.ReadLine());
            //Loops.FindFactors(n);

            //Console.WriteLine("Enter a number to check if the number is Armstrong or not : ");
            //int num = int.Parse(Console.ReadLine());
            //if(Loops.IsArmstrong(num))
            //{
            //    Console.WriteLine("Is Armstrong");
            //}
            //else
            //{
            //    Console.WriteLine("Not Armstrong");
            //}


            Console.WriteLine("Enter a number to check if the number is Harshad or not : ");
            int num2 = int.Parse(Console.ReadLine());
            if (Loops.IsHarshad(num2))
            {
                Console.WriteLine("Is Harshad");
            }
            else
            {
                Console.WriteLine("Not Harshad");
            }

            Console.WriteLine("Enter a number to check if the number is Abundant or not : ");
            int num3 = int.Parse(Console.ReadLine());
            if (Loops.IsAbundant(num3))
            {
                Console.WriteLine("Is Abundant");
            }
            else
            {
                Console.WriteLine("Not Abundant");
            }



        }
    }
}
