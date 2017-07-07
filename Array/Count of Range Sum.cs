﻿/*
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
            long[] sums = new long[n + 1];
            for (int i = 0; i < n; ++i)
            {
                sums[i + 1] = sums[i] + nums[i];
            }
            int ans = 0;
            for (int i = 0; i < n; ++i)
            {
                for (int j = i + 1; j <= n; ++j)
                {
                    if (sums[j] - sums[i] >= lower && sums[j] - sums[i] <= upper)
                    {
                        ans++;
                    }
                }
            }
            return ans;
        }

        public int CountRangeSum2(int[] nums, int lower, int upper)
        {
            int n = nums.Length;
            long[] sums = new long[n + 1];
            for (int i = 0; i < n; ++i)
            {
                sums[i + 1] = sums[i] + nums[i];
            }

            return CountWhileMergeSort(sums, 0, n + 1, lower, upper);
        }

        private int CountWhileMergeSort(long[] sums, int start, int end, int lower, int upper)
        {
            if (end - start <= 1) return 0;
            int mid = (start + end) / 2;
            int count = CountWhileMergeSort(sums, start, mid, lower, upper)
                      + CountWhileMergeSort(sums, mid, end, lower, upper);
            int j = mid, k = mid;

            // count the number of rang start with i,
            for (int i = start, r = 0; i < mid; ++i, ++r)
            {
                while (k < end && sums[k] - sums[i] < lower) k++;
                while (j < end && sums[j] - sums[i] <= upper) j++;
                count += j - k;
            }

            int t = mid;
            long[] cache = new long[end - start];
            for (int i = start, r = 0; i < mid; ++i, ++r)
            {
                while (t < end && sums[t] < sums[i]) cache[r++] = sums[t++];
                cache[r] = sums[i];
            }
            Array.Copy(cache, 0, sums, start, t - start);
            return count;
        }
    }
}