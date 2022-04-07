using System.Collections.Generic;

namespace AlgoRay.UnitTests.Setups
{
    internal class DummyOutputs
    {
        public static List<string[]> Expected_PermutationWithoutRepetition_1 { get; } = new List<string[]>
        {
            new string[] {"A", "B", "C"},
            new string[] {"A", "C", "B"},
            new string[] {"B", "A", "C"},
            new string[] {"B", "C", "A"},
            new string[] {"C", "A", "B"},
            new string[] {"C", "B", "A"},
        };
    }
}
