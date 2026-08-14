using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Sorting
{
    internal static class Assignment
    {
        public static void BubbleSort(int[]arr) //adj elements are swapped
        {
            int n = arr.Length;
            for(int i=0;i<n;i++)
            {
                for(int j=0;j<n-1;j++)
                {
                    if (arr[j] > arr[j+1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        public static void InsertionSort(int[]arr) //Take one element at a time and insert it into its correct position in the already-sorted portion.
        {
            int n = arr.Length;
            for(int i=1;i<n;i++)
            {
                int j = i;
                while(j>0 && arr[j] < arr[j-1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j - 1];
                    arr[j - 1] = temp;
                    j--;
                }
            }
        }

        public static void SelectionSort(int[]arr)
        {
            int n=arr.Length;
            for(int i=0;i<n;i++)
            {
                int minIndex = i;
                for(int j=i+1;j<n;j++)
                {
                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                    }
                }

                int temp = arr[minIndex];
                arr[minIndex] = arr[i];
                arr[i] = temp;
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
            int pivot = prices[high];

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

    }
}
