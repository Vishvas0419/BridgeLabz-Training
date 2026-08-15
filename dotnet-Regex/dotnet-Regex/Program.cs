using System.Text;
using System.Text.RegularExpressions;

namespace dotnet_Regex
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\d"; //to match if string contains any digit or not
            string input = "The price of this laptop is 6 rupees";
            bool result = Regex.IsMatch(input, pattern);
            //Console.WriteLine(result);

            //Console.WriteLine(Regex.IsMatch("hello 123", @"\w")); //true
            string vowels = "AEIOUaeiou";
            string str = "hello my name is vishvas";
            StringBuilder nonVowelsStr = new StringBuilder();
            foreach (char ch in str.ToCharArray())
            {
                if (Regex.IsMatch(ch.ToString(), @"[AEIOUaeiou\s]"))
                {
                    continue;
                }
                nonVowelsStr.Append(ch);
            }
            //Console.WriteLine(nonVowelsStr.ToString());


            //range - (a-z)
            //Console.WriteLine(Regex.IsMatch("AIDTYGHHGBDTYHBN90abcA123", @"[A-Z][a-zA-Z0-9]")); //true

            //negation ^
            //Console.WriteLine(Regex.IsMatch("abc", @"[^0-9]")); //true

            //Console.WriteLine(Regex.IsMatch("hello", @"[hel]")); //true
            //Console.WriteLine(Regex.IsMatch("hello", @"^[hel]")); //true
            //Console.WriteLine(Regex.IsMatch("",@"[]"));

            //start ^ the string should start with the regex pattern writeen after ^
            //Console.WriteLine(Regex.IsMatch("hello my name is vishvas", "^hello")); //true
            //Console.WriteLine(Regex.IsMatch("hello my name is vishvas", "^helo")); //false
            //Console.WriteLine(Regex.IsMatch("hello my roll number is 2310991082",());

            //email vaildation username@gmail.com

            //Regex.Match() and 

            //Match and MatchCollection class in System.Text.RegularExpressions;
            //Match match = Regex.Match("My email id is vishvas1234@gmail.com", @"\d+"); //1234
            //Match match2 = Regex.Match("My email id is vishvas@gmail.com", "^[a-z][@][$gmail.com]");

            //Console.WriteLine(match.Value); //1234
            //Console.WriteLine(match2.Value);

            //Regex.Matches()
            MatchCollection matches = Regex.Matches("i have 10 apples and 5 oranges in my bag", @"\d+");
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }

            //methods in Regex class 
            //Regex.Matches(); Regex.Match(); Regex.Split(); Regex.Replace();

            string[] splitResult = Regex.Split("Hello my name is vishvas, my age is 21 years old and i have 10 apples and 5 oranges in my bag",@"[,and]");

            foreach(string s in splitResult)
            {
                Console.WriteLine(s);
            }
        }
    }
}
