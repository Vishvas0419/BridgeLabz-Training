namespace TypeConversion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string numStr = "123";
            int num = int.Parse(numStr);
            Console.WriteLine("String to int: " + num);

            double dNum = num;
            Console.WriteLine("Implicit int to double: " + dNum);

            double dValue = 45.67;
            int iValue = (int)dValue;
            Console.WriteLine("Explicit double to int: " + iValue);

            string backToString = iValue.ToString();
            Console.WriteLine("Int to string: " + backToString);
        }
    }
}
