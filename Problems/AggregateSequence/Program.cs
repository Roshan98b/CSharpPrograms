namespace AggregateSequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            string sequence = "a123b1a2d1b29879d10c91";
            Console.WriteLine($"Sequence: {sequence}");
            Console.WriteLine($"Aggregated Sequence: {SequenceGenerate(sequence)}");
        }

        public static string SequenceGenerate(string sequence)
        {
            // String Parser and Generate Hash map
            var map = LexicalAnalysis(sequence);

            // Sort Map - Ordered Map
            var orderedPair = map.ToList();
            orderedPair.Sort(new KeyValuePairComparer());

            // Generate String from Map
            string generatedSequence = "";
            foreach (var pair in orderedPair)
            {
                generatedSequence += $"{pair.Key}{pair.Value}";
            }

            return generatedSequence;
        }

        private static Dictionary<char, int> LexicalAnalysis(string sequence)
        {
            var tempDigit = "";
            var tempChar = ' ';
            var map = new Dictionary<char, int>();

            // Generate Map
            foreach (char item in sequence)
            {
                if (char.IsLetter(item))
                {
                    if (string.IsNullOrEmpty(tempDigit))
                    {
                        tempChar = item;
                    }
                    else
                    {
                        AddOrUpdateMap(map, tempChar, tempDigit);
                        tempChar = item;
                        tempDigit = "";
                    }
                }
                if (char.IsDigit(item))
                {
                    tempDigit += item;
                }
            }

            // Handling last iteration
            AddOrUpdateMap(map, tempChar, tempDigit);

            return map;
        }

        private static void AddOrUpdateMap(Dictionary<char, int> map, char tempChar, string tempDigit)
        {
            int count = int.Parse(tempDigit);
            if (map.ContainsKey(tempChar))
            {
                map[tempChar] += count;
            }
            else
            {
                map[tempChar] = count;
            }
        }
    }

    public class KeyValuePairComparer : IComparer<KeyValuePair<char, int>>
    {
        public int Compare(KeyValuePair<char, int> x, KeyValuePair<char, int> y)
        {
            if (x.Key <= y.Key) 
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
    }
}