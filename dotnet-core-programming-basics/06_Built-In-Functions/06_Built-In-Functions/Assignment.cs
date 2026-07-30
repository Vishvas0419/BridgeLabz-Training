using System;
using System.Collections.Generic;
using System.Text;

namespace _06_Built_In_Functions
{
    internal class Assignment
    {
        public static int GuessNumber(int low,int high)
        {
            Random random = new Random();
            return random.Next(low, high);
        }

        public static void UpdateRange(ref int low, ref int high, int guess, char feedback)
        {
            if (feedback == 'H' || feedback == 'h')
                high = guess - 1;
            else if (feedback == 'L' || feedback == 'l')
                low = guess + 1;
        }

        public static bool IsCorrect(char feedback)
        {
            return feedback == 'C' || feedback == 'c';
        }
    }
}
