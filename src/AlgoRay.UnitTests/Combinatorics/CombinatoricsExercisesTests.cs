using AlgoRay.Combinatorics.Exercises;
using AlgoRay.UnitTests.Helpers;
using AlgoRay.UnitTests.Setups.Dummies;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AlgoRay.UnitTests.Combinatorics
{
    [TestClass]
    public class CombinatoricsExercisesTests : CollectionsTest
    {
        [TestMethod]
        public void ReverseArrayByRecursion_ShouldReturnReversedArray_Correctly()
        {
            // Arrange
            var inputs = new string[][]
            {
                CombinatoricsDummies.ReverseArrayByRecursion.InputStrings_1,
                CombinatoricsDummies.ReverseArrayByRecursion.InputStrings_2
            };

            var expectedOutputs = new string[][]
            {
                CombinatoricsDummies.ReverseArrayByRecursion.ExpectedNumbers_1,
                CombinatoricsDummies.ReverseArrayByRecursion.ExpectedStrings_2
            };

            // Act
            for (int test = 0; test < inputs.Length; test++)
            {
                var testOutput = TestRunner.RunTest(() =>
                {
                    return ReverseArrayByRecursion<string>
                    .Run(inputs[test]);
                },
                100);

                AssertTestResultFromTestRunningResponse(testOutput, expectedOutputs[test]);
            }
        }

        [TestMethod]
        public void NestedLoopsToRecursion_ShouldCreateIntegerLoops_Correctly()
        {
            // Arrange
            var input = CombinatoricsDummies.NestedLoopsToRecursion.InputNumberOfLoops_1;
            var expectedOutput = CombinatoricsDummies.NestedLoopsToRecursion.ExpectedLoops_1;

            // Act
            var testOutput = TestRunner.RunTest(() =>
            {
                return NestedLoopsToRecursion
                .Run(input);
            },
            100);

            AssertTestResultFromTestRunningResponse(testOutput, expectedOutput);
        }

        [TestMethod]
        public void ConnectedAreaInMatrix_ShouldReturn_ExpectedResult()
        {
            // Arrange
            var input = CombinatoricsDummies.ConnectedAreasInMatrix.InputMatrix_1;
            var expectedOutput = CombinatoricsDummies.ConnectedAreasInMatrix.ExpectedResult_1;

            // Act
            var testOutput = TestRunner.RunTest(() =>
            {
                return ConnectedAreaInAMatrix
                .Run(input);
            },
            100);

            AssertTestResultFromTestRunningResponse(testOutput, expectedOutput);
        }

        [TestMethod]
        public void Cinema_ShouldReturn_ExpectedResult()
        {
            // Arrange
            var test1Inputs = new object[]
            {
                CombinatoricsDummies.Cinema.InputNames_Test1,
                CombinatoricsDummies.Cinema.PlaceChanging_Test1
            };

            var test2Inputs = new object[]
            {
                CombinatoricsDummies.Cinema.InputNames_Test2,
                CombinatoricsDummies.Cinema.PlaceChanging_Test2
            };

            var test1Outputs = new object[]
            {
                CombinatoricsDummies.Cinema.Expected_Test1
            };

            var test2Outputs = new object[]
            {
                CombinatoricsDummies.Cinema.Expected_Test2
            };

            var tests = new Dictionary<object[], object[]>()
            {
                { test1Inputs, test1Outputs },
                { test2Inputs, test2Outputs }
            };

            // Act
            foreach (var test in tests)
            {
                var firstParam = (IList<string>)test.Key[0];
                var secondParam = (IDictionary<string, int>)test.Key[1];

                var expectedOutput = (IList<string[]>)test.Value[0];

                var testOutput = TestRunner.RunTest(() =>
                {
                    return Cinema
                    .Run(firstParam, secondParam);
                },
                100);

                AssertTestResultFromTestRunningResponse(testOutput, expectedOutput, false, false);
            }
        }

        [TestMethod]
        public void SchoolTeams_ShouldReturn_ExpectedResult()
        {
            // Arrange
            var test1Inputs = new object[]
            {
                CombinatoricsDummies.SchoolTeams.GirlNamesInput_test1,
                CombinatoricsDummies.SchoolTeams.BoyNamesInput_test1
            };

            var test2Inputs = new object[]
            {
                CombinatoricsDummies.SchoolTeams.GirlNamesInput_test2,
                CombinatoricsDummies.SchoolTeams.BoyNamesInput_test2
            };

            var test1Outputs = new object[]
            {
                CombinatoricsDummies.SchoolTeams.Expected_test1
            };

            var test2Outputs = new object[]
            {
                CombinatoricsDummies.SchoolTeams.Expected_test2
            };

            var tests = new Dictionary<object[], object[]>()
            {
                { test1Inputs, test1Outputs },
                { test2Inputs, test2Outputs }
            };

            // Act
            foreach (var test in tests)
            {
                var firstParam = (IList<string>)test.Key[0];
                var secondParam = (IList<string>)test.Key[1];

                var expectedOutput = (IList<string[]>)test.Value[0];

                var testOutput = TestRunner.RunTest(() =>
                {
                    return SchoolTeams
                    .Run(firstParam, secondParam);
                },
                100);

                AssertTestResultFromTestRunningResponse(testOutput, expectedOutput, false, false);
            }
        }
    }
}
