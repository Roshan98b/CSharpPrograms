using System;
using System.Collections.Generic;
using Sorting;

namespace ArrayElements
{
    class Program
    {
        static void Main()
        {
            List<int> arr = new(new int[] { 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 });

            //MergeSort.PrintArray(arr);
            //MergeSort.Sort(arr, 0, arr.Count - 1);
            //MergeSort.PrintArray(arr);

            QuickSort.PrintArray(arr);
            QuickSort.Sort(arr, 0, arr.Count - 1);
            QuickSort.PrintArray(arr);
        }
    }
}
