using System;
using System.Collections.Generic;

namespace Collection
{
    /// <summary>
    /// The graph matrix
    /// </summary>
    /// <typeparam name="T">Element Type</typeparam>
    public class GraphMatrix<T>
    {
        public T[][] Grid { get; private set; }

        public int[,] ComponentGrid { get; private set; }

        public int ComponentCount { get; private set; }

        private bool[,] Visited { get; set; }

        private T EmptyIndex { get; set; }

        private (int, int) Dimension { get { return (Grid.Length, Grid[0].Length); } }

        public GraphMatrix(T[][] grid, T emptyIndex)
        {
            Grid = grid;
            Visited = new bool[Dimension.Item1, Dimension.Item2];
            ComponentGrid = new int[Dimension.Item1, Dimension.Item2];
            ComponentCount = 0;
            EmptyIndex = emptyIndex;
            GetComponents();
        }

        private (int, int[,]) GetComponents()
        {
            for (int i = 0; i < Dimension.Item1; i++)
            {
                for (int j = 0; j < Dimension.Item2; j++)
                {
                    if (!Visited[i, j] && !Grid[i][j].Equals(EmptyIndex))
                    {
                        ComponentCount++;
                        DfsMatrix(i, j);
                    }
                }
            }
            return (ComponentCount, ComponentGrid);
        }

        private void DfsMatrix(int x, int y)
        {
            if (Visited[x, y]) return;
            else
            {
                Visited[x, y] = true;
                ComponentGrid[x, y] = ComponentCount;
                var neighbours = GetNeighbours(x, y);                
                foreach (var neighbor in neighbours)
                {
                    DfsMatrix(neighbor.Item1, neighbor.Item2);
                }
            }
        }

        private List<Tuple<int, int>> GetNeighbours(int x, int y)
        {
            List<Tuple<int, int>> neighbours = new List<Tuple<int, int>>();
            
            if (IsValidIndex(x - 1, y) && !Grid[x - 1][y].Equals(EmptyIndex))
            {
                neighbours.Add(new Tuple<int, int>(x - 1, y));
            }
            if (IsValidIndex(x, y - 1) && !Grid[x][y - 1].Equals(EmptyIndex))
            {
                neighbours.Add(new Tuple<int, int>(x, y - 1));
            }
            if (IsValidIndex(x + 1, y) && !Grid[x + 1][y].Equals(EmptyIndex))
            {
                neighbours.Add(new Tuple<int, int>(x + 1, y));
            }
            if (IsValidIndex(x, y + 1) && !Grid[x][y + 1].Equals(EmptyIndex))
            {
                neighbours.Add(new Tuple<int, int>(x, y + 1));
            }

            return neighbours;
        }

        private bool IsValidIndex(int x, int y)
        {
            if (x < 0 || y < 0 || x >= Dimension.Item1 || y >= Dimension.Item2) return false;
            else return true;
        }
    }
}
