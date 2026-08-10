namespace Collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

            List<int> reversedCopy = ListReverser.Reverse(numbers);
            Console.WriteLine(string.Join(", ", reversedCopy));

            ListReverser.ReverseInPlace(numbers);
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
