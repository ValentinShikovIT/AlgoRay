using AlgoRay.Combinatorics;
using AlgoRay.UnitTests.Helpers;
using AlgoRay.UnitTests.Setups.Dummies;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AlgoRay.UnitTests.Combinatorics
{
    [TestClass]
    public class CombinatoricsTests : TestBase
    {
        [TestMethod]
        public void PermutationsWithoutRepetition_ShouldGetAllPermutations_Correctly()
        {
            //Arrange
            var tests = new (string[] Input, List<string[]> ExpectedOutput)[]
                {
                    CombinatoricsDummies.Permutations.Test_WithoutRepetition
                };

            //Act
            foreach(var (Input, Expected) in tests)
            {
                var testOutput = TestRunner.RunTest(() =>
                {
                    return new PermutationsWithoutRepetitions<string>()
                    .Run(Input);
                },
                100);

                AssertTestResultFromTestRunningResponse(testOutput, Expected);
            }
        }

        [TestMethod]
        public void PermutationsWithRepetition_ShouldGetAllPermutations_Correctly()
        {
            //Arrange
            var tests = new (string[] Input, List<string[]> ExpectedOutput)[]
                {
                    CombinatoricsDummies.Permutations.Test_WithRepetition
                };

            //Act
            foreach (var (Input, Expected) in tests)
            {
                var testOutput = TestRunner.RunTest(() =>
                {
                    return new PermutationsWithRepetitions<string>()
                    .Run(Input);
                },
                100);

                AssertTestResultFromTestRunningResponse(testOutput, Expected);
            }
        }

        [TestMethod]
        public void VariationsWithoutRepetition_ShouldGetAllVariations_Correctly()
        {
            //Arrange
            var tests = new (string[] Input, int LengthOfVariationWithoutRepetitions, List<string[]> Expected)[]
                {
                    CombinatoricsDummies.Variations.Test_WithoutRepetition
                };

            //Act
            foreach (var (Input, LengthOfVariationWithoutRepetitions, Expected) in tests)
            {
                var testOutput = TestRunner.RunTest(() =>
                {
                    return new VariationsWithoutRepetitions<string>()
                    .Run(Input, LengthOfVariationWithoutRepetitions);
                },
                100);

                AssertTestResultFromTestRunningResponse(testOutput, Expected);
            }
        }

        [TestMethod]
        public void VariationsWithRepetition_ShouldGetAllVariations_Correctly()
        {
            //Arrange
            var tests = new (string[] Input, int LengthOfVariationWithRepetitions, List<string[]> Expected)[]
                 {
                    CombinatoricsDummies.Variations.Test_WithRepetition
                 };

            //Act
            foreach (var (Input, LengthOfVariationWithRepetitions, Expected) in tests)
            {
                var testOutput = TestRunner.RunTest(() =>
                {
                    return new VariationsWithRepetitions<string>()
                    .Run(Input, LengthOfVariationWithRepetitions);
                },
                100);

                AssertTestResultFromTestRunningResponse(testOutput, Expected);
            }
        }

        [TestMethod]
        public void CombinationsWithoutRepetition_ShouldGetAllCombinations_Correctly()
        {
            //Arrange
            var tests = new (string[] Input, int LengthOfCombinationsWithoutRepetitions, List<string[]> Expected)[]
                 {
                    CombinatoricsDummies.Combinations.Test_WithoutRepetition
                 };


            //Act
            foreach (var (Input, LengthOfCombinationsWithoutRepetitions, Expected) in tests)
            {
                var testOutput = TestRunner.RunTest(() =>
                {
                    return new CombinationsWithoutRepetitions<string>()
                    .Run(Input, LengthOfCombinationsWithoutRepetitions);
                },
                100);

                AssertTestResultFromTestRunningResponse(testOutput, Expected);
            }
        }

        [TestMethod]
        public void CombinationsWithRepetition_ShouldGetAllCombinations_Correctly()
        {
            //Arrange
            var tests = new (string[] Input, int LengthOfCombinationsWithRepetitions, List<string[]> Expected)[]
                 {
                    CombinatoricsDummies.Combinations.Test_WithRepetition
                 };


            //Act
            foreach (var (Input, LengthOfCombinationsWithRepetitions, Expected) in tests)
            {
                var testOutput = TestRunner.RunTest(() =>
                {
                    return new CombinationsWithRepetitions<string>()
                    .Run(Input, LengthOfCombinationsWithRepetitions);
                },
                100);

                AssertTestResultFromTestRunningResponse(testOutput, Expected);
            }
        }

        [TestMethod]
        public void NChooseKCount_ShouldGetBinom_Correctly()
        {
            //Arrange
            var tests = new (int N, int K, int Expected)[]
            {
                CombinatoricsDummies.NChooseKCountBinom.Test_1,
                CombinatoricsDummies.NChooseKCountBinom.Test_2
            };

            //Act
            foreach (var (N, K, Expected) in tests)
            {
                var testOutput = TestRunner.RunTest(() =>
                {
                    return new NChooseKCount()
                    .Run(N, K);
                },
                100);

                AssertTestResultFromTestRunningResponse(testOutput, Expected);
            }
        }
    }
}
