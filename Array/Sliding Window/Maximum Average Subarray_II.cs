/*
644. Maximum Average Subarray II
hard, revist
Given an array consisting of n integers, find the contiguous subarray whose length is greater than or equal to k that has the maximum average value. And you need to output the maximum average value.

Example 1:
Input: [1,12,-5,-6,50,3], k = 4
Output: 12.75
Explanation:
when length is 5, maximum average value is 10.8,
when length is 6, maximum average value is 9.16667.
Thus return 12.75.
Note:
1 <= k <= n <= 10,000.
Elements of the given array will be in range [-10,000, 10,000].
The answer with the calculation error less than 10-5 will be accepted.
*/

using System;
using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public double FindMaxAverage2(int[] nums, int k)
        {
            int n = nums.Length;
            var sums = new int[n + 1];
            for (int i = 0; i < n; i++)
            {
                sums[i + 1] = sums[i] + nums[i];
            }

            // hull[x] = i, i  is the left boundary of the window
            // i to j is at least k
            var hull = new List<int>();
            double ans = double.MinValue;
            for (int j = k - 1; j < n; j++)
            {
                while (hull.Count >= 2 &&
                       GetAverage(sums, hull[hull.Count - 2], hull[hull.Count - 1] - 1)
                       >= GetAverage(sums, hull[hull.Count - 2], j - k))
                {
                    hull.RemoveAt(hull.Count - 1);
                }

                hull.Add(j - k + 1);
                while (hull.Count >= 2 &&
                    GetAverage(sums, hull[0], hull[1] - 1) <= GetAverage(sums, hull[0], j))
                {
                    hull.RemoveAt(0);
                }

                ans = Math.Max(ans, GetAverage(sums, hull[0], j));
            }

            return ans;
        }

        private double GetAverage(int[] sums, int i, int j)
        {
            return (double)(sums[j + 1] - sums[i]) / (j - i + 1);
        }
    }
}
