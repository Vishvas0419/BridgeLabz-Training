using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Runtime.ConstrainedExecution;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _02_ControlFlow
{
    internal class Loops
    {
        //- Create a program  find the sum of all the digits of a number given by a user.
        public static void SumOfDigits()
        {
            Console.WriteLine("Enter a number to find sum of their digits: ");
            int num = int.Parse(Console.ReadLine());
            int sum = 0;
            while(num!=0)
            {
                int digit = num % 10;
                sum += digit;
                num = num / 10;
            }
            Console.WriteLine("Sum of digits is : "+ sum);
        }

        //Write a LeapYear program that takes a year as input and outputs the Year is a Leap Year or not a Leap Year.
        public static void CheckLeapYear()
        {
            Console.WriteLine("Enter a year to check whether its leap year or not : ");
            int year = int.Parse(Console.ReadLine());
            if(year < 1582)
            {
                Console.WriteLine("Not a Leap year");
            }
            else if((year % 4 == 0) && (year % 100 != 0) || (year % 400 == 0) )
            {
                Console.WriteLine("Leap year");
            }
            else
            {
                Console.WriteLine("Not a Leap Year");
            }
        }
        //Write a program to input marks and 3 subjects physics, chemistry and maths. Compute the percentage and then calculate the grade as per the following guidelines
        public static void CalculatePercentageGrade()
        {
            Console.WriteLine("Enter your Physics marks : ");
            int phy = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your Chemistry marks : ");
            int chem = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your Maths marks : ");
            int math = int.Parse(Console.ReadLine());
            double percentage = ((phy + chem + math) / 300) * 100;
            double avg = (phy + chem + math) / 100;
            char grade;
            string remarks;
            if (percentage >= 80)
            {
                grade = 'A';
                remarks = "Level 4, Above agency-normalized standards";
            }
            else if (percentage <= 79 && percentage >= 70)
            {
                grade = 'B';
                remarks = "Level 3, agency-normalized standards";
            }
            else if (percentage <= 69 && percentage >= 60)
            {
                grade = 'C';
                remarks = "Level 2, below, but approaching agency-normalized standards";
            }
            else if (percentage <= 59 && percentage >= 50)
            {
                grade = 'D';
                remarks = "Level 1, well below agency-normalized standards";
            }
            else if (percentage <= 49 && percentage >= 40)
            {
                grade = 'E';
                remarks = "Level 1-, too below agency-normalized standards";
            }
            else
            {
                grade = 'R';
                remarks = "Remedial Standards";
            }

            Console.WriteLine("Your result is below :-");
            Console.WriteLine("Average Marks : " + avg);
            Console.WriteLine("Percentage : "+ percentage+"%");
            Console.WriteLine("Remarks : "+remarks);
        }

        //Write a Program to check if the given number is a prime number or not
        public static bool isPrime()
        {
            int num = int.Parse(Console.ReadLine());
            bool isPrime = false;
            if (num <= 1) return false;
            for(int i=2;i*i <= num;i++)
            {
                if (num % i == 0) return false;
            }
            return true;
        }

       // Write a Program to find the factorial of an integer entered by the user.

        public static int Factorial(int num)
        {
            if (num == 0 || num == 1) return 1;
            return num * Factorial(num - 1);
        }
        //Write a program FizzBuzz, take a number as user input, and if it is a positive integer loop from 0 to the number and print the number, but for multiples of 3 print "Fizz" instead of the number, for multiples of 5 print "Buzz", and for multiples of both print "FizzBuzz".

        public static void FizBuzz()
        {
            int num = int.Parse(Console.ReadLine());
            for(int i=0;i<num;i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if (i%3==0)
                {
                    Console.WriteLine("Fizz");
                }
                else if(i%5==0)
                {
                    Console.WriteLine("Buzz");
                }
                else{
                    Console.WriteLine(i);
                }
            }
        }

        //Create a program to find the factors of a number taken as user input.
        public static void FindFactors(int num)
        {
            for(int i=1;i<=num; i++)
            {
                if (num % i == 0) {
                    Console.WriteLine(i);   
                }
            }
        }

        //Armstrong Number
        //153 = 1^3 + 5^3 + 3^3;
        public static bool IsArmstrong(int num)
        {
            int original = num;
            int digits = original.ToString().Length;
            int sum = 0;

            while (num > 0)
            {
                int digit = num % 10;
                sum += (int)Math.Pow(digit, digits);
                num /= 10;
            }

            return sum == original;
        }

        //Harshad Number
        public static bool IsHarshad(int num)
        {
            int originalNumber = num;
            int sum = 0;
            while(num!=0)
            {
                int digit = num % 10;
                sum += digit;
                num = num / 10;
            }
            return (sum == originalNumber);
        }

        //Abundant Number
        public static bool IsAbundant(int num)
        {

            int sum = 0;
            for (int i = 1; i <= num / 2; i++)
            {
                if (num % i == 0) sum += i;
            }
            return sum > num;
        }
    }
}
