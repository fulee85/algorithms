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
    public class NullableComparerTests
    {
        [TestMethod]
        public void CompareNullableIntegersNullNull()
        {
            int? x = null;
            int? y = null;
            var comparer = new NullableComparer<int>();
            comparer.Compare(x, y).Should().Be(0);
        }

        [TestMethod]
        public void CompareNullableIntegersNotNullNull()
        {
            int? x = 3;
            int? y = null;
            var comparer = new NullableComparer<int>();
            comparer.Compare(x, y).Should().Be(1);
        }

        [TestMethod]
        public void CompareNullableIntegersNullNotNull()
        {
            int? x = null;
            int? y = 3;
            var comparer = new NullableComparer<int>();
            comparer.Compare(x, y).Should().Be(-1);
        }

        [TestMethod]
        public void CompareNullableIntegersNotNullNotNull()
        {
            int? x = 1;
            int? y = 3;
            var comparer = new NullableComparer<int>();
            comparer.Compare(x, y).Should().Be(-1);
        }
    }
}
