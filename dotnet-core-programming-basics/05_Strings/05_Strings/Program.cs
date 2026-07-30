namespace _05_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");

            //Basics.BasicsOfString();










            //Console.WriteLine("Enter string to find no of vowels, consonants : ");
            //string inputStr1 = Console.ReadLine();
            //PractiseProblems.CountVowelConsonants(inputStr1);

            //Console.WriteLine("Enter a string to reverse a string");
            //string inputStr2 = Console.ReadLine();
            //Console.WriteLine(PractiseProblems.ReverseString(inputStr2));

            //Console.WriteLine("enter a string to check palindrome : ");
            //string inputStr3 = Console.ReadLine();
            //if(PractiseProblems.CheckPalindrome(inputStr3))Console.WriteLine("Is Palindrome");
            //else Console.WriteLine("Not palindrome");

            //Console.WriteLine("Enter a string to return longest word in a sentence : ");
            //string inputStr4 = Console.ReadLine();
            //Console.WriteLine(PractiseProblems.LongestWord(inputStr4));


            Console.WriteLine("Enter a string to check occ of a substring in it : ");
            string inputStr5 = Console.ReadLine();

            Console.WriteLine("Enter a substring : to find its no of occurences : ");
            string substr = Console.ReadLine();
            Console.WriteLine(PractiseProblems.OccurenceOfString(inputStr5,substr));
        }
    }
}
