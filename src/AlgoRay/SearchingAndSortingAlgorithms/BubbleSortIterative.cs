using AlgoRay.Helpers;
using System;
using System.Collections.Generic;

namespace AlgoRay.SearchingSortingAndGreedyAlgorithms.SearchingAndSorting
{
    public class BubbleSortIterative
    {
        public AlgorithmicResult<IList<T>> Run<T>(IList<T> inputElements)
            where T : IComparable
        {
            try
            {
                return Logic(inputElements);
            }
            catch (Exception ex)
            {
                return new AlgorithmicResult<IList<T>>(default, ex.Message);
            }
        }

        public AlgorithmicResult<IList<T>> Logic<T>(IList<T> inputElements)
            where T : IComparable
        {
            for (int i = 0; i < inputElements.Count; i++)
            {
                var isSorted = true;

                for (int j = 0; j < inputElements.Count - 1 - i; j++)
                {
                    if (inputElements[j].CompareTo(inputElements[j + 1]) == 1)
                    {
                        isSorted = false;
                        (inputElements[j + 1], inputElements[j]) = (inputElements[j], inputElements[j + 1]);
                    }
                }

                if (isSorted)
                {
                    break;
                }
            }

            return new AlgorithmicResult<IList<T>>(inputElements);
        }
    }
}