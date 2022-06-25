using System;
using System.Collections.Generic;

namespace PageCompression
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Page> pages = new List<Page>
            {
                new Page(1, 5),
                new Page(4, 6),
                new Page(10, 5)
            };

            var result = TransformOverlapOrContiguous(pages);

            foreach (Page page in result)
            {
                Console.WriteLine($"start: {page.Start}, length: {page.Length}");
            }
        }

        private static List<Page> TransformOverlapOrContiguous(List<Page> pages)
        {
            for (int i = 0; i < pages.Count - 1; i++)
            {
                if (pages[i].End > pages[i + 1].Start || pages[i].End + 1 == pages[i + 1].Start)
                {
                    Page newPage = new Page(pages[i].Start, pages[i].Start + pages[i + 1].End - 1);
                    pages[i] = newPage;
                    pages.RemoveAt(i + 1);
                    i--;
                }
            }
            return pages;
        }

        internal class Page
        {
            public int Start { get; set; }
            public int Length { get; set; }
            public int End { get { return this.Start + this.Length - 1; } }

            public Page(int start, int length)
            {
                this.Start = start;
                this.Length = length;
            }

        }
    }
}
