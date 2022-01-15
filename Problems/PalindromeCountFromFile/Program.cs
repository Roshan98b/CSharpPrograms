using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static bool IsPalindrome(string word)
        {
            for (int i = 0; i < word.Length/2; i++)
            {
                if (word[i] != word[word.Length-(i+1)])
                {
                    return false;
                }
            }
            return true;
        }

        static void Main(string[] args)
        {
            try
            {
                StreamReader streamReader = new StreamReader(@"C:\Users\robadrin\source\repos\ConsoleApp1\ConsoleApp1\data.txt");
                List<string> words = new List<string>();
                int count = 0;
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    words.AddRange(line.Split(new char[] { ' ', '.', ',' }, StringSplitOptions.RemoveEmptyEntries));
                }
                foreach(string word in words)
                {
                    if (IsPalindrome(word.ToLower()))
                    {
                        count++;
                    }
                }
                Console.WriteLine("");
                Console.WriteLine("Count = " + count);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
