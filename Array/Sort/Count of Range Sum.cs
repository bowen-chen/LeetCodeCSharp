/*
327	Count of Range Sum
hard, revisit
Given an integer array nums, return the number of range sums that lie in [lower, upper] inclusive.
Range sum S(i, j) is defined as the sum of the elements in nums between indices i and j (i ≤ j), inclusive.

Note:
A naive algorithm of O(n2) is trivial. You MUST do better than that.

Example:
Given nums = [-2, 5, -1], lower = -2, upper = 2,
Return 3.
The three ranges are : [0, 0], [2, 2], [0, 2] and their respective sums are: -2, -1, 2.
*/

using System;

namespace Demo
{
    public partial class Solution
    {
        public int CountRangeSum(int[] nums, int lower, int upper)
        {
            int n = nums.Length;

            // sums[0] = 0, to make code simpler
            long[] sums = new long[n + 1];
            for (int i = 0; i < n; ++i)
            {
                sums[i + 1] = sums[i] + nums[i];
            }

            return CountWhileMergeSort(sums, 0, n, lower, upper);
        }

        // merge sort [start, end]
        private int CountWhileMergeSort(long[] sums, int start, int end, int lower, int upper)
        {
            // sort
            if (start >= end)
            {
                return 0;
            }

            int mid = start + (end - start) / 2;
            int count = CountWhileMergeSort(sums, start, mid, lower, upper)
                        + CountWhileMergeSort(sums, mid + 1, end, lower, upper);
           
            // count the number of rang start with i,
            // end with [j, k)
            for (int i = start, j = mid + 1, k = mid + 1; i <= mid; ++i)
            {
                while (j <= end && sums[j] - sums[i] < lower) j++;
                while (k <= end && sums[k] - sums[i] <= upper) k++;

                // i can pair wiht (j, k]
                count += k - j;
            }

            // merge
            long[] cache = new long[end - start + 1];
            for (int i = start, j = mid + 1, r = 0; i <= mid || j <= end;)
            {
                if (i <= mid && j <= end)
                {
                    cache[r++] = sums[i] < sums[j] ? sums[i++] : sums[j++];
                }
                else
                {
                    cache[r++] = i <= mid ? sums[i++] : sums[j++];
                }
            }

            Array.Copy(cache, 0, sums, start, end - start + 1);
            return count;
        }
    }
}
