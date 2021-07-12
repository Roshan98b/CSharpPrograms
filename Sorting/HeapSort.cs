using System;
using System.Collections.Generic;

namespace Sorting
{
    public class HeapSort
    {
        public static List<int> Sort(List<int> arr)
        {
            Heap heap = new(arr);
            int size = heap.Count;
            List<int> sortedArr = new(size);
            for (int i = 0; i < size; i++)
            {
                sortedArr.Add(heap.Poll());
            }
            return sortedArr;
        }

        public static void PrintArray(List<int> arr)
        {
            foreach (int item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("");
        }
    }

    class Heap
    {
        private readonly List<int> data;

        public List<int> Data
        {
            get => data;
        }

        public int Count
        {
            get => data.Count;
        }

        public Heap(List<int> arr)
        {
            data = new List<int>();
            Heapify(arr);
        }

        private void Swap(int a, int b)
        {
            int temp = data[a];
            data[a] = data[b];
            data[b] = temp;
        }

        private void Swim(int child)
        {
            int parent = (int)(child - 1) / 2;
            while (child > 0 && data[parent] < data[child])
            {
                Swap(parent, child);
                child = parent;
                parent = (int)(child - 1) / 2;
            }
        }

        private void Sink(int parent)
        {
            int leftChild = (2 * parent) + 1;
            int rightChild = (2 * parent) + 2;
            int size = data.Count;
            while (leftChild < size)
            {
                if (rightChild < size)
                {
                    if (data[parent] < data[leftChild] || data[parent] < data[rightChild])
                    {
                        int swapChild = data[leftChild] > data[rightChild] ? leftChild : rightChild;
                        Swap(parent, swapChild);
                        parent = swapChild;
                        leftChild = (2 * parent) + 1;
                        rightChild = (2 * parent) + 2;
                    } 
                    else
                    {
                        break;
                    }
                }
                else
                {
                    if (data[parent] < data[leftChild])
                    {
                        Swap(parent, leftChild);
                        parent = leftChild;
                        leftChild = (2 * parent) + 1;
                        rightChild = (2 * parent) + 2;
                    } 
                    else
                    {
                        break;
                    }
                }
            }
        }

        public int Poll()
        {
            int poll = data[0];
            Swap(0, data.Count - 1);
            data.RemoveAt(data.Count - 1);
            Sink(0);
            return poll;
        }

        private void Heapify(List<int> arr)
        {
            foreach (int item in arr)
            {
                data.Add(item);
                Swim(data.Count - 1);
            }
        }
    }
}
