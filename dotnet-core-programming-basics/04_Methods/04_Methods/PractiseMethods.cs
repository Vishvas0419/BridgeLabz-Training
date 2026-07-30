using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _04_Methods
{
    internal class PractiseMethods
    {
        public static void Increment(ref int value)
        {
            value++;
        }

        //Write a program Quadratic to find the roots of the equation ax2+ bx + c. Use Math functions Math.pow() and Math.sqrt()
        public static void Quadratic(int a,int b,int c)
        {
            double dis = Math.Pow(b, 2) - 4 * a * c;
            if(dis>0)
            {
                double root1 = (-b + Math.Sqrt(dis)) / (2 * a);
                double root2 = (-b - Math.Sqrt(dis)) / (2 * a);
                Console.WriteLine("Roots are real and different ");
                Console.WriteLine("Root 1 = "+ root1);
                Console.WriteLine("Root 2 = " + root2);
            }
            else if(dis==0)
            {
                double root = -b / (2*a);
                Console.WriteLine("Roots are real and same");
            }
            else
            {
                double realPart = -b / (2 * a);
                double imaginaryPart = Math.Sqrt(-dis) / (2 * a);
                Console.WriteLine("Roots are complex : ");
                Console.WriteLine("Root1 : "+ realPart + " + "+" imaginaryPart : "+ imaginaryPart + " i ");
                Console.WriteLine("Root2 : " + realPart + " - " + " imaginaryPart : " + imaginaryPart + " i ");


            }
        }


        //Write a program that generates five 4 digit random values and then finds their average value, and their minimum and maximum value. Use Math.Random(), Math.Min(), and Math.Max().

        public static int[] Generate4DigitRandomArray(int size)
        {
            int[] numbers = new int[size];
            Random random = new Random(); //math.random is not available in c# we have to create a object of random class
            for(int i=0;i<size;i++)
            {
                numbers[i] = random.Next(1000,10000);
            }
            Console.WriteLine("Generated 4 digit random Numbers : ");
            foreach (var item in numbers)
            {
                Console.WriteLine(item);
            }
            return numbers;
        }

        //level 3
        //Extend or Create a NumberChecker utility class and perform the following task.Call from the main() method the different methods and display results. Make sure all are static methods

        public static NumberChecker

        //Write a program to generate a six - digit OTP number using Math.Random() method.Validate the numbers are unique by generating the OTP number 10 times and ensuring all the 10 OTPs are not the same
        //Create a program to display a calendar for a given month and year. The program should take the month and year as input from the user and display the calendar for that month. E.g. for 07 2005 user input, the program should display the calendar as shown below
        //Write a program to find the 3 points that are collinear using the slope formulae and area of triangle formulae. check  A (2, 4), B (4, 6) and C (6, 8) are Collinear for sampling. 
        //Create a program to find the bonus of 10 employees based on their years of service as well as the total bonus amount the 10-year-old company Zara has to pay as a bonus, along with the old and new salary.
        //Write a program to perform matrix manipulation operations like addition, subtraction, multiplication, and transpose. Also finding the determinant and inverse of a matrix. The program should take random matrices as input and display the result of the operations.



    }
}
