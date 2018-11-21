using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DivideAndConquerAlgorithms.Test
{
    [TestClass]
    public class MaximumSubarrayFinderTest
    {
        [TestMethod]
        public void Test()
        {
            var array = new[] { 1, -2, 5, 8, -9, 12, -1 };
            var (startIndex, endIndex, sum) = MaximumSubarrayFinder.FindMaximumSubarray(array, 0, array.Length - 1);
            startIndex.Should().Be(2);
            endIndex.Should().Be(5);
            sum.Should().Be(16);
        }

        [TestMethod]
        public void TestMaxInFront()
        {
            var array = new[] { 10, 5, -5, 0, -5, 5 , 1 };
            var (startIndex, endIndex, sum) = MaximumSubarrayFinder.FindMaximumSubarray(array, 0, array.Length - 1);
            startIndex.Should().Be(0);
            endIndex.Should().Be(1);
            sum.Should().Be(15);
        }

        [TestMethod]
        public void TestMaxInEnd()
        {
            var array = new[] { 10, 5, -15, 0, -5, 5, 15 };
            var (startIndex, endIndex, sum) = MaximumSubarrayFinder.FindMaximumSubarray(array, 0, array.Length - 1);
            startIndex.Should().Be(5);
            endIndex.Should().Be(6);
            sum.Should().Be(20);
        }

        [TestMethod]
        public void TestEqualValueSubarraysExists()
        {
            var array = new[] { 10, 5, -15, 0, -5, -5, 15 };
            var (startIndex, endIndex, sum) = MaximumSubarrayFinder.FindMaximumSubarray(array, 0, array.Length - 1);
            sum.Should().Be(15);
        }

        [TestMethod]
        public void TestMaxInTheWayEnd()
        {
            var array = new[] { 10, 5, -15, 0, -5, -5, 50 };
            var (startIndex, endIndex, sum) = MaximumSubarrayFinder.FindMaximumSubarray(array, 0, array.Length - 1);
            startIndex.Should().Be(6);
            endIndex.Should().Be(6);
            sum.Should().Be(50);
        }

        [TestMethod]
        public void TestMaxInTheWayFirst()
        {
            var array = new[] { 50, -50, -15, 0, -5, -5, 10 };
            var (startIndex, endIndex, sum) = MaximumSubarrayFinder.FindMaximumSubarray(array, 0, array.Length - 1);
            startIndex.Should().Be(0);
            endIndex.Should().Be(0);
            sum.Should().Be(50);
        }
    }
}
