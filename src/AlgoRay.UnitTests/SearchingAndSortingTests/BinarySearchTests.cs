using AlgoRay.SearchingAndSortingAlgorithms;
using AlgoRay.UnitTests.Helpers;
using AlgoRay.UnitTests.Setups;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace AlgoRay.UnitTests.SearchingAndSortingTests
{
    [TestClass]
    public class BinarySearchTests
    {
        private static IList<int> dummyInput;

        [ClassInitialize]
        public void SetupDummyData()
        {
            dummyInput = DummyInputs.BinarySearch_1;
        }

        [TestMethod]
        public void BinarySearchIterative_ShouldFindElementInSortedCollection_WhenElementExists()
        {
            //Arrange
            var searchedItem = dummyInput.First();
            var expectedIndex = dummyInput.IndexOf(searchedItem);

            //Act
            var testResult = TestRunner.RunTest(() =>
            {
                return BinarySearchIterative.Run(dummyInput, searchedItem);
            },
            200m);

            //Assert
            Assert.IsTrue(testResult.IsInTimeLimit, TestMessages.MaximumAllowedTimeExceeded);
            Assert.AreEqual(testResult.Value, expectedIndex);
        }

        [TestMethod]
        public void BinarySearchIterative_ShouldReturnMinusOne_WhenElementIsNotFound()
        {
            //Arrange
            var searchedItem = 51_000;
            var expectedIndex = -1;

            //Act
            var testResult = TestRunner.RunTest(() =>
            {
                return BinarySearchIterative.Run(dummyInput, searchedItem);
            },
            200m);

            //Assert
            Assert.IsTrue(testResult.IsInTimeLimit, TestMessages.MaximumAllowedTimeExceeded);
            Assert.AreEqual(testResult.Value, expectedIndex);
        }

        [TestMethod]
        public void BinarySearchRecursive_ShouldFindElementInSortedCollection_WhenElementExists()
        {
            //Arrange
            var searchedItem = dummyInput.First();
            var expectedIndex = dummyInput.IndexOf(searchedItem);

            //Act
            var testResult = TestRunner.RunTest(() =>
            {
                return BinarySearchRecursive.Run(dummyInput, searchedItem);
            },
            200m);

            //Assert
            Assert.IsTrue(testResult.IsInTimeLimit, TestMessages.MaximumAllowedTimeExceeded);
            Assert.AreEqual(testResult.Value, expectedIndex);
        }

        [TestMethod]
        public void BinarySearchRecursive_ShouldReturnMinusOne_WhenElementIsNotFound()
        {
            //Arrange
            var searchedItem = 51_000;
            var expectedIndex = -1;

            //Act
            var testResult = TestRunner.RunTest(() =>
            {
                return BinarySearchRecursive.Run(dummyInput, searchedItem);
            },
            200m);

            //Assert
            Assert.IsTrue(testResult.IsInTimeLimit, TestMessages.MaximumAllowedTimeExceeded);
            Assert.AreEqual(testResult.Value, expectedIndex);
        }
    }
}
