using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace FibonacciNumbers
{
    class Program
    {
        static int Fibonacci(int n)
        {
            if (n == 1 || n == 2)
            {
                return 1;
            }
            else
            {
                return Fibonacci(n - 1) + Fibonacci(n - 2);
            }
        }

        static int FibonacciMemo(int n, Dictionary<int, int> memo = null)
        {
            if (memo == null)
            {
                memo = new();
            }
            if (memo.ContainsKey(n))
            {
                return memo[n];
            }
            else if (n == 1 || n == 2)
            {
                memo.Add(n, 1);
                return 1;
            }
            else
            {
                int res = FibonacciMemo(n - 1, memo) + FibonacciMemo(n - 2, memo);
                memo.Add(n, res);
                return res;
            }
        }

        static void Main(string[] args)
        {
            Stopwatch sw;

            sw = Stopwatch.StartNew();
            int fibMemo = FibonacciMemo(10);
            sw.Stop();
            Console.WriteLine(fibMemo + " " + sw.ElapsedTicks);

            sw = Stopwatch.StartNew();
            int fib = Fibonacci(10);
            sw.Stop();
            Console.WriteLine(fib + " " + sw.ElapsedTicks);
        }
    }
}
