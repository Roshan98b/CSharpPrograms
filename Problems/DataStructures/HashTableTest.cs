using System;
using Collection;

namespace DataStructures
{
    internal class HashTableTest : IDataStructuresTest
    {
        private static readonly HashTable<int, string> table = new HashTable<int, string>(capacity: 5);

        public void Validate()
        {
            table.Add(1, "Test1");
            table.Add(10, "Test10");
            table.Add(150, "Test150");
            Display(table);

            table.Remove(150);
            Display(table);

            table.Add(500, "Test500");
            Display(table);

            Console.WriteLine($"Does 150 exist: {table.Exists(150)}");
            Console.WriteLine($"Does 500 exist: {table.Exists(500)}");

            Console.WriteLine($"Get 150: {table.Get(150)}");
            Console.WriteLine($"Get 500: {table.Get(500)}");
        }

        private static void Display<K, V>(HashTable<K, V> table)
        {
            foreach ((K key, V value) in table)
            {
                Console.Write($"{{ {key}: {value} }} ");
            }
            Console.WriteLine("");
        }
    }
}
