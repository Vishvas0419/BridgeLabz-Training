using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Program_codes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //if-else
            //Check if a number is positive, negative, or zero
            int n = int.Parse(Console.ReadLine());
            if(n>0)
            {
                Console.WriteLine("The number is positive.");
            }
            else if(n<1)
            {
                Console.WriteLine("The number is negative.");
            }
            else
            {
                Console.WriteLine("Number is zero");
            }   
            //Check if a person is eligible to vote(age >= 18)
            int age = Convert.ToInt32(Console.ReadLine());
            if (age >= 18 && age < 100) Console.WriteLine("The person is eligible to vote");
            else if (age < 18) Console.WriteLine("The person is not eligible to vote");
            else Console.WriteLine("please enter a valid age");
            //Find the largest of three numbers using nested if-else
            Console.WriteLine("Enter three numbers to find greatest among three them: ");
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());
            if(num1>num2)
            {
                if(num1>num3)
                {
                    Console.WriteLine(num1 + " is greatest");
                }
                else
                {
                    Console.WriteLine(num3 + " is greatest");
                }
            }
            else
            {
                if(num2>num3)
                {
                    Console.WriteLine(num2+" is greatest");
                }
                else
                {
                    Console.WriteLine(num3+" is greatest");
                }
            }
        }
    }
}
