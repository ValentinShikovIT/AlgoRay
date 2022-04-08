using AlgoRay.Combinatorics;
using AlgoRay.UnitTests.Helpers;
using AlgoRay.UnitTests.Setups;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AlgoRay.UnitTests.Combinatorics
{
    [TestClass]
    public class CombinatoricsTests : CollectionsTest
    {
        [TestMethod]
        public void PermutationsWithoutRepetition_ShouldGetAllPermutations_Correctly()
        {
            //Arrange
            var inputs = new string[][]
            {
                DummyInputs.RandomStringsFor_PermutationWithoutRepetitionTest_1
            };

            var outputs = new List<string[]>[]
            {
                DummyOutputs.Expected_PermutationWithoutRepetition_1
            };

            //Act
            for (int test = 0; test < inputs.Length; test++)
            {
                var testOutput = TestRunner.RunTest(() =>
                {
                    return PermutationsWithoutRepetitions<string>
                    .Run(inputs[test]);
                },
                100);

                AssertTestResultFromAlgorithmicResponse(testOutput, outputs[test]);
            }
        }

        [TestMethod]
        public void PermutationsWithRepetition_ShouldGetAllPermutations_Correctly()
        {
            //Arrange
            var inputs = new string[][]
            {
                DummyInputs.RandomStringsFor_PermutationWithRepetitionTest_1
            };

            var outputs = new List<string[]>[]
            {
                DummyOutputs.Expected_PermutationWithRepetition_1
            };

            //Act
            for (int test = 0; test < inputs.Length; test++)
            {
                var testOutput = TestRunner.RunTest(() =>
                {
                    return PermutationsWithRepetitions<string>
                    .Run(inputs[test]);
                },
                100);

                AssertTestResultFromAlgorithmicResponse(testOutput, outputs[test]);
            }
        }
    }
}
