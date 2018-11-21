namespace DivideAndConquerAlgorithms
{
    public static class MaximumSubarrayFinder
    {
        public static (int startIndex, int endIndex, int sum) FindMaximumSubarray(int[] list, int low, int high)
        {
            if (low == high)
            {
                return (low, high, list[low]);
            }

            int mid = (low + high) / 2;
            var (leftLow, LeftHigh, leftSum) = FindMaximumSubarray(list, low, mid);
            var (rightLow, rightHigh, rightSum) = FindMaximumSubarray(list, mid + 1, high);
            var (crossLow, crossHigh, crossSum) = FindMaxCrossingSubarray(list, low, mid, high);

            if (leftSum > rightSum && leftSum > crossSum)
            {
                return (leftLow, LeftHigh, leftSum);
            }
            else if (rightSum > leftSum && rightSum > crossSum)
            {
                return (rightLow, rightHigh, rightSum);
            }
            return (crossLow, crossHigh, crossSum);
        }

        private static (int maxLeft, int maxRight, int maxSum) FindMaxCrossingSubarray(int[] list, int lowIndex, int midIndex, int highIndex)
        {
            int maxLeft = midIndex, maxRight = midIndex;

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
