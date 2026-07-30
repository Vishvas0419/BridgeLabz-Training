using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _05_Strings
{
    internal class PractiseProblems
    {
        //Write a C# program to count the number of vowels and consonants in a given string.
        public static void CountVowelConsonants(string str)
        {
            string vowels = "AaEeIiOoUuEe";
            int vowelsCount = 0; int consonantsCount = 0;
            foreach(char ch in str.ToCharArray())
            {
                if(char.IsLetter(ch))
                {
                    if (vowels.Contains(ch)) vowelsCount++;
                    else consonantsCount++;
                }
            }
            Console.WriteLine("No of vowels : " + vowelsCount );
            Console.WriteLine("No of consonants: " +consonantsCount);

        }
        //Write a C# program to reverse a given string without using any built-in reverse functions.
        public static string ReverseString(string str)
        {
            //string str2 = "vishvas";
            string reversedStr = new string(str.Reverse().ToArray());
            return reversedStr;
        }

        //Write a C# program to check if a given string is a palindrome (a string that reads the same forward and backward).

        public static bool CheckPalindrome(string str)
        {
            int i = 0;int j = str.Length-1;
            while(i<j)
            {
                if (str[i] != str[j])
                {
                    return false;
                }
                i++;j--;
            }
            return true;
        }


        // Write a C# program to remove all duplicate characters from a given string and return the modified string.

        public static string RemoveDuplicateChars(string str)
        {
            string result = "";
            HashSet<char> set = new HashSet<char>();
            foreach(char ch in str.ToCharArray())
            {
                if (set.Contains(ch))
                {
                    set.Add(ch);
                    result += ch;
                }
            }
            return result;
        }

        //Write a C# program that takes a sentence as input and returns the longest word in the sentence.
        public static string LongestWord(string str)
        {
            int maxLength = 0;
            string result = "";
            StringBuilder word = new StringBuilder();

            foreach (char ch in str.ToCharArray())
            {
                if (ch == ' ')
                {
                    if (word.Length > maxLength)
                    {
                        maxLength = word.Length;
                        result = word.ToString(); // snapshot as independent string
                    }
                    word.Clear();
                }
                else
                {
                    word.Append(ch);
                }
            }
            // check the last word
            if (word.Length > maxLength)
            {
                result = word.ToString();
            }
            return result;
        }

        //Write a C# program to count how many times a given substring occurs in a string.
         public static int OccurenceOfString(string str,string sub)
        {
            int i = 0;
            int count = 0;
            while(i < str.Length - sub.Length)
            {
                if(str.Substring(i,sub.Length) == sub)
                {
                    count++;
                }
            }
            return count;
        }

        //Write a C# program to toggle the case of each character in a given string. Convert uppercase letters to lowercase and vice versa.

        //public static int


        //Write a C# program to compare two strings lexicographically (dictionary order) without using built-in compare methods.


        //Write a C# program to find the most frequent character in a string.

        //Write a C# program to remove all occurrences of a specific character from a string.

        //Write a C# program that accepts two strings from the user and checks if the two strings are anagrams of each other(i.e., whether they contain the same characters in any order).

        //Write a replace method in C# that replaces a given word with another word in a sentence:

    }
}
