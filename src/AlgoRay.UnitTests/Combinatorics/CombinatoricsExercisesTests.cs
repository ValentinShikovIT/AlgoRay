﻿using AlgoRay.Combinatorics.Exercises;
using AlgoRay.UnitTests.Helpers;
using AlgoRay.UnitTests.Setups.Dummies;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

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

            var outputs = new string[][]
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

                AssertTestResultFromTestRunningResponse(testOutput, outputs[test]);
            }
        }

        [TestMethod]
        public void NestedLoopsToRecursion_ShouldCreateIntegerLoops_Correctly()
        {
            // Arrange
            var input = CombinatoricsDummies.NestedLoopsToRecursion.InputNumberOfLoops_1;
            var output = CombinatoricsDummies.NestedLoopsToRecursion.ExpectedLoops_1;

            // Act
            var testOutput = TestRunner.RunTest(() =>
            {
                return NestedLoopsToRecursion
                .Run(input);
            },
            100);

            AssertTestResultFromTestRunningResponse(testOutput, output);
        }
    }
}
