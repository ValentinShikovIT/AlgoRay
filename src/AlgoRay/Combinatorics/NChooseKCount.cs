using AlgoRay.Helpers;

namespace AlgoRay.Combinatorics
{
    public class NChooseKCount
    {
        public static AlgorithmicResult<int> Run(int n, int k)
        {
            var binom = GetBinom(n, k);

            return new AlgorithmicResult<int>(binom, true);
        }

        private static int GetBinom(int row, int col)
        {
            if (row <= 1 || col == 0 || col == row)
            {
                return 1;
            }

            return GetBinom(row - 1, col - 1) + GetBinom(row - 1, col);
        }
    }
}
