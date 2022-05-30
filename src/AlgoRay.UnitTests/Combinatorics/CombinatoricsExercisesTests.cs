using AlgoRay.Combinatorics.Exercises;
using AlgoRay.UnitTests.Helpers;
using AlgoRay.UnitTests.Setups.Dummies;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace AlgoRay.UnitTests.Combinatorics
{
    [TestClass]
    public class CombinatoricsExercisesTests : TestBase
    {
        [TestMethod]
        public void ReverseArrayByRecursion_ShouldReturnReversedArray_Correctly()
        {
            // Arrange
            var tests = new (string[] Input, string[] Expected)[]
            {
                CombinatoricsDummies.ReverseArrayByRecursion.Test_1,
                CombinatoricsDummies.ReverseArrayByRecursion.Test_2
            };

            // Act
            foreach (var (Input, Expected) in tests)
            {
                var testOutput = TestRunner.RunTest(() =>
                {
                    return new ReverseArrayByRecursion<string>()
                    .Run(Input);
                },
                100);

                AssertTestResultFromTestRunningResponse(testOutput, Expected);
            }
        }

        [TestMethod]
        public void NestedLoopsToRecursion_ShouldCreateIntegerLoops_Correctly()
        {
            // Arrange
            var tests = new (int Input, IList<int[]> Expected)[]
            {
                CombinatoricsDummies.NestedLoopsToRecursion.Test_1
            };

            // Act
            foreach (var (Input, Expected) in tests)
            {
                var testOutput = TestRunner.RunTest(() =>
                {
                    return new NestedLoopsToRecursion()
                    .Run(Input);
                },
                100);

                AssertTestResultFromTestRunningResponse(testOutput, Expected);
            }
        }

        [TestMethod]
        public void ConnectedAreaInMatrix_ShouldReturn_ExpectedResult()
        {
            // Arrange
            var tests = new (char[,] InputMatrix, IList<string> Expected)[]
            {
                CombinatoricsDummies.ConnectedAreasInMatrix.Test_1
            };

            // Act
            foreach (var (Input, Expected) in tests)
            {
                var testOutput = TestRunner.RunTest(() =>
                {
                    return new ConnectedAreaInAMatrix()
                    .Run(Input);
                },
                100);

                AssertTestResultFromTestRunningResponse(testOutput, Expected);
            }
        }

        [TestMethod]
        public void Cinema_ShouldReturn_ExpectedResult()
        {
            // Arrange
            var tests = new (IList<string> Names, IDictionary<string, int> PlaceChanges, IList<string[]> Expected)[]
            {
                CombinatoricsDummies.Cinema.Test_1,
                CombinatoricsDummies.Cinema.Test_2
            };

            // Act
            foreach (var (Names, PlaceChanges, Expected) in tests)
            {
                var testOutput = TestRunner.RunTest(() =>
                {
                    return new Cinema()
                    .Run(Names, PlaceChanges);
                },
                100);

                var orderedExpected = Expected
                    .Select(combo => combo.OrderBy(name => name).ToArray())
                    .ToList();

                AssertTestResultFromTestRunningResponse(testOutput, orderedExpected);
            }
        }

        [TestMethod]
        public void SchoolTeams_ShouldReturn_ExpectedResult()
        {
            // Arrange
            var tests = new (IList<string> GirlNames, IList<string> BoyNames, IList<string[]> Expected)[]
            {
                CombinatoricsDummies.SchoolTeams.Test_1,
                CombinatoricsDummies.SchoolTeams.Test_2
            };

            // Act
            foreach (var (GirlNames, BoyNames, Expected) in tests)
            {
                var testOutput = TestRunner.RunTest(() =>
                {
                    return new SchoolTeams()
                    .Run(GirlNames, BoyNames);
                },
                100);

                AssertTestResultFromTestRunningResponse(testOutput, Expected);
            }
        }

        [TestMethod]
        public void WordCruncher_ShouldReturn_ExpectedResult()
        {
            // Arrange
            var tests = new (string[] WordParts, string Word, IList<string[]> Expected)[]
            {
                CombinatoricsDummies.WordCruncher.Test_1,
                CombinatoricsDummies.WordCruncher.Test_2,
                CombinatoricsDummies.WordCruncher.Test_3
            };

            // Act
            foreach (var (WordParts, Word, Expected) in tests)
            {
                var testOutput = TestRunner.RunTest(() =>
                {
                    return new WordCruncher()
                    .Run(WordParts, Word);
                },
                100);

                AssertTestResultFromTestRunningResponse(testOutput, Expected);
            }
        }
    }
}
