using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
namespace Complexity
{
    internal static class Assignment
    {

        public static int LinearSeearch(int[]arr,int target)
        {
            int n = arr.Length;
            for(int i=0;i<n;i++)
            {
                if (arr[i] == target)
                {
                    return i;
                }
            }
            return -1;
        }
        //1 2 3 3 4 5 6 6 6 7 7 7 8 8 9 9 
        public static int BinarySearch(int[]arr,int target)
        {
            int n = arr.Length;
            int low = 0;
            int high = n - 1;
            while(low <= high)
            {
                int mid = low + (high - low) / 2;
                if (arr[mid] == target)
                {
                    return mid;
                }
                else if (arr[mid] > target)
                {
                    high = mid - 1;
                }
                else low = mid + 1;
            }
            return -1;
        }

        public static void BubbleSort(int[] arr) //adj elements are swapped
        {
            int n = arr.Length;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        public static void MergeSort(int[] arr, int low, int high)
        {
            // Base case
            if (low >= high)
                return;

            int mid = low + (high - low) / 2;

            MergeSort(arr, low, mid);
            MergeSort(arr, mid + 1, high);

            Merge(arr, low, mid, high);
        }

        private static void Merge(int[] arr, int low, int mid, int high)
        {
            int[] temp = new int[high - low + 1];

            int left = low;
            int right = mid + 1;
            int i = 0;

            while (left <= mid && right <= high)
            {
                if (arr[left] <= arr[right])
                {
                    temp[i++] = arr[left++];
                }
                else
                {
                    temp[i++] = arr[right++];
                }
            }

            while (left <= mid)
            {
                temp[i++] = arr[left++];
            }

            while (right <= high)
            {
                temp[i++] = arr[right++];
            }

            // Copy back into original array
            for (int j = 0; j < temp.Length; j++)
            {
                arr[low + j] = temp[j];
            }
        }



        public static void QuickSort(int[] prices, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(prices, low, high);

                QuickSort(prices, low, pivotIndex - 1);

                QuickSort(prices, pivotIndex + 1, high);
            }
        }

        public static int Partition(int[] prices, int low, int high)
        {
            int pivotIndex = low + (high - low) / 2;
            int pivot = prices[pivotIndex];       // <-- FIX: get the VALUE at that index

            // move pivot to the end so it doesn't get disturbed
            int tempPivot = prices[pivotIndex];
            prices[pivotIndex] = prices[high];
            prices[high] = tempPivot;

            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (prices[j] < pivot)
                {
                    i++;

                    int temp = prices[i];
                    prices[i] = prices[j];
                    prices[j] = temp;
                }
            }

            int temp2 = prices[i + 1];
            prices[i + 1] = prices[high];
            prices[high] = temp2;

            return i + 1;
        }


        public static void stringConcatenation(int n)
        {
            string result = "";
            for(int i=0;i<n;i++)
            {
                result += "a";
            }
        }

        public static void builderConcatenation(int count)
        {
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < count; i++)
            {
                sb = sb.Append("a");
            }
            sb.ToString();
        }



        public static void CreateLargeFile(string path,int sizeInMb)
        {
            StringBuilder line = new StringBuilder();
            for(int i=0;i<100;i++)
            {
                line.Append("hello my name is vishvas");
            }

            int lineNeeded = (sizeInMb*1024*1024)/line.Length;
            using (StreamWriter writer = new StreamWriter(path))
            {
                for (int i = 0; i < lineNeeded; i++)
                {
                    writer.WriteLine(line.ToString());
                }
            }

        }

        public static void ReadWithStreamReader(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while((line = reader.ReadLine()) != null)
                {

                }
            }
        }

        public static void ReadWithFileStream(string path)
        {
            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                byte[] buffer = new byte[8192];
                int bytesRead;
                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                }
            }
        }


        //5. Recursive vs Iterative Fibonacci Computation

        public static int FiboRecursive(int num)
        {
            if (num <= 1) return num;
            return FiboRecursive(num-1) * FiboRecursive(num-2);
        }

        public static int FiboIterative(int num)
        {
            if (num <= 1) return num;
            int a = 0;int b = 1;int c;
            for(int i=2;i<num;i++)
            {
                c = a + b;
                a = b;
                b = c;
            }
            return b;
        }
    }
}
