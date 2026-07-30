namespace _04_Methods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int a = 0;
            //PractiseMethods.Increment(ref a);
            //Console.WriteLine(a);

            //Quadratic : find roots
            //Console.WriteLine("Finding the quadratic roots : ");
            //Console.WriteLine("Enter values of a , b , c : ");
            //int a = int.Parse(Console.ReadLine());
            //int b = int.Parse(Console.ReadLine());
            //int c = int.Parse(Console.ReadLine());

            //PractiseMethods.Quadratic(a,b,c);

            //Console.WriteLine("Program : generate 4 digit numbers : ");
            //Console.WriteLine("Enter a size of array : ");
            //int size = int.Parse(Console.ReadLine());
            //int[]numbers = PractiseMethods.Generate4DigitRandomArray(size);
            //foreach (var item in numbers)
            //{
            //    Console.WriteLine(item);
            //}

            Console.WriteLine("---------Number Checker Program-----");

            Console.WriteLine("Enter a number : ");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine("counting its digits : ");
            NumberChecker.CountDigits(num);

            Console.WriteLine("storing its digits : ");
            NumberChecker.StoreDigits(num);

            Console.WriteLine("checking duck number : ");





        }
    }
}
