using System;
using System.Collections.Generic;
using System.Text;
using static ExceptionHandling.Practise;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ExceptionHandling
{
    internal class Assignment
    {
        //1. Handling File Not Found Exception
        public static void ReadFile()
        {
            try
            {
                string content = File.ReadAllText("data.txt"); //data.txt is not here so will give exception
                Console.WriteLine(content);
            }
            catch (IOException e)
            {
                Console.WriteLine("File not found : "+e.Message);
            }
        }

        //2. Handling Division and Input Errors
        public static void handleDivide()
        {
            try
            {
                Console.WriteLine("Enter two numbers : ");
                int num1 = int.Parse(Console.ReadLine());
                int num2 = int.Parse(Console.ReadLine());
                int x = num1 / num2;
                Console.WriteLine("Result : "+num1 / num2);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Operation completed");
            }
        }


        //3. Creating and Handling a Custom Exception
        public class InvalidAgeException : Exception
        {
            public InvalidAgeException(string message) : base(message) { }
        }

        public static void ValidateAge()
        {
            try
            {
                int age = int.Parse(Console.ReadLine());
                if (age < 18) throw new InvalidAgeException("Age must be 18 or above");
                Console.WriteLine("Access granted ");
            }
            catch (InvalidAgeException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //4. Handling Multiple Exceptions
        public static void HandlingMultipleExceptions()
        {
            try
            {
                Console.WriteLine("Array size : ");
                int n = int.Parse(Console.ReadLine());
                int[] arr = new int[n];
                Console.WriteLine("Input array : ");
                for(int i=0;i<n;i++)
                {
                    arr[i] = int.Parse(Console.ReadLine());
                }
                Console.WriteLine("Enter index number : ");
                int index = int.Parse(Console.ReadLine());

                for(int i=0;i<n;i++)
                {
                    if(i==index) Console.WriteLine($"Value at index {i}: {arr[i]}");
                }

            } 
            catch(IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
        }


        //5. Using using Statement for File Handling

        public static void UsingStatement()
        {
            try
            {
                using(StreamReader reader = new StreamReader("data.txt"))
                {
                    string firstLine = reader.ReadLine();
                    //string content = reader.ReadToEnd();
                    Console.WriteLine(firstLine);
                    //Console.WriteLine(content);
                }
            }
            catch(IOException e)
            {
                Console.WriteLine("Error reading file");
            }


        }



        //6. Handling Invalid Input in Interest Calculation
        public static void RunCalculateInterest()
        {
            try
            {
                Console.WriteLine("Enter amount : ");
                double amount = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter rate : ");
                double rate = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter year : ");
                int years = int.Parse(Console.ReadLine());

                Console.WriteLine(CalculateInterest(amount, rate, years));
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public static double CalculateInterest(double amount, double rate, int years)
        {
            if (amount < 0 || rate < 0 || years<0) throw new ArgumentException("Invalid input: Amount, rate or year must be positive");
            return (amount * rate * years) / 100;
        }

        //7. Demonstrating finally Block Execution
        //same as problem 2 above (added finally block their)



        //8. Propagating Exceptions Across Methods

        public static void Method1()
        {
            try
            {
                int a = 10;
                int b = 0;
                int x = a / b;
            }
            catch(ArithmeticException e)
            {
                Console.WriteLine(e.Message);
                throw; 
            }
        }

        public static void Method2()
        {
            Method1();
        }

        public static void PropagatingExceptions()
        {
            try
            {
                Method2();
            }
            catch(ArithmeticException e)
            {
                Console.WriteLine("Handled exception in Main");
            }
        }

        //9. Using Nested try-catch Blocks
        public static void NestedTryCatch()
        {
            try
            {
                Console.WriteLine("Enter array size : ");
                int n = int.Parse(Console.ReadLine());
                int[] arr = new int[n];
                Console.WriteLine("input array : ");
                for(int i=0;i<n;i++)
                {
                    arr[i] = int.Parse(Console.ReadLine());
                }
                Console.WriteLine("divisor : ");
                int divisor = int.Parse(Console.ReadLine());
                Console.WriteLine("Index : ");
                int index = int.Parse(Console.ReadLine());

                int value = arr[index];

                try
                {
                    int result = value / divisor;

                    Console.WriteLine("Division Result : "+result);
                }
                catch(DivideByZeroException)
                {
                    Console.WriteLine("Cannot divide by zero!");
                }
            }
            catch(IndexOutOfRangeException)
            {
                Console.WriteLine("Invalid array index!");
            }

        }

        //10. Implementing a Bank Transaction System
        public static void BankTransactionSystem()
        {
            BankAccount acc = new BankAccount(1000);
            try
            {
                acc.Withdraw(100);
                acc.Withdraw(2000);
                acc.Withdraw(-2000);
            }
            catch(InsufficientFundsException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}

