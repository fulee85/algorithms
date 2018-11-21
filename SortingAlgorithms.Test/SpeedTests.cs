using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortingAlgorithms.Test.TestUtilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms.Test
{
    [TestClass]
    public class SpeedTests
    {
        [TestMethod]
        public void InsertionSortSpeedTest()
        {
            var count = 10_000;
            var stopwatch = new Stopwatch();
            var arrayToSort = RandomCollectionFactory.CreateRandomIntArray(count);
            stopwatch.Start();
            InsertionSort.Sort(arrayToSort);
            stopwatch.Stop();
            Console.WriteLine("Insertion sort {0} elements time: {1} ms", count, stopwatch.ElapsedMilliseconds);
        }

        [TestMethod]
        public void MergeSortSpeedTest()
        {
            var count = 10_000;
            var stopwatch = new Stopwatch();
            var arrayToSort = RandomCollectionFactory.CreateRandomIntArray(count);
            stopwatch.Start();
            MergeSort.Sort(arrayToSort);
            stopwatch.Stop();
            Console.WriteLine("Insertion sort {0} elements time: {1} ms", count, stopwatch.ElapsedMilliseconds);
        }      
    }
}
