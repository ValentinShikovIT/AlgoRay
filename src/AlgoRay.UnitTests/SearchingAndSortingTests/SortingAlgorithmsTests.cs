using AlgoRay.SearchingSortingAndGreedyAlgorithms.SearchingAndSorting;
using AlgoRay.UnitTests.Helpers;
using AlgoRay.UnitTests.Setups.Dummies;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace AlgoRay.UnitTests.SearchingAndSortingTests
{
    [TestClass]
    public class SortingAlgorithmsTests : TestBase
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

            sortedInputData_Small = unsortedInputData_Small.OrderBy(x => x).ToList();
            sortedInputData_Medium = unsortedInputData_Medium.OrderBy(x => x).ToList();
            sortedInputData_Large = unsortedInputData_Large.OrderBy(x => x).ToList();
        }

        [TestMethod]
        public void BubbleSort_ShouldSortElements_Correctly()
        {
            //Arrange
            //Act
            var result = TestRunner.RunTest(() =>
            {
                return new BubbleSortIterative().Run(unsortedInputData_Small);
            },
            400);

            AssertTestResultFromTestRunningResponse(result, sortedInputData_Small);
        }

        [TestMethod]
        [ProjectorTimeOut(10_000)]
        public void BubbleSort_ShouldSortElements_Correctly_WithMediumData()
        {
            //Arrange
            //Act
            var result = TestRunner.RunTest(() =>
            {
                return new BubbleSortIterative().Run(unsortedInputData_Medium);
            },
            8_000);

            AssertTestResultFromTestRunningResponse(result, sortedInputData_Medium);
        }

        [TestMethod]
        public void InsertionSort_ShouldSortElements_Correctly()
        {
            //Arrange
            //Act
            var result = TestRunner.RunTest(() =>
            {
                return new InsertionSortIterative().Run(unsortedInputData_Small);
            },
            400);

            AssertTestResultFromTestRunningResponse(result, sortedInputData_Small);
        }

        [TestMethod]
        [ProjectorTimeOut(8_000)]
        public void InsertionSort_ShouldSortElements_Correctly_WithMediumData()
        {
            //Arrange
            //Act
            var result = TestRunner.RunTest(() =>
            {
                return new InsertionSortIterative().Run(unsortedInputData_Medium);
            },
            6_000);

            AssertTestResultFromTestRunningResponse(result, sortedInputData_Medium);
        }

        [TestMethod]
        public void MergeSort_ShouldSortElements_Correctly()
        {
            //Arrange
            var inputDataAsArray = unsortedInputData_Large.ToArray();

            //Act
            var result = TestRunner.RunTest(() =>
            {
                return new MergeSortRecursive().Run(inputDataAsArray);
            },
            100);

            AssertTestResultFromTestRunningResponse(result, sortedInputData_Large);
        }

        [TestMethod]
        public void QuickSort_ShouldSortElements_Correctly()
        {
            //Arrange
            //Act
            var result = TestRunner.RunTest(() =>
            {
                return new QuickSortRecursive().Run(unsortedInputData_Large);
            },
            100);

            AssertTestResultFromTestRunningResponse(result, sortedInputData_Large);
        }
    }
}
