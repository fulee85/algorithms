using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortingAlgorithms.Comparers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms.Test
{
    [TestClass]
    public class MergeSortTests
    {
        [TestMethod]
        public void SortIntegers()
        {
            var integers = new[] { 0, 3, 7, 4, 2, 1 };
            var expected = new[] { 0, 1, 2, 3, 4, 7 };
            MergeSort.Sort(integers);
            integers.SequenceEqual(expected).Should().BeTrue();
        }

        [TestMethod]
        public void SortDescending()
        {
            var integers = new[] { 0, 3, 7, 4, 2, 1 };
            var expected = new[] { 7, 4, 3, 2, 1, 0 };
            MergeSort.Sort(integers, Order.Descending);
            integers.SequenceEqual(expected).Should().BeTrue();
        }

        [TestMethod]
        public void SortEmptyArray()
        {
            var integers = new int[] { };
            var expected = new int[] { };
            MergeSort.Sort(integers);
            integers.SequenceEqual(expected).Should().BeTrue();
        }

        [TestMethod]
        public void SortOneElementArray()
        {
            var integers = new int[] { 3 };
            var expected = new int[] { 3 };
            MergeSort.Sort(integers);
            integers.SequenceEqual(expected).Should().BeTrue();
        }

        [TestMethod]
        public void SortStrings()
        {
            var strings = new[] { "", "abc", "zzz", "efg", "a", "ccc" };
            var expected = new[] { "", "a", "abc", "ccc", "efg", "zzz" };
            MergeSort.Sort(strings);
            strings.SequenceEqual(expected).Should().BeTrue();
        }

        [TestMethod]
        public void SortStringsWithNull()
        {
            var strings = new[] { "", "abc", null, "efg", "aaa", "ccc" };
            var expected = new[] { null, "", "aaa", "abc", "ccc", "efg" };
            MergeSort.Sort(strings);
            strings.SequenceEqual(expected).Should().BeTrue();
        }

        [TestMethod]
        public void SortListWithNullableValues()
        {
            var integers = new List<int?> { null, 3, 5, 4, 2, null };
            var expected = new List<int?> { null, null, 2, 3, 4, 5 };
            MergeSort.Sort(integers, new NullableComparer<int>());
            integers.SequenceEqual(expected).Should().BeTrue();
        }
    }
}
