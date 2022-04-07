using AlgoRay.Combinatorics;
using AlgoRay.UnitTests.Helpers;
using AlgoRay.UnitTests.Setups;
using DeepEqual.Syntax;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AlgoRay.UnitTests.Combinatorics
{
    [TestClass]
    public class CombinatoricsTests
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
                var output = TestRunner.RunTest(() =>
                {
                    return PermutationsWithoutRepetitions<string>
                    .Run(inputs[test]);
                },
                100);

                Assert.IsTrue(output.IsInTimeLimit, TestMessages.MaximumAllowedTimeExceeded);
                Assert.IsTrue(output.Value.IsSuccessful);

                outputs[test].ShouldDeepEqual(output.Value.AlgorithmResult);
            }
        }

    }
}
