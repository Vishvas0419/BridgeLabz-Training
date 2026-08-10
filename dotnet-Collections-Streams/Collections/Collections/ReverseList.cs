

using System;
using System.Collections.Generic;
using System.Text;

namespace Collections
{
    public class ListReverser
    {
        public static List<int> Reverse(List<int> input)
        {
            List<int> result = new List<int>();
            int index = input.Count - 1;
            while (index >= 0)
            {
                result.Add(input[index]);
                index--;
            }
            return result;
        }

    }}
