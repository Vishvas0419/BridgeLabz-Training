namespace Searching
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "D:\\BridgeLabz-Training\\dotnet-DSA\\dotnet-DSA\\Searching\\Searching\\source.txt";
            string targetword = "java";
            string text = File.ReadAllText(filePath);
            string[] words = text.Split(' ');
            int index = 0;
            for(int i=0;i<words.Length;i++) //linear search
            {
                if(words[i].ToLower() == targetword.ToLower())
                {
                    index = i;
                    break;
                }
            }
            if (index != -1)
            {
                Console.WriteLine($"Word {targetword} found at index : {index}");
            }
            else
            {
                Console.WriteLine($"Word {targetword} not found in the source file");
            }


        }
    }
}
