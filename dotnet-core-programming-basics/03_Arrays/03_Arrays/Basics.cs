using System;
using System.Collections.Generic;
using System.Text;
//using System.Collections.String;

namespace _03_Arrays
{
    internal class Basics
    {
        public static void BasicsOfArray()
        {
            //Basics of array in c#

            //declaring a array
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] arr3 = new int[4]; //{0,0,0,0}
            int[] arr4 = { 1, 2, 3, 4, 5 };
            int[] arr5 = new int[5];
            arr5[0] = 12;
            arr5[4] = 45;
            //for (int i = 0; i < arr5.Length; i++)
            //{
            //    Console.Write(arr5[i]+" "); 
            //}

            //var arr5 = { 12, 2, 3, 4, 4 };//var cant find the type if directly created array using curly brackets

            //foreach (int num in arr)
            //{
            //    Console.WriteLine(num);
            //}

            //Console.WriteLine(arr);
            //Console.WriteLine(object.ReferenceEquals(arr3,arr));

            //Console.WriteLine(arr.GetType());

            //Console.WriteLine(arr is int[]); //true
            //Console.WriteLine(arr is object); //true


            //int [] arr2;

            var list = new List<int>();
            list.Add(1);
            //foreach (int item in list)
            //{
            //    Console.WriteLine(item);
            //}

            //reference behaviour

            int[] a = { 1, 2, 3, };
            int[] b = a; //both a and b now points to the same heap memory
            b[0] = 90;
            //Console.WriteLine(a[0]);

            int[] c = { 1, 2, 3, };
            int[] d = new int[3] { 90, 100, 200 };
            c = d; //the array d is now pointing to c array and the elements of d is now not pointing to anyone, eleigible for garbage collection
            d[0] = 200;
            //Console.WriteLine(c[1]);
            //Console.WriteLine(d[1]);

            int[] age = { 24, 23, 18, 19, 20 };
            age[0] = 25; // simply assigning a new value
            age[1] = age[1] + 1; // Accessing the element and increment by 1
            age[2]++; // Accessing the element and using the increment operator

            //Console.WriteLine(age[1]+" " + age[2]);

            //Console.WriteLine("Sorting");
            int[] arr6 = { 23, 45, 22, 100, 35, 1, 3, 5, 5, 2, 3, 5 };
            Array.Sort(arr);

            //foreach (var item in arr6)
            //{
            //    Console.WriteLine(item);
            //}

            //2d arrays
            int[,] twoDArray = new int[2, 3];
            for (int i = 0; i < twoDArray.Length; i++)
            {
                for (int j = 0; j < twoDArray.Length; j++)
                {

                }
            }
        }
        
    }
}
