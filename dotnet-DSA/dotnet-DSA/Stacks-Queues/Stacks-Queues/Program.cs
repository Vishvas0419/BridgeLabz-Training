namespace Stacks_Queues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World this main class for stacks and queues!");
            Stack<int> stack = new Stack<int>();
            stack.Push(4);
            stack.Push(3);
            stack.Push(6);
            stack.Push(7);
            stack.Push(1);
            stack.Push(5);
            stack.Push(2);
            Console.WriteLine("Before sorting, original stack : ");
            PrintStack(stack);
            Assignment ass = new Assignment();
            ass.SortStack(stack);
            Console.WriteLine("Sorted Stack : ");
            PrintStack(stack);
        }

        private static void PrintStack(Stack<int>stack)
        {
            foreach (var item in stack)
            {
                Console.Write(item+" ");
            }
            Console.WriteLine();
        }
    }
}
