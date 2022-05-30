using AlgoRay.Helpers;
using System;

namespace AlgoRay.Combinatorics
{
    public class NChooseKCount
    {
        public AlgorithmicResult<int> Run(int n, int k)
        {
            try
            {
                return Logic(n, k);
            }
            catch (Exception ex)
            {
                return new AlgorithmicResult<int>(default, ex.Message);
            }
        }

        public AlgorithmicResult<int> Logic(int n, int k)
        {
            var binom = GetBinom(n, k);

            return new AlgorithmicResult<int>(binom);
        }

        private int GetBinom(int row, int col)
        {
            if (row <= 1 || col == 0 || col == row)
            {
                return 1;
            }

            return GetBinom(row - 1, col - 1) + GetBinom(row - 1, col);
        }
    }
}
