using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CanConstruct
{
    class Program
    {
        static bool CanConstruct(string target, List<string> wordBank)
        {
            if (target == "")
            {
                return true;
            }
            else
            {
                foreach (string word in wordBank)
                {
                    if (target.StartsWith(word))
                    {
                        if (CanConstruct(target.Remove(0, word.Length), wordBank))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }

        static bool CanConstructMemo(string target, List<string> wordBank, Dictionary<string, bool> memo = null)
        {
            if (memo == null)
            {
                memo = new();
            }
            if (memo.ContainsKey(target))
            {
                return memo[target];
            }
            if (target == "")
            {
                return true;
            }
            else
            {
                foreach (string word in wordBank)
                {
                    if (target.StartsWith(word))
                    {
                        if (CanConstructMemo(target.Remove(0, word.Length), wordBank))
                        {
                            memo.Add(target, true);
                            return true;
                        }
                    }
                }
                memo.Add(target, false);
                return false;
            }
        }

        static void Main(string[] args)
        {
            Stopwatch sw;

            sw = Stopwatch.StartNew();
            bool canConstruct = CanConstruct("abcdef", new List<string> { "ab", "abc", "cd", "de", "abcd" });
            sw.Stop();
            Console.WriteLine(canConstruct + " " + sw.ElapsedTicks);

            sw = Stopwatch.StartNew();
            bool canConstructMemo = CanConstructMemo("abcdef", new List<string> { "ab", "abc", "cd", "de", "abcd" });
            sw.Stop();
            Console.WriteLine(canConstructMemo + " " + sw.ElapsedTicks);
        }
    }
}
