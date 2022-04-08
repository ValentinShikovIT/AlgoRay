using AlgoRay.Combinatorics;
using AlgoRay.UnitTests.Helpers;
using AlgoRay.UnitTests.Setups.Dummies;
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
                CombinatoricsDummies.Permutations.RandomStringsFor_PermutationWithoutRepetitionTest_1
            };

            var outputs = new List<string[]>[]
            {
                CombinatoricsDummies.Permutations.Expected_PermutationWithoutRepetition_1
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

                AssertTestResultFromTestRunningResponse(testOutput, outputs[test]);
            }
        }

        [TestMethod]
        public void PermutationsWithRepetition_ShouldGetAllPermutations_Correctly()
        {
            //Arrange
            var inputs = new string[][]
            {
                CombinatoricsDummies.Permutations.RandomStringsFor_PermutationWithRepetitionTest_1
            };

            var outputs = new List<string[]>[]
            {
                CombinatoricsDummies.Permutations.Expected_PermutationWithRepetition_1
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

                AssertTestResultFromTestRunningResponse(testOutput, outputs[test]);
            }
        }

        [TestMethod]
        public void VariationsWithoutRepetition_ShouldGetAllVariations_Correctly()
        {
            //Arrange
            var inputs = new string[][]
            {
                CombinatoricsDummies.Variations.RandomStringsFor_VariationWithoutRepetitionTest_1
            };

            var outputs = new List<string[]>[]
            {
                CombinatoricsDummies.Variations.Expected_VariationWithoutRepetition_1
            };

            var lengthOfVariation = CombinatoricsDummies
                .Variations
                .LengthOfVariationWithoutRepetitions_1;

            //Act
            for (int test = 0; test < inputs.Length; test++)
            {
                var testOutput = TestRunner.RunTest(() =>
                {
                    return VariationsWithoutRepetitions<string>
                    .Run(inputs[test], lengthOfVariation);
                },
                100);

                AssertTestResultFromTestRunningResponse(testOutput, outputs[test]);
            }
        }

        [TestMethod]
        public void VariationsWithRepetition_ShouldGetAllVariations_Correctly()
        {
            //Arrange
            var inputs = new string[][]
            {
                CombinatoricsDummies.Variations.RandomStringsFor_VariationWithRepetitionTest_1
            };

            var outputs = new List<string[]>[]
            {
                CombinatoricsDummies.Variations.Expected_VariationWithRepetition_1
            };

            var lengthOfVariation = CombinatoricsDummies
                .Variations
                .LengthOfVariationWithRepetitions_1;

            //Act
            for (int test = 0; test < inputs.Length; test++)
            {
                var testOutput = TestRunner.RunTest(() =>
                {
                    return VariationsWithRepetitions<string>
                    .Run(inputs[test], lengthOfVariation);
                },
                100);

                AssertTestResultFromTestRunningResponse(testOutput, outputs[test]);
            }
        }

        [TestMethod]
        public void CombinationsWithoutRepetition_ShouldGetAllCombinations_Correctly()
        {
            //Arrange
            var inputs = new string[][]
            {
                CombinatoricsDummies.Combinations.RandomStringsFor_CombinationWithoutRepetitionTest_1
            };

            var outputs = new List<string[]>[]
            {
                CombinatoricsDummies.Combinations.Expected_CombinationWithoutRepetition_1
            };

            var lengthOfVariation = CombinatoricsDummies
                .Combinations
                .LengthOfCombinationWithoutRepetitions_1;

            //Act
            for (int test = 0; test < inputs.Length; test++)
            {
                var testOutput = TestRunner.RunTest(() =>
                {
                    return CombinationsWithoutRepetitions<string>
                    .Run(inputs[test], lengthOfVariation);
                },
                100);

                AssertTestResultFromTestRunningResponse(testOutput, outputs[test]);
            }
        }

        [TestMethod]
        public void CombinationsWithRepetition_ShouldGetAllCombinations_Correctly()
        {
            //Arrange
            var inputs = new string[][]
            {
                CombinatoricsDummies.Combinations.RandomStringsFor_CombinationWithRepetitionTest_1
            };

            var outputs = new List<string[]>[]
            {
                CombinatoricsDummies.Combinations.Expected_CombinationWithRepetition_1
            };

            var lengthOfVariation = CombinatoricsDummies
                .Combinations
                .LengthOfCombinationWithRepetitions_1;

            //Act
            for (int test = 0; test < inputs.Length; test++)
            {
                var testOutput = TestRunner.RunTest(() =>
                {
                    return CombinationsWithRepetitions<string>
                    .Run(inputs[test], lengthOfVariation);
                },
                100);

                AssertTestResultFromTestRunningResponse(testOutput, outputs[test]);
            }
        }

        [TestMethod]
        public void NChooseKCount_ShouldGetBinom_Correctly()
        {
            //Arrange
            var inputs = new int[][]
            {
                new int[] {CombinatoricsDummies.NChooseKCountBinom.Choice_1_For_N,
                            CombinatoricsDummies.NChooseKCountBinom.Choice_1_For_K},

                new int[] {CombinatoricsDummies.NChooseKCountBinom.Choice_2_For_N,
                            CombinatoricsDummies.NChooseKCountBinom.Choice_2_For_K},
            };

            var outputs = new int[]
            {
                CombinatoricsDummies.NChooseKCountBinom.ExpectedFromTest_1,
                CombinatoricsDummies.NChooseKCountBinom.ExpectedFromTest_2
            };

            var lengthOfVariation = CombinatoricsDummies
                .Combinations
                .LengthOfCombinationWithRepetitions_1;

            //Act
            for (int test = 0; test < inputs.Length; test++)
            {
                var n = inputs[test][0];
                var k = inputs[test][1];

                var testOutput = TestRunner.RunTest(() =>
                {
                    return NChooseKCount
                    .Run(n, k);
                },
                100);

                AssertTestResultFromTestRunningResponse(testOutput, outputs[test]);
            }
        }
    }
}
