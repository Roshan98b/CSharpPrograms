using System;
using System.Collections.Generic;

namespace AllConstruct
{
    class Program
    {
        static List<List<string>> AllConstruct()
        {

            return new List<List<string>> { new List<string> { "abc", "def" }, new List<string>{ "abc" } };
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
