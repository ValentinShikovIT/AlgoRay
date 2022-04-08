using AlgoRay.SearchingSortingAndGreedyAlgorithms.SearchingAndSorting;
using AlgoRay.UnitTests.Helpers;
using AlgoRay.UnitTests.Setups.Dummies;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace AlgoRay.UnitTests.SearchingAndSortingTests
{
    [TestClass]
    public class SortingAlgorithmsTests : CollectionsTest
    {
        private static IList<int> unsortedInputData_Small;
        private static IList<int> unsortedInputData_Medium;
        private static IList<int> unsortedInputData_Large;

        private static IList<int> sortedInputData_Small;
        private static IList<int> sortedInputData_Medium;
        private static IList<int> sortedInputData_Large;

        [TestInitialize]
        public void ResetInputData()
        {
            unsortedInputData_Small = new List<int>(SortingAndBinarySearchDummies.Inputs.UnsortedDummyData_Small);
            unsortedInputData_Medium = new List<int>(SortingAndBinarySearchDummies.Inputs.UnsortedDummyData_Medium);
            unsortedInputData_Large = new List<int>(SortingAndBinarySearchDummies.Inputs.UnsortedDummyData_Big);

            sortedInputData_Small = new List<int>(SortingAndBinarySearchDummies.Outputs.SortedData_Small);
            sortedInputData_Medium = new List<int>(SortingAndBinarySearchDummies.Outputs.SortedData_Medium);
            sortedInputData_Large = new List<int>(SortingAndBinarySearchDummies.Outputs.SortedData_Large);
        }

        [TestMethod]
        public void BubbleSort_ShouldSortElements_Correctly()
        {
            //Arrange
            //Act
            var result = TestRunner.RunTest(() =>
            {
                return BubbleSortIterative.Run(unsortedInputData_Small);
            },
            400);

            AssertTestResultFromAlgorithmicResponse(result, sortedInputData_Small, false, false);
        }

        [TestMethod]
        [ProjectorTimeOut(10_000)]
        public void BubbleSort_ShouldSortElements_Correctly_WithMediumData()
        {
            //Arrange
            //Act
            var result = TestRunner.RunTest(() =>
            {
                return BubbleSortIterative.Run(unsortedInputData_Medium);
            },
            8_000);

            AssertTestResultFromAlgorithmicResponse(result, sortedInputData_Medium, false, false);
        }

        [TestMethod]
        public void InsertionSort_ShouldSortElements_Correctly()
        {
            //Arrange
            //Act
            var result = TestRunner.RunTest(() =>
            {
                return InsertionSortIterative.Run(unsortedInputData_Small);
            },
            400);

            AssertTestResultFromAlgorithmicResponse(result, sortedInputData_Small, false, false);
        }

        [TestMethod]
        [ProjectorTimeOut(8_000)]
        public void InsertionSort_ShouldSortElements_Correctly_WithMediumData()
        {
            //Arrange
            //Act
            var result = TestRunner.RunTest(() =>
            {
                return InsertionSortIterative.Run(unsortedInputData_Medium);
            },
            5_000);

            AssertTestResultFromAlgorithmicResponse(result, sortedInputData_Medium, false, false);
        }

        [TestMethod]
        public void MergeSort_ShouldSortElements_Correctly()
        {
            //Arrange
            var inputDataAsArray = unsortedInputData_Large.ToArray();

            //Act
            var result = TestRunner.RunTest(() =>
            {
                return MergeSortRecursive.Run(inputDataAsArray);
            },
            100);

            AssertTestResultFromAlgorithmicResponse(result, sortedInputData_Large, false, false);
        }

        [TestMethod]
        public void QuickSort_ShouldSortElements_Correctly()
        {
            //Arrange
            //Act
            var result = TestRunner.RunTest(() =>
            {
                return QuickSortRecursive.Run(unsortedInputData_Large);
            },
            100);

            AssertTestResultFromAlgorithmicResponse(result, sortedInputData_Large, false, false);
        }
    }
}
