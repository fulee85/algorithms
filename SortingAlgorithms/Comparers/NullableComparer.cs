using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms.Comparers
{
    public class NullableComparer<T> : IComparer<T?> where T : struct, IComparable<T>
    {
        /// <summary>
        /// Compares nullable values. Null value comes before everything except null equals to null.
        /// </summary>
        public int Compare(T? x, T? y)
        {
            if (x.HasValue)
            {
                if (y.HasValue)
                {
                    return x.Value.CompareTo(y.Value);
                }
                return 1;
            }
            if (y.HasValue)
            {
                return -1;
            }
            return 0;
        }
    }
}
