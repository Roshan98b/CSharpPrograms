using System;
using System.Collections;
using System.Collections.Generic;

namespace Collection
{
    /// <summary>
    /// The Vector class
    /// </summary>
    public class Vector<T>: IEnumerable<T>
    {
        public int Size { get; private set;  }
        
        private T[] Array { get; set; }

        public int Capacity { get; private set; }
        
        public Vector(int capacity = 16)
        {
            this.Size = 0;
            this.Array = new T[capacity];
            this.Capacity = capacity;
        }
        
        public bool IsEmpty()
        {
            return this.Size == 0;
        }

        private void IndexCheck(int index)
        {
            if (index >= this.Size || index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"{index} is not in between 0 and {this.Size}");
            }
        }

        private void SizeCheck()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException("No elements to Pop");
            }
        }

        public T At(int index)
        {
            this.IndexCheck(index);
            return this.Array[index-1];
        }

        public void Push(T item)
        {
            if (this.Size == this.Capacity)
            {
                this.Resize(this.Capacity * 2);
            }
            this.Array[this.Size] = item;
            this.Size++;
        }

        public void Insert(T item, int index)
        {
            this.IndexCheck(index);
            if (this.Size == this.Capacity)
            {
                this.Resize(this.Capacity * 2);
            }
            for (int i = this.Size; i > index; i--)
            {
                this.Array[i] = this.Array[i - 1];
            }
            this.Array[index] = item;
            this.Size++;
        }

        public void Prepend(T item)
        {
            this.Insert(item, 0);
        }

        public T Pop()
        {
            if (this.Size == this.Capacity / 4)
            {
                this.Resize(this.Capacity / 2);
            }
            this.SizeCheck();
            T value = this.Array[this.Size - 1];
            this.Array[this.Size - 1] = default(T);
            this.Size--;
            return value;
        }

        public void Delete(int index)
        {
            if (this.Size == this.Capacity / 4)
            {
                this.Resize(this.Capacity / 2);
            }
            this.SizeCheck();
            this.IndexCheck(index);
            for (int i = index+1; i < this.Size; i++)
            {
                this.Array[i-1] = this.Array[i];
            }
            this.Array[this.Size - 1] = default(T);
            this.Size--;
        }

        public int Find(T item)
        {
            for (int i = 0; i < this.Size; i++)
            {
                if (this.Array[i].Equals(item)) return i;
            }
            return -1;
        }

        public bool Remove(T item)
        {
            if (this.Size == this.Capacity / 4)
            {
                this.Resize(this.Capacity / 2);
            }
            int seek = 0;
            for (int i = 0; i < this.Size; i++)
            {
                if (this.Array[i].Equals(item))
                {
                    seek++;
                    continue;
                }
                this.Array[i-seek] = this.Array[i];
            }
            for (int i = 1; i <= seek; i++)
            {
                this.Array[Size - i] = default(T);
            }
            this.Size -= seek;
            return seek != 0;
        }

        private void Resize(int capacity)
        {
            this.Capacity = capacity;
            T[] temp = new T[capacity];
            for (int i = 0; i < this.Size; i++)
            {
                temp[i] = this.Array[i];
            }
            this.Array = temp;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach(T element in this.Array)
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
