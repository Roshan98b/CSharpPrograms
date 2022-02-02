using System.Collections;
using System.Collections.Generic;

namespace Collection
{
    /// <summary>
    /// The Linear Probing Hash Table Class
    /// </summary>
    /// <typeparam name="K">Key</typeparam>
    /// <typeparam name="V">Value</typeparam>
    public class HashTable<K, V>: IEnumerable<(K, V)>
    {
        public int Size { get; private set; }

        private Pair<K, V>[] Table { get; set; }

        public int Capacity { get; private set; }

        private int Threshold { get; set; }

        private int TombstoneNumber { get; set; }

        private readonly Pair<K, V> Tombstone;

        private readonly double LoadFactor;

        public HashTable(int capacity = 16, double loadFactor = 0.6)
        {
            this.Tombstone = new Pair<K, V>(default, default, 0);
            this.LoadFactor = loadFactor;
            this.Size = 0;
            this.Table = new Pair<K, V>[capacity];
            this.Capacity = capacity;
            this.TombstoneNumber = 0;
            this.Threshold = (int)(this.Capacity * this.LoadFactor);
        }

        private int Hash1(K key)
        {
            return key.GetHashCode();
        }

        private int Probe(K key, int x)
        {
            return x;
        }

        private void Resize(int capacity)
        {
            Pair<K, V>[] NewTable = new Pair<K, V>[capacity];
            foreach(var element in this.Table)
            {
                if (element != null && !element.Equals(this.Tombstone))
                {
                    int x = 1;
                    int index = element.Hash % capacity;
                    while (NewTable[index] != null)
                    {
                        index = (element.Hash + Probe(element.Key, x)) % capacity;
                        x++;
                    }
                    NewTable[index] = new Pair<K, V>(element.Key, element.Value, element.Hash);
                }
            }
            this.Table = NewTable;
            this.Capacity = capacity;
            this.TombstoneNumber = 0;
            this.Threshold = (int)(capacity * this.LoadFactor);
        }

        public void Add(K key, V value)
        {
            if (this.Size + this.TombstoneNumber == this.Threshold)
            {
                this.Resize(this.Capacity * 2);
            }
            int x = 1;
            int index = Hash1(key) % this.Capacity;
            while (this.Table[index] != null)
            {
                index = (Hash1(key) + Probe(key, x)) % this.Capacity;
                x++;
            }
            this.Table[index] = new Pair<K, V>(key, value, Hash1(key));
            this.Size++;
        }

        public bool Exists(K key)
        {
            int index = Hash1(key) % this.Capacity;
            if (this.Table[index] == null)
            {
                return false;
            } 
            else
            {
                int x = 1;
                while (this.Table[index] != null)
                {
                    if (this.Table[index].Key.Equals(key))
                    {
                        return true;
                    } else
                    {
                        index = (Hash1(key) + Probe(key, x)) % this.Capacity;
                        x++;
                    }
                }
                return false;
            }
        }

        public V Get(K key)
        {
            int index = Hash1(key) % this.Capacity;
            if (this.Table[index] == null)
            {
                return default;
            }
            else
            {
                int x = 1;
                while (this.Table[index] != null)
                {
                    if (this.Table[index].Key.Equals(key))
                    {
                        return this.Table[index].Value;
                    }
                    else
                    {
                        index = (Hash1(key) + Probe(key, x)) % this.Capacity;
                        x++;
                    }
                }
                return default;
            }
        }

        public int Find(K key)
        {
            int index = Hash1(key) % this.Capacity;
            if (this.Table[index] == null)
            {
                return -1;
            }
            else
            {
                int x = 1;
                while (this.Table[index] != null)
                {
                    if (this.Table[index].Key.Equals(key))
                    {
                        return index;
                    }
                    else
                    {
                        index = (Hash1(key) + Probe(key, x)) % this.Capacity;
                        x++;
                    }
                }
                return -1;
            }
        }

        public bool Remove(K key)
        {
            int index = Find(key);
            if (index == -1)
            {
                return false;
            }
            else
            {
                this.Table[index] = Tombstone;
                this.Size--;
                this.TombstoneNumber++;
                return true;
            }
        }

        public IEnumerator<(K, V)> GetEnumerator()
        {
            foreach (var element in this.Table)
            {
                if (element != null && !element.Equals(this.Tombstone))
                {
                    yield return (element.Key, element.Value);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    internal class Pair<K, V>
    {
        public K Key { get; set; }

        public V Value { get; set; }
        
        public int Hash { get; set; }

        public Pair(K key, V value, int hash)
        {
            this.Key = key;
            this.Value = value;
            this.Hash = hash;
        }
    }

}
