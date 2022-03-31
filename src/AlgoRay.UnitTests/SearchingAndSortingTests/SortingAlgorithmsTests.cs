using AlgoRay.SearchingSortingAndGreedyAlgorithms.SearchingAndSorting;
using AlgoRay.UnitTests.Helpers;
using AlgoRay.UnitTests.Setups;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AlgoRay.UnitTests.SearchingAndSortingTests
{
    [TestClass]
    public class SortingAlgorithmsTests
    {
        private static IList<int> unsortedData;

        [TestInitialize]
        public void ResetInputData()
        {
            unsortedData = new List<int>(DummyInputs.UnsortedDummyData_Small);
        }

        [TestMethod]
        public void BubbleSort_ShouldSortElements_Correctly()
        {
            //Arrange
            //Act
            var result = TestRunner.RunTest(() =>
            {
                return BubbleSortIterative.Run(unsortedData);
            },
            500m);

            Assert.IsTrue(result.IsInTimeLimit, TestMessages.MaximumAllowedTimeExceeded);
            Assert.IsTrue(result.Value.IsSuccessful);
        }
    }
}
