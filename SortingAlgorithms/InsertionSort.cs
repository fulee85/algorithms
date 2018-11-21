using System;
using System.Collections.Generic;

namespace SortingAlgorithms
{
    public static class InsertionSort
    {
        /// <summary>
        /// Sorting an array not descending order with insertion sort algorithm.
        /// </summary>
        /// <typeparam name="T">Implements IComparable</typeparam>
        /// <param name="list">Array to sort</param>
        /// <returns>The sorted array</returns>
        public static IList<T> Sort<T>(IList<T> list, Order order = Order.Ascending) where T : IComparable<T>
        {
            Func<T, T, bool> compFunc = GetOrderFunc<T>((lval, rval) => lval?.CompareTo(rval) ?? -1, order);
            return InsertionSortAlgorithm(list, compFunc);
        }

        /// <summary>
        /// Sorting an array not descending order with insertion sort algorithm.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">Array to sort</param>
        /// <param name="comparer">Comparer object</param>
        /// <returns>The sorted array</returns>
        public static IList<T> Sort<T>(IList<T> list, IComparer<T> comparer, Order order = Order.Ascending)
        {
            if (comparer is null) throw new ArgumentNullException(nameof(comparer));

            Func<T, T, bool> compFunc = GetOrderFunc<T>(comparer.Compare, order);
            return InsertionSortAlgorithm(list, compFunc);
        }

        private static Func<T,T,bool> GetOrderFunc<T>(Func<T, T, int> compareFunc, Order order)
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
        
        private static IList<T> InsertionSortAlgorithm<T>(IList<T> list, Func<T,T,bool> compareFunc)
        {
            for (int j = 1; j < list.Count; j++)
            {
                var key = list[j];
                int i = j;
                while (0 <= --i && compareFunc(key, list[i]))
                {
                    list[i + 1] = list[i];
                }
                list[i + 1] = key;
            }
            return list;
        }
    }
}
