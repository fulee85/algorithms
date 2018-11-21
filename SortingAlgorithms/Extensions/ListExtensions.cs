using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms.Extensions
{
    internal static class ListExtensions
    {
        internal static List<T> SubList<T>(this IList<T> list, int from, int count)
        {
            var sub = new List<T>(count);
            for (int i = 0; i < count; i++)
            {
                sub.Add(list[from + i]);
            }
            return sub;
        }
    }
}
