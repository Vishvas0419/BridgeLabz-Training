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
            if (age < 18) throw new ArgumentException("You are not eligible to vote yet.... your age must be greater than 18 !");
            else Console.WriteLine("Age is valid to vote");
        }




        //========================================

        public static void SomeMethod()
        {
            Console.WriteLine("Start of some method");
            int a = 10;
            int b = 0;
            int x = a / b; //exception occur here execution stops here for function someMethod()

            Console.WriteLine("End of SomeMethod()"); //compiler never reaches here because before that an excepption occurs the method stops its execeution and starts searching a catch vlock to catch handle the exception
        }

        public static void MiddleLayer()
        {
            Console.WriteLine("middle start");
            try
            {
                SomeMethod();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Logging exception: " + ex.Message);
                throw; //Control now leaves MiddleLayer entirely here, searching for the next matching catch block up the call stack

                //if we dont use throw here then the top layer catch block will not be executed because for topLayer the middlelayer have no exceptions because it was handled witht the catch block in middleLayer.  so to tell topLayer that middleLayer had an exception in it we use throw keyword in a method and so that topLayer can perform actions accordingly 
            }
            Console.WriteLine("middle end"); //due to throw keyword above, the execution never reaches here
        }

        public static void TopLayer()
        {
            Console.WriteLine("top start");
            try
            {
                MiddleLayer();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Handled at top layer: " + ex.Message);
            }
            Console.WriteLine("top end");
        }


        //custom exceptions in c#

        internal class CustomException : Exception
        {
            public CustomException(string message) : base(message) { }
        }


        public static void ValidateAge(int age)
        {
            try
            {
                if (age < 18) throw new CustomException("Age must be greater than 18");
                Console.WriteLine("Access granted ");
            }
            catch(CustomException customexception)
            {
                Console.WriteLine(customexception.Message);
            }
        }

        //public static void 

        







    }
}
