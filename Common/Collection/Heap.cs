using System;
using System.Collections;
using System.Collections.Generic;

namespace Collection
{
    /// <summary>
    /// The Min Heap class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Heap<T>: IEnumerable<T>
    {
        public T[] Array { get; set; }
        public int Size { get; set; }

        public Heap(int capacity)
        {
            this.Size = 0;
            this.Array = new T[capacity];
        }

        private void Swap(int index1, int index2)
        {
            T temp = this.Array[index1];
            this.Array[index1] = this.Array[index2];
            this.Array[index2] = temp;
        }

        private void ShiftUp(int index)
        {
            int parent = (index % 2) != 0 ? index / 2 : (index - 2) / 2;
            if (parent >=0 && Comparer<T>.Default.Compare(this.Array[parent], this.Array[index]) > 0)
            {
                this.Swap(parent, index);
                this.ShiftUp(parent);
            }
        }

        private void ShiftDown(int index)
        {
            int leftChild = (2 * index) + 1;
            int rightChild = (2 * index) + 2;
            if (leftChild < this.Size)
            {
                int child;
                if (rightChild >= this.Size || Comparer<T>.Default.Compare(this.Array[leftChild], this.Array[rightChild]) < 0)
                {
                    child = leftChild;
                } 
                else
                {
                    child = rightChild;
                }
                if (Comparer<T>.Default.Compare(this.Array[index], this.Array[child]) > 0)
                {
                    this.Swap(child, index);
                    this.ShiftDown(child);
                }
            }
        }

        public void Insert(T data)
        {
            this.Array[this.Size] = data;
            this.Size++;
            this.ShiftUp(this.Size-1);
        }

        public T Poll()
        {
            if (this.Size == 0)
            {
                return default;
            }
            T data = this.Array[0];
            this.Swap(0, this.Size - 1);
            this.Size--;
            this.ShiftDown(0);
            return data;
        }

        private int Find(T data)
        {
            for (int i = 0; i < this.Size; i++)
            {
                if (this.Array[i].Equals(data))
                {
                    return i;
                }
            }
            return -1;
        }

        public (T, int) Delete(T data)
        {
            int index = this.Find(data);
            if (index != -1)
            {
                this.Swap(index, this.Size - 1);
                this.Size--;
                this.ShiftUp(index);
                this.ShiftDown(index);
                return (data, index);
            }
            return (default, index);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Size; i++)
            {
                yield return this.Array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

    }
}
