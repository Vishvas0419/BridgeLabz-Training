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

            //start ^ means the string should start with the regex pattern written after ^

            //Console.WriteLine(Regex.IsMatch("hello my name is vishvas", "^hello")); //true
            //Console.WriteLine(Regex.IsMatch("hello my name is vishvas", "^helo")); //false
            //Console.WriteLine(Regex.IsMatch("hello my roll number is 2310991082",());

            //email vaildation username@gmail.com

            string input3 = "vishvas@gmail.com";
            string emailPattern = @"^[a-zA-z0-9]+@gmail\.com$";
            bool isValidEmail = Regex.IsMatch(input3,emailPattern);

            if(isValidEmail) Console.WriteLine($"{input3} is a valid email");
            else Console.WriteLine($"{input3} is not a valid email");

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

            //foreach(string s in splitResult)
            //{
            //    Console.WriteLine(s);
            //}

            //regex class methods
            string input2 = "My phone number is 123-456-7890";
            string pattern2 = @"\d{3}-\d{3}-\d{4}";
            string replacement = "***-***-****";
            string result2 = Regex.Replace(input2, pattern2, replacement);
            Console.WriteLine(result2);

            //Lookaheads and Lookbehinds

            string input4 = "hello i have 100 apples and 50 oranges";
            Match match4 = Regex.Match(input4, @"\d+(?= apples)"); //this regex pattern means : match \d only if apples comes after \d (positive lookahead)
            Console.WriteLine(match4);//100

            //note : regex.match will matches the regex pattern string that is outside the parenthesis () here \d+ will be the output

            string input5 = "hello i have 100 apples and 50 oranges";
            Match match5 = Regex.Match(input5, @"\d+(?! apples)"); //this regex pattern means : match \d only if apples does not comes after \d (negative lookahead)
            Console.WriteLine(match5);//10

            string input6 = "hello i have 100 apples and 50 oranges";
            Match match6 = Regex.Match(input6, @"(?<=\d+) oranges"); //this regex pattern means : match oranges only if \d comes before apples (positive lookbehind)
            Console.WriteLine(match6);//apples

            string input7 = "hello i have 100 apples and 50 oranges and i have lot of oranges";
            Match match7 = Regex.Match(input7, @"(?<!\d+) oranges"); //this regex pattern means : match oranges only if \d does not comes before apples (negative lookbehind)
            Console.WriteLine(match7);//empty output because their is no pattern which have not 


            //email validation 
            //email = vishvas1234@gmail.com
            string input8 = "vishvas@gmail.com";
            //Match match8 = Regex.Match(input8, @"^[0-9A-Za-z._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            //Console.WriteLine(match8);
            if (Regex.IsMatch(input8, @"^[0-9A-Za-z._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                Console.WriteLine($"{input8} is a valid email address");
            }
            else Console.WriteLine($"{input8} is not a valid email adddress");


            // URL Validation
            string input9 = "https://www.google.com/";
            Match Regex.IsMatch(input9, @"^(http://|https://)?(www)?\.(\w\d)+\.(\w{2,})");
            Console.WriteLine();
        }
    }
}
