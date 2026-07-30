using Microsoft.VisualBasic;
using System.Drawing;
using System.Reflection.Metadata;
using System.Security.Principal;
using System.Timers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _04_PractiseProblems
{
    internal class Program
    {
        static void Main(string[] args)
        {


            //1.Welcome to Bridgelabz!
            //Write a program that prints "Welcome to Bridgelabz!" to the screen.
            Console.WriteLine("Welcome to Bridgelabz!");

            //2.Add Two Numbers
            //Write a program that takes two numbers as input from the user and prints
            //their sum.

            Console.WriteLine("Enter two Numbers to print their sum :");
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Sum : " + (num1+num2));

            //3.Celsius to Fahrenheit Conversion
            //Write a program that takes the temperature in Celsius as input and converts
            //it to Fahrenheit using the formula:
            //Fahrenheit = (Celsius * 9 / 5) + 32.

            Console.WriteLine("Enter temp in celsius to convert it into fahrenheit : ");
            int temp = int.Parse(Console.ReadLine());
            int fahrenheit = (temp * 9 / 5) + 32;
            Console.WriteLine("Temperature in fahrenheit : "+ fahrenheit);

            //4.Area of a Circle
            //Write a program to calculate the area of a circle.Take the radius as input
            //and use the formula:
            //Area = π * radius ^ 2.

            Console.WriteLine("Enter radius to find area of circle : ");
            int radius = int.Parse(Console.ReadLine());
            double area = Math.PI * radius * radius;
            Console.WriteLine("Area of circle : " + area);

            //5.Volume of a Cylinder
            //Write a program to calculate the volume of a cylinder.Take the radius and
            //height as inputs and use the formula:
            //Volume = π * radius ^ 2 * height.

            Console.WriteLine("Enter radius and height to find Volume of cylinder : ");
            int r = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            Console.WriteLine("Volume of Cylinder : "+ Math.PI * r * r * height);


            //Self Problems
            //1.Calculate Simple Interest
            //Write a program to calculate simple interest using the formula:
            //Simple Interest = (Principal * Rate * Time) / 100.
            //Take Principal, Rate, and Time as inputs from the user.

            Console.WriteLine("Enter Principal, Rate, and Time to find Simple Interest : ");
            int principal = int.Parse(Console.ReadLine());
            int rate = int.Parse(Console.ReadLine());
            int time = int.Parse(Console.ReadLine());
            int simpleInterest = (principal * rate * time) / 100;
            Console.WriteLine("Simple Interest : " + simpleInterest);

            //2.Perimeter of a Rectangle
            //Write a program to calculate the perimeter of a rectangle.Take the length
            //and width as inputs and use the formula:
            //Perimeter = 2 * (length + width).

            Console.WriteLine("Enter length and width to find the perimter of rectangle : ");
            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            double perimeter = 2 * (length +  width);

            Console.WriteLine("Perimeter of Rectangle : "+ perimeter);

            Console.WriteLine("Enter base and exp to find the power : ");
            //3.Power Calculation
            //Write a program that takes two numbers as input: a base and an exponent,
            //and prints the result of base raised to the exponent(without using loops or
            //conditionals).

            int baseNum = int.Parse(Console.ReadLine());
            int exponent = int.Parse(Console.ReadLine());

            Console.WriteLine("Result : "+ Math.Pow(baseNum,exponent));

            Console.WriteLine("Enter three numbers to find their avg : ");
            //4.Calculate Average of Three Numbers
            //Write a program that takes three numbers as input from the user and prints
            //their average.

            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int avg = (a + b + c) / 3;
            Console.WriteLine("Average : " + avg);

            //5.Convert Kilometers to Miles
            //Write a program that takes the distance in kilometers as input from the user
            //and converts it into miles using the formula:
            //Miles = Kilometers * 0.621371.

            Console.WriteLine("Enter km to change it into miles : ");
            int km = int.Parse(Console.ReadLine());
            double miles = km * 0.621371;
            Console.WriteLine("Miles : "+miles);

        }
    }
}
