namespace _06_Built_In_Functions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Think of a number between 1 and 100.");
            int low = 0; int high = 100;
            while (true)
            {
                int guess = Assignment.GuessNumber(low, high);

                Console.WriteLine("Computer Guess: " + guess);
                Console.Write("Enter H for High, L for Low, C for Correct: ");

                char feedback = Convert.ToChar(Console.ReadLine());

                if (Assignment.IsCorrect(feedback))
                {
                    Console.WriteLine("Computer guessed correctly.");
                    break;
                }

                Assignment.UpdateRange(ref low, ref high, guess, feedback);
            }
        }
    }
}
