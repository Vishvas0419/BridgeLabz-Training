using System;
using System.Collections.Generic;
using System.Text;

namespace Stacks_Queues
{
    internal class Assignment
    {
        public void SortStack(Stack<int> stack)
        {
            if (stack.Count > 0)
            {
                int top = stack.Pop();
                SortStack(stack);
                InsertSorted(stack, top);
            }
        }

        private void InsertSorted(Stack<int> stack, int value)
        {
            if (stack.Count == 0 || stack.Peek() >= value)
            {
                stack.Push(value);
            }
            else
            {
                int top = stack.Pop();
                InsertSorted(stack, value);
                stack.Push(top);
            }
        }
    }
}
