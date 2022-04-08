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

                AssertTestResultFromAlgorithmicResponse(testOutput, outputs[test]);
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

                AssertTestResultFromAlgorithmicResponse(testOutput, outputs[test]);
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

                AssertTestResultFromAlgorithmicResponse(testOutput, outputs[test]);
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

                AssertTestResultFromAlgorithmicResponse(testOutput, outputs[test]);
            }
        }
    }
}
