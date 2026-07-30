using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace _03_Arrays
{
    internal class PractiseProblems
    {
        //Write a program to store multiple values in an array up to a maximum of 10 or until the user enters a 0 or a negative number. Show all the numbers as well as the sum of all numbers 
        public static void StoreMultipleValues()
        {
            int[] numbers = new int[10];
            int count = 0;
            int sum = 0;
            Console.WriteLine("Enter numbers (up to 10). Enter 0 or a negative number to stop:");

            int i = 0;
            while (i < 10)
            {
                Console.Write("Enter number " + (i + 1) + ": ");
                int value = int.Parse(Console.ReadLine());
                if (value <= 0) break;
                numbers[i] = value;
                count++;
                sum += value;
                i++;
            }

            Console.WriteLine("\nNumbers entered:");
            int j = 0;
            while (j < count)
            {
                Console.WriteLine(numbers[j]);
                j++;
            }

            Console.WriteLine("\nSum of all numbers: " + sum);
        }

        //Working with Multi-Dimensional Arrays. Write a C# program to create a 2D Array and Copy the 2D Array into a single dimension array
        public static void TwoDArray()
        {
            Console.WriteLine("Enter 2d matrix row and col sizes : ");
            int row = int.Parse(Console.ReadLine());
            int col = int.Parse(Console.ReadLine());
            int[,] matrix = new int[row, col];

            Console.WriteLine("Enter your 2d array elements according to array size to declared : ");
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }
            int[] array = new int[row * col];
            int k = 0;
            for(int i=0;i<row;i++)
            {
                for(int j=0;j<col;j++)
                {
                    array[k++] = matrix[i, j];
                }
            }
            Console.WriteLine("Converted Array into 1d array : ");
            for(int i=0;i<k;i++)
            {
                Console.WriteLine(array[i]);
            }
            //foreach (var item in array)
            //{
            //    Console.WriteLine("Converted 1d Array : " + item);

            //}


        }

        public static void FindYoungestAndTallest()
        {
            string[] names = { "Amar", "Akhbar", "Anthony" }; 
            int[] age = new int[3];
            int[] height = new int[3];
            for (int i = 0; i < age.Length; i++)
            {
                Console.WriteLine($"Enter {names[i]}'s Age and height : ");
                age[i] = int.Parse(Console.ReadLine());
                height[i] = int.Parse(Console.ReadLine());
            }
            int youngestIndex = 0; int tallestIndex = 0;
            for (int i=0;i<age.Length;i++)
            {
                if(age[i] < age[youngestIndex])
                {
                    youngestIndex = i;
                }
                if (height[i] > height[tallestIndex])
                {
                    tallestIndex = i;
                }
            }
            Console.WriteLine($"Among Amar, Abhkar, Anthony : \n youngest is : {names[youngestIndex]} and tallest is {names[tallestIndex]}");
        }
        //Create a program to take a number as input and reverse the number. To do this, store the digits of the number in an array and display the array in reverse order

        public static void ReverseNumber()
        {
            Console.WriteLine("Enter a number to reverse it : ");
            int num = int.Parse(Console.ReadLine());
            int[] numArray = new int[num.ToString().Length];
            int i = 0;
            while(num!=0)
            {
                int digit = num % 10;
                numArray[i++] = digit;
                num = num / 10;
            }
            //int j = 0, k = numArray.Length-1;
            //while(j<k)
            //{
            //    int temp = numArray[j];
            //    numArray[j] = numArray[k];
            //    numArray[k] = temp;
            //    j++;k--;
            //}
            foreach (var item in numArray)
            {
                Console.Write(item);
            }

        }
    }
}