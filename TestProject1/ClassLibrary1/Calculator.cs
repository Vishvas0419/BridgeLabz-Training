using System.Reflection.Metadata.Ecma335;

namespace ClassLibrary1
{
    public class Calculator
    {
        public int add(int x, int y)
        {
            return x + y;
        }
        internal int subtract(int x, int y)
        {
            if(y>x) return y-x;
            else return x-y;
        }
        internal int multiply(int x, int y)
        {
            return x * y;
        }
        internal int divide(int x, int y)
        {
            if (y == 0) return 0;
            return x / y;
        }
        internal int mod(int x, int y)
        {
            return (x % y);
        }

    }
}
