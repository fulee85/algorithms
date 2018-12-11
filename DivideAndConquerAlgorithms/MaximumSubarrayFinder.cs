using System;

namespace DivideAndConquerAlgorithms
{
    public static class MaximumSubarrayFinder
    {
        public static (int startIndex, int endIndex, int sum) LinearFindMaximumSubarray(int[] array)
        {
            if (array is null || array.Length == 0) return (-1, -1, -1);
            int maxSum = array[0];
            int maxStart = 0, maxEnd = 0;
            int midSum = array[0];
            int midMaxStart = 0;
            for (int i = 1; i < array.Length; i++)
            {
                if (midSum < 0)
                {
                    midSum = array[i];
                    midMaxStart = i;
                }
                else
                {
                    midSum = midSum + array[i];
                }

                if (midSum > maxSum)
                {
                    maxSum = midSum;
                    maxStart = midMaxStart;
                    maxEnd = i;
                }
            }
            return (maxStart, maxEnd, maxSum);
        }

        public static (int startIndex, int endIndex, int sum) FindMaximumSubarray(int[] array, int low, int high)
        {
            if (low == high)
            {
                return (low, high, array[low]);
            }

            int mid = (low + high) / 2;
            var (leftLow, leftHigh, leftSum) = FindMaximumSubarray(array, low, mid);
            var (rightLow, rightHigh, rightSum) = FindMaximumSubarray(array, mid + 1, high);
            var (crossLow, crossHigh, crossSum) = FindMaxCrossingSubarray(array, low, mid, high);

            if (leftSum >= rightSum && leftSum >= crossSum)
            {
                return (leftLow, leftHigh, leftSum);
            }
            else if (rightSum > leftSum && rightSum > crossSum)
            {
                return (rightLow, rightHigh, rightSum);
            }
            return (crossLow, crossHigh, crossSum);
        }

        private static (int maxLeft, int maxRight, int maxSum) FindMaxCrossingSubarray(int[] list, int lowIndex, int midIndex, int highIndex)
        {
            int maxLeft = midIndex, maxRight = midIndex + 1;

            var leftSum = int.MinValue;
            var sum = 0;
            for (int i = midIndex; i >= lowIndex; i--)
            {
                sum += list[i];
                if (sum > leftSum)
                {
                    leftSum = sum;
                    maxLeft = i;
                }
            }

            var rightSum = int.MinValue;
            sum = 0;
            for (int i = midIndex + 1; i <= highIndex; i++)
            {
                sum += list[i];
                if (sum > rightSum)
                {
                    rightSum = sum;
                    maxRight = i;
                }
            }

            return (maxLeft, maxRight, leftSum + rightSum);
        }
    }
}
