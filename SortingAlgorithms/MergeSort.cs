using SortingAlgorithms.Extensions;
using System;
using System.Collections.Generic;

namespace SortingAlgorithms
{
    public static class MergeSort
    {
        /// <summary>
        /// Sorting an array not descending order with merge sort algorithm.
        /// </summary>
        /// <typeparam name="T">Implements IComparable</typeparam>
        /// <param name="list">Array to sort</param>
        /// <returns>The sorted array</returns>
        public static IList<T> Sort<T>(IList<T> list, Order order = Order.Ascending) where T : IComparable<T>
        {
            Func<T, T, bool> compFunc = GetOrderFunc<T>((lval, rval) => lval?.CompareTo(rval) ?? -1, order);
            return MergeSortAlgorithm(list, 0, list.Count, compFunc);
        }

        /// <summary>
        /// Sorting an array not descending order with merge sort algorithm.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">Array to sort</param>
        /// <param name="comparer">Comparer object</param>
        /// <returns>The sorted array</returns>
        public static IList<T> Sort<T>(IList<T> list, IComparer<T> comparer, Order order = Order.Ascending)
        {
            if (comparer is null) throw new ArgumentNullException(nameof(comparer));

            Func<T, T, bool> compFunc = GetOrderFunc<T>(comparer.Compare, order);
            return MergeSortAlgorithm(list, 0, list.Count, compFunc);
        }

        private static Func<T, T, bool> GetOrderFunc<T>(Func<T, T, int> compareFunc, Order order)
        {
            switch (order)
            {
                case Order.Descending:
                    return (ls, rs) => compareFunc(ls, rs) > 0;
                default:
                case Order.Ascending:
                    return (ls, rs) => compareFunc(ls, rs) < 0;
            }
        }

        /// <summary>
        /// Sort an object which implement IList interface
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">Object which implements IList of T</param>
        /// <param name="startIndex">The start indexof the sortable list</param>
        /// <param name="endIndex">The after the last index of the list</param>
        /// <param name="compareFunc">Function which decides an order between two object of type T</param>
        /// <returns></returns>
        private static IList<T> MergeSortAlgorithm<T>(IList<T> list, int startIndex, int endIndex, Func<T, T, bool> compareFunc)
        {
            if (1 < endIndex - startIndex)
            {
                var middleIndex = (endIndex + startIndex) / 2;
                MergeSortAlgorithm(list, startIndex, middleIndex, compareFunc);
                MergeSortAlgorithm(list, middleIndex, endIndex, compareFunc);
                Merge(list, startIndex, middleIndex, endIndex, compareFunc);
            }
            return list;
        }

        private static void Merge<T>(IList<T> list, int startIndex, int middleIndex, int endIndex, Func<T, T, bool> compareFunc)
        {
            var firstHalfCount = middleIndex - startIndex;
            var firstHalf = list.SubList(startIndex, firstHalfCount);
            int i = startIndex, j = 0, k = middleIndex;
            while ( i < endIndex && j < firstHalf.Count && k < endIndex)
            {
                if (compareFunc(firstHalf[j], list[k]))
                {
                    list[i++] = firstHalf[j++];
                }
                else
                {
                    list[i++] = list[k++];                   
                }
            }            
            while (j < firstHalf.Count)
            {
                list[i++] = firstHalf[j++];
            }           
        }
    }
}
