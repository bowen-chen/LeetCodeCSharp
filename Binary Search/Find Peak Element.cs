/*
162. Find Peak Element
medium, math, highlow
A peak element is an element that is greater than its neighbors.

Given an input array where num[i] ≠ num[i+1], find a peak element and return its index.

The array may contain multiple peaks, in that case return the index to any one of the peaks is fine.

You may imagine that num[-1] = num[n] = -∞.

For example, in array [1, 2, 3, 1], 3 is a peak element and your function should return the index number 2.

click to show spoilers.

Note:
Your solution should be in logarithmic complexity.
*/

namespace Demo
{
    public partial class Solution
    {
        public int FindPeakElement(int[] nums)
        {
            int low = 0;
            int high = nums.Length - 1;
            while (low < high)
            {
                int mid1 = (low + high) / 2;
                int mid2 = mid1 + 1;
                if (nums[mid1] < nums[mid2])
                {
                    // there is peak on right side
                    // 1. if keep increasing, then Peak is high
                    // 2. if has a dip at i, then Peak is i-1
                    low = mid2;
                }
                else
                {
                    // there is peak on left side
                    // 1. if keep decreasing, then peak is low
                    // 2. if has a dip at i, then it is i+1
                    high = mid1;
                }
            }

            return low;
        }
    }
}
