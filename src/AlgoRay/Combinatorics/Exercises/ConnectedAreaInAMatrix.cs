using AlgoRay.Helpers;
using System;
using System.Collections.Generic;

namespace AlgoRay.Combinatorics.Exercises
{
    public class ConnectedAreaInAMatrix
    {
        private static char[,] localMatrix;
        private static int counter;
        private static readonly SortedSet<Area> allAreas = new SortedSet<Area>();
        private static readonly IList<string> outputResults = new List<string>();

        public static AlgorithmicResult<IList<string>> Run(char[,] matrix)
        {
            localMatrix = matrix;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] != '*')
                    {
                        counter = 0;
                        SolvePaths(i, j);
                        allAreas.Add(new Area(i, j, counter));
                    }
                }
            }

            FillResultsInOutputResults();

            return new AlgorithmicResult<IList<string>>(outputResults, true);
        }

        private static void SolvePaths(int row, int col)
        {
            if (IsOutOfBounds(row, col) || localMatrix[row, col] == '*')
            {
                return;
            }

            localMatrix[row, col] = '*';
            counter++;

            SolvePaths(row + 1, col);
            SolvePaths(row - 1, col);
            SolvePaths(row, col + 1);
            SolvePaths(row, col - 1);
        }

        private static bool IsOutOfBounds(int row, int col)
        {
            return row < 0 || row >= localMatrix.GetLength(0) ||
                col < 0 || col >= localMatrix.GetLength(1);
        }

        private static void FillResultsInOutputResults()
        {
            outputResults.Add($"Total areas found: {allAreas.Count}");

            var number = 1;
            foreach (var result in allAreas)
            {
                outputResults.Add($"Area #{number} at ({result.x}, {result.y}), size: {result.size}");
                number++;
            }
        }

        private class Area : IComparable
        {
            public int x;
            public int y;

            public int size;

            public Area(int x, int y, int size)
            {
                this.x = x;
                this.y = y;
                this.size = size;
            }

            public int CompareTo(object obj)
            {
                var area = obj as Area;

                if (this.size == area.size)
                {
                    if (this.x == area.x)
                    {
                        return this.y.CompareTo(area.y);
                    }
                    else
                    {
                        return this.x.CompareTo(area.x);
                    }
                }
                else
                {
                    return area.size.CompareTo(this.size);
                }
            }
        }
    }
}
