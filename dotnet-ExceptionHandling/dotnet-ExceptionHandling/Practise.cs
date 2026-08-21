using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace ExceptionHandling
{
    internal static class Practise
    {
        public static void DivideByZero()
        {
            try
            {
                Console.WriteLine("A");

                int a = 10; int b = 0;
                int x = a/b;

                Console.WriteLine("B"); //C# immediately stops executing the remaining statements inside the try when Exception occurs
            }
            catch (DivideByZeroException e) //e is a Object of class Exception
            {
                Console.WriteLine("C");
                //Console.WriteLine(ex.Message);
                Console.WriteLine(e.StackTrace); //tells where exception occurs
                //Console.WriteLine(e.ToString);

            }
            catch(IndexOutOfRangeException) //without obj if you dont want any info about the catched exception 
            {
                Console.WriteLine("Index out of bound please check your indices");
            }

            Console.WriteLine("D"); //after handling the exception the program flow continue after try catch block
        }


        //exception propagation in nested method
        static void MethodA()
        {
            MethodB();
        }
        static void MethodB()
        {
            MethodC();
        }
        static void MethodC()
        {
            int a = 10; int b = 0;
            int x = a / b;
        }

        public static void CheckAge(int age)
        {
            if (age < 18) throw new ArgumentException("You are not eligible to vote yet.... your age must greater than 18 !");
            else Console.WriteLine("Age is valid to vote");
        }
    }


    
}
