using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortingAlgorithms.Comparers;
using System.Collections.Generic;
using System.Linq;

namespace SortingAlgorithms.Test
{
    [TestClass]
    public class InsertionSortTests
    {
        [TestMethod]
        public void SortIntegers()
        {
            var integers = new[] { 0, 3, 7, 4, 2, 1 };
            var expected = new[] { 0, 1, 2, 3, 4, 7 };
            InsertionSort.Sort(integers);
            integers.SequenceEqual(expected).Should().BeTrue();
        }

        [TestMethod]
        public void SortDescending()
        {
            var integers = new[] { 0, 3, 7, 4, 2, 1 };
            var expected = new[] { 7, 4, 3, 2, 1, 0 };
            InsertionSort.Sort(integers, Order.Descending);
            integers.SequenceEqual(expected).Should().BeTrue();
        }

        [TestMethod]
        public void SortEmptyArray()
        {
            var integers = new int[] { };
            var expected = new int[] { };
            InsertionSort.Sort(integers);
            integers.SequenceEqual(expected).Should().BeTrue();
        }

        [TestMethod]
        public void SortOneElementArray()
        {
            var integers = new int[] { 3 };
            var expected = new int[] { 3 };
            InsertionSort.Sort(integers);
            integers.SequenceEqual(expected).Should().BeTrue();
        }

        [TestMethod]
        public void SortStrings()
        {
            var strings = new[] { "", "abc", "zzz", "efg", "a", "ccc" };
            var expected = new[] { "", "a", "abc", "ccc", "efg", "zzz" };
            InsertionSort.Sort(strings);
            strings.SequenceEqual(expected).Should().BeTrue();
        }

        [TestMethod]
        public void SortStringsWithNull()
        {
            var strings = new[] { "", "abc", null, "efg", "aaa", "ccc" };
            var expected = new[] { null, "", "aaa", "abc", "ccc", "efg" };
            InsertionSort.Sort(strings);
            strings.SequenceEqual(expected).Should().BeTrue();
        }

        [TestMethod]
        public void SortListWithNullableValues()
        {
            var integers = new List<int?> { null, 3, 5, 4, 2, null };
            var expected = new List<int?> { null, null, 2, 3, 4, 5 };
            InsertionSort.Sort(integers, new NullableComparer<int>());
            integers.SequenceEqual(expected).Should().BeTrue();
        }
    }
}
