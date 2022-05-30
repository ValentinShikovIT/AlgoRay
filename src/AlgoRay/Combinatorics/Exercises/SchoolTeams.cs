using AlgoRay.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoRay.Combinatorics.Exercises
{
    public class SchoolTeams
    {
        private IList<string> _girlNames = new List<string>();
        private IList<string> _boysNames = new List<string>();
        private readonly string[] result = new string[5];

        private readonly IList<string[]> outputResults = new List<string[]>();


        public AlgorithmicResult<IList<string[]>> Run(IList<string> girlNames, IList<string> boyNames)
        {
            try
            {
                return Logic(girlNames, boyNames);
            }
            catch (Exception ex)
            {
                return new AlgorithmicResult<IList<string[]>>(default, ex.Message);
            }
        }

        public AlgorithmicResult<IList<string[]>> Logic(IList<string> girlNames, IList<string> boyNames)
        {
            _girlNames = girlNames;
            _boysNames = boyNames;

            Combine(0, 0, 0);

            return new AlgorithmicResult<IList<string[]>>(outputResults);
        }

        private void Combine(int index, int startIndexGirl, int startIndexBoy)
        {
            if (index >= result.Length)
            {
                outputResults.Add(result.ToArray());
                return;
            }

            if (index < 3)
            {
                for (int i = startIndexGirl; i < _girlNames.Count; i++)
                {
                    result[index] = _girlNames[i];
                    Combine(index + 1, i + 1, startIndexBoy);
                }
            }
            else
            {
                for (int i = startIndexBoy; i < _boysNames.Count; i++)
                {
                    result[index] = _boysNames[i];
                    Combine(index + 1, startIndexGirl, i + 1);
                }
            }
        }
    }
}
