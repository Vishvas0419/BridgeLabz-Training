namespace Sorting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] BubbleArray = {2,3,4,1,6,7,1,3,4,65,8};
            Assignment.BubbleSort(BubbleArray);
            PrintArray(BubbleArray);

            int[] insertionArray = { 2, 3, 4, 1, 5, 6, 7, 1, 3 };
            Assignment.InsertionSort(insertionArray);
            PrintArray(insertionArray);

            int[]selectionArray = { 2, 3, 4,1, 5, 6,7, 1, 3 };
            Assignment.SelectionSort(selectionArray);
            PrintArray(selectionArray);

            int[] mergeArray = { 2, 3, 4, 5, 8, 10 };
            Assignment.MergeSort(mergeArray, 0, mergeArray.Length);
            PrintArray(mergeArray);

            int[] prices = { 500, 200, 800, 100, 400 };
            Assignment.QuickSort(prices, 0, prices.Length - 1);
            PrintArray(prices);

        }
        public static void PrintArray(int[]arr)
        {
            foreach (var item in arr)
            {
                Console.Write(item+" ");
            }
            Console.WriteLine();
        }
    }
}
