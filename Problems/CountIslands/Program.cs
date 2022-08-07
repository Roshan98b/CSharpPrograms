using Collection;
using System.Text.Json.Nodes;

namespace CountIslands
{
    public class Program
    {
        static void Main(string[] args)
        {
            var grid = new char[4][]
            {
                new char[5]{ '1', '1', '0', '0', '0' },
                new char[5]{ '1', '1', '0', '0', '0' },
                new char[5]{ '0', '0', '1', '0', '0' },
                new char[5]{ '0', '0', '0', '1', '1' }
            };

            Console.WriteLine($"Number of islands : {NumIslands(grid)}");
        }

        private static int NumIslands(char[][] grid)
        {
            var graph = new GraphMatrix<char>(grid, '0');

            Console.WriteLine("Component Graph:");
            for (int i = 0; i < graph.ComponentGrid.GetLength(0); i++)
            {
                for (int j = 0; j < graph.ComponentGrid.GetLength(1); j++)
                {
                    Console.Write(graph.ComponentGrid[i, j]);
                }
                Console.WriteLine("");
            }

            return graph.ComponentCount;
        }
    }
}