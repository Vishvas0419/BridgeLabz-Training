namespace ReadWriteBasics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter an integer: ");
            int i = int.Parse(Console.ReadLine());
            Console.WriteLine($"You entered: {i}");

            Console.Write("Enter a double: ");
            double d = double.Parse(Console.ReadLine());
            Console.WriteLine($"You entered: {d}");

            Console.Write("Enter a string: ");
            string s = Console.ReadLine();
            Console.WriteLine($"You entered: {s}");

            Console.WriteLine("Enter a boolean: ");
            bool b = bool.Parse(Console.ReadLine());
            Console.WriteLine($"You entered: {b}");

            Console.WriteLine("Enter a character: ");
            char c = char.Parse(Console.ReadLine());
            Console.WriteLine($"You entered: {c}")
        }
    }
}
