using System.Diagnostics;

namespace Complexity
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw1 = Stopwatch.StartNew();
            Random random = new Random();

            int n = 1000;
            int[] arr = new int[n];
            int target = arr[n - 1];
            //int n = 1000000;
            for(int i=0;i<n;i++)
            {
                arr[i] = random.Next(1, n * 10);
            }
            Array.Sort(arr);
            sw1.Start();
            int LinearResult = Class1.LinearSeearch(arr, target);
            sw1.Stop();

            Stopwatch sw2 = Stopwatch.StartNew();
            sw2.Start();
            int BinaryResult = Class1.BinarySearch(arr, target);
            sw2.Stop();
            Console.WriteLine("Result of linear serach : "+ LinearResult + " Time Taken in linear Search : "+sw1.Elapsed.TotalMilliseconds);
            Console.WriteLine("Result of Binary Search : "+BinaryResult + " Time Taken in Binary Search : "+sw2.Elapsed.TotalMilliseconds);
        }
    }
}
