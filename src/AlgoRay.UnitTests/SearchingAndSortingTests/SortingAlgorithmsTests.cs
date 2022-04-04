using AlgoRay.SearchingSortingAndGreedyAlgorithms.SearchingAndSorting;
using AlgoRay.UnitTests.Helpers;
using AlgoRay.UnitTests.Setups;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace AlgoRay.UnitTests.SearchingAndSortingTests
{
    [TestClass]
    public class SortingAlgorithmsTests
    {
        private static IList<int> unsortedInputData_Small;
        private static IList<int> unsortedInputData_Medium;
        private static IList<int> unsortedInputData_Large;

        [TestInitialize]
        public void ResetInputData()
        {
            unsortedInputData_Small = new List<int>(DummyInputs.UnsortedDummyData_Small);
            unsortedInputData_Medium = new List<int>(DummyInputs.UnsortedDummyData_Medium);
            unsortedInputData_Large = new List<int>(DummyInputs.UnsortedDummyData_Big);
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
            400m);

            Assert.IsTrue(result.IsInTimeLimit, TestMessages.MaximumAllowedTimeExceeded);
            Assert.IsTrue(result.Value.IsSuccessful);
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
            8_000m);

            Assert.IsTrue(result.IsInTimeLimit, TestMessages.MaximumAllowedTimeExceeded);
            Assert.IsTrue(result.Value.IsSuccessful);
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
            400m);

            Assert.IsTrue(result.IsInTimeLimit, TestMessages.MaximumAllowedTimeExceeded);
            Assert.IsTrue(result.Value.IsSuccessful);
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
            100m);

            Assert.IsTrue(result.IsInTimeLimit, TestMessages.MaximumAllowedTimeExceeded);
            Assert.IsTrue(result.Value.IsSuccessful);
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
            100m);

            Assert.IsTrue(result.IsInTimeLimit, TestMessages.MaximumAllowedTimeExceeded);
            Assert.IsTrue(result.Value.IsSuccessful);
        }
    }
}
