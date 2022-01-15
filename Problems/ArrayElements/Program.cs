using System;
using System.Collections.Generic;
using Sorting;

namespace ArrayElements
{
    class Program
    {
        static void Main()
        {
            List<int> arr = new(new int[] { 9, 7, 1, 5, 3, 2, 8, 6, 4 });

            MergeSort.PrintArray(arr);
            MergeSort.Sort(arr, 0, arr.Count - 1);
            MergeSort.PrintArray(arr);

            QuickSort.PrintArray(arr);
            QuickSort.Sort(arr, 0, arr.Count - 1);
            QuickSort.PrintArray(arr);

            HeapSort.PrintArray(arr);
            List<int> sortedArr =  HeapSort.Sort(arr);
            HeapSort.PrintArray(sortedArr);
        }
    }
}
