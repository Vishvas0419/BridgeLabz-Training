using System;
using System.Collections.Generic;
using System.Text;

namespace _02_ControlFlow
{
    internal class Switch
    {
        //calculator
        public static void Calculator()
        {
            Console.WriteLine("Enter two numbers : ");
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            Console.WriteLine("Select operator to perform calculation : ");
            Console.WriteLine("1 -> +");
            Console.WriteLine("2 -> -");
            Console.WriteLine("3 -> *");
            Console.WriteLine("4 -> /");
            Console.WriteLine("5 -> %");
            Console.WriteLine("6 -> ^");

            int op = int.Parse(Console.ReadLine());
            switch(op)
            {
                case 1:
                    Console.WriteLine("Result : " + (num1 + num2));
                    break;
                case 2:
                    Console.WriteLine("Result : " + (num1 - num2));
                    break;
                case 3:
                    Console.WriteLine("Result : " + (num1 * num2));
                    break;
                case 4:
                    Console.WriteLine("Result : " + (num1 / num2));
                    break;
                case 5:
                    Console.WriteLine("Result : " + (num1 % num2));
                    break;
                case 6:
                    Console.WriteLine("Result : " + Math.Pow(num1, num2));
                    break;
            }
        }
    }
}
