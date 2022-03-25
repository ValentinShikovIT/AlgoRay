using AlgoRay.SearchingAndSortingAlgorithms;
using AlgoRay.UnitTests.Helpers;
using AlgoRay.UnitTests.Setups;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace AlgoRay.UnitTests.SearchingAndSortingTests
{
    [TestClass]
    public class BinarySearchTests
    {
        [TestMethod]
        public void BinarySearchShould_FindElementInSortedCollection()
        {
            //Arrange
            var dummyInput = DummyInputs.BinarySearch_1;
            var searchedItem = dummyInput.First();
            var expectedIndex = dummyInput.IndexOf(searchedItem);

            //Act
            var testResult = TestRunner.RunTest(() =>
            {
                return BinarySearchIterative.Run(dummyInput, searchedItem);
            },
            1000m);

            //Assert
            Assert.IsTrue(testResult.IsSuccessful, TestMessages.MaximumAllowedTimeExceeded);
            Assert.AreEqual(testResult.Value, expectedIndex);
        }

        [TestMethod]
        public void TestShouldFail()
        {
            Assert.IsFalse(true);
        }
    }
}
