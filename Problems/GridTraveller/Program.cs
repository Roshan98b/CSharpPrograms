using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace GridTraveller
{
    class Program
    {
        static int GridTravell(int m, int n)
        {
            if (m == 0 || n == 0)
            {
                return 0;
            }
            else if (m == 1 && n == 1)
            {
                return 1;
            }
            else
            {
                return GridTravell(m - 1, n) + GridTravell(m, n - 1);
            }
        }

        static int GridTravellMemo(int m, int n, Dictionary<int, int> memo = null)
        {
            if (memo == null)
            {
                memo = new();
            }
            if (memo.ContainsKey((m > n) ? (m * 10) + n : (n * 10) + m))
            {
                return memo[(m > n) ? (m * 10) + n : (n * 10) + m];
            }
            if (m == 0 || n == 0)
            {
                return 0;
            }
            else if (m == 1 && n == 1)
            {
                memo.Add(11, 1);
                return 1;
            }
            else
            {
                int res = GridTravellMemo(m - 1, n) + GridTravellMemo(m, n - 1);
                memo.Add((m > n) ? (m * 10) + n : (n * 10) + m, res);
                return res;
            }
        }

        static void Main(string[] args)
        {
            Stopwatch sw;

            sw = Stopwatch.StartNew();
            int grid = GridTravell(16, 16);
            sw.Stop();
            Console.WriteLine(grid + " " + sw.ElapsedTicks);

            sw = Stopwatch.StartNew();
            int gridMemo = GridTravellMemo(16, 16);
            sw.Stop();
            Console.WriteLine(gridMemo + " " + sw.ElapsedTicks);
        }
    }
}
