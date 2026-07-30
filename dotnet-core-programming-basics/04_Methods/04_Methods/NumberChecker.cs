using System;
using System.Collections.Generic;
using System.Text;

namespace _04_Methods
{
    internal class NumberChecker
    {
        // Method to Find the count of digits in the number
        public static int CountDigits(int num)
        {
            int count = 0;
            while (num != 0)
            {
                int digit = num % 10;
                count++;
                num = num / 10;
            }
            return count;
        }
        //Method to Store the digits of the number in a digits array

        public static int[] StoreDigits(int num)
        {
            int[] digits = new int[num.ToString().Length];
            int i = 0;
            while(num!=0)
            {
                int digit = num % 10;
                digits[i++] = digit;
                num = num / 10;
            }
            return digits;
        }

        //Method to Check if a number is a duck number using the digits array. A duck number is a number that has a non-zero digit present in it

        public static bool IsDuckNumber(int num)
        {

        }

        // Method to check if the number is an armstrong number using the digits array. ​​Armstrong number is a number that is equal to the sum of its own digits raised to the power of the number of digits. Eg: 153 = 1^3 + 5^3 + 3^3

        //  Method to find the largest and second largest elements in the digits array. Use Int32.MinValue to initialize the variable.

        //  Method to find the smallest and second smallest elements in the digits array. Use Int32.MaxValue to initialize the variable

    }
}
