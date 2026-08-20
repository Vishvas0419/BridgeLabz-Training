using System.Diagnostics;

namespace Complexity
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] counts = { 1000, 10000, 100000 };
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
            int LinearResult = Assignment.LinearSeearch(arr, target);
            sw1.Stop();

            Stopwatch sw2 = Stopwatch.StartNew();
            sw2.Start();
            int BinaryResult = Assignment.BinarySearch(arr, target);
            sw2.Stop();
            Console.WriteLine("Result of linear serach : "+ LinearResult + " Time Taken in linear Search : "+sw1.Elapsed.TotalMilliseconds);
            Console.WriteLine("Result of Binary Search : "+BinaryResult + " Time Taken in Binary Search : "+sw2.Elapsed.TotalMilliseconds);



            //2. Sorting Large Data Efficiently

            Random random2 = new Random();

            
            int[] UnsortedArray = new int[1000];
            int size = UnsortedArray.Length;
            for (int i = 0; i < n; i++)
            {
                UnsortedArray[i] = random2.Next(1, n * 10);
            }


            Stopwatch sw3 = Stopwatch.StartNew();
            sw3.Start();
            Assignment.BubbleSort(UnsortedArray);
            sw3.Stop();

            Console.WriteLine("TIme Taken in Bubble SOrt : "+sw3.Elapsed.TotalMilliseconds);


            Stopwatch sw4 = Stopwatch.StartNew();
            sw4.Start();
            Assignment.MergeSort(UnsortedArray,0, size-1);
            sw4.Stop();

            Console.WriteLine("TIme Taken in Merge SOrt : " + sw4.Elapsed.TotalMilliseconds);

            Stopwatch sw5 = Stopwatch.StartNew();
            sw5.Start();
            Assignment.QuickSort(UnsortedArray,0,size-1);
            sw5.Stop();

            Console.WriteLine("TIme Taken in Quick SOrt : " + sw5.Elapsed.TotalMilliseconds);


            //3. String Concatenation Performance

            Stopwatch sw6 = Stopwatch.StartNew();
            sw6.Start();
            Assignment.stringConcatenation(1000);
            sw6.Stop();

            Console.WriteLine("TIme Taken in string concatenation : " + sw6.Elapsed.TotalMilliseconds);

            Stopwatch sw7 = Stopwatch.StartNew();
            sw7.Start();
            Assignment.builderConcatenation(1000);
            sw7.Stop();

            Console.WriteLine("TIme Taken in stringBuilder concatenation : " + sw7.Elapsed.TotalMilliseconds);


            //4. Large File Reading Efficiency
            string path = "D:\\BridgeLabz-Training\\dotnet-DSA\\dotnet-DSA\\Complexity\\Complexity\\TextFile1.txt";
            //Assignment.CreateLargeFile(path, 100);

            //Stopwatch sw8 = Stopwatch.StartNew();
            //sw8.Start();
            //Assignment.ReadWithFileStream(path);
            //sw8.Stop();

            //Stopwatch sw9 = Stopwatch.StartNew();
            //sw9.Start();
            //Assignment.ReadWithStreamReader(path);
            //sw9.Stop();

            //Console.WriteLine("Time taken by filestream to read : "+sw8.Elapsed.TotalMilliseconds);
            //Console.WriteLine("Time taken by StreamReader to read : " + sw9.Elapsed.TotalMilliseconds);


            //5. Recursive vs Iterative Fibonacci Computation

            int num = 30;
            Stopwatch sw10 = Stopwatch.StartNew();
            sw10.Start();
            Assignment.FiboRecursive(num);
            sw10.Stop();

            Stopwatch sw11 = Stopwatch.StartNew();
            sw11.Start();
            Assignment.FiboIterative(num);
            sw11.Stop();

            Console.WriteLine("Time taken by recursive fibonacci : "+sw10.Elapsed.TotalMilliseconds);

            Console.WriteLine("Time taken by iteratice fibonacci : "+sw11.Elapsed.TotalMilliseconds);


        }
    }
}
