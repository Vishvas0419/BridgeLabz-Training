using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
namespace Complexity
{
    internal static class Class1
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
        //1 2 3 3 4 5 6 6 6 7 7 7 8 8  9 9 
        public static int BinarySearch(int[]arr,int target)
        {
            int n = arr.Length;
            int low = 0;
            int high = n - 1;
            while(low < high)
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
    }
}
