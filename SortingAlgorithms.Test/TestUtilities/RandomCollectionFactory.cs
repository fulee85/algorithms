using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms.Test.TestUtilities
{
    public static class RandomCollectionFactory
    {
        internal static int[] CreateRandomIntArray(int size)
        {
            var randGen = new Random();
            var arrayOfInt = new int[size];
            for (int i = 0; i < size; i++)
            {
                arrayOfInt[i] = randGen.Next();
            }
            return arrayOfInt;
        }
    }
}
