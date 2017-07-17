/*
560. Subarray Sum Equals K
easy
Given an array of integers and an integer k, you need to find the total number of continuous subarrays whose sum equals to k.

Example 1:
Input:nums = [1,1,1], k = 2
Output: 2
Note:
The length of the array is in range [1, 20,000].
The range of numbers in the array is [-1000, 1000] and the range of the integer k is [-1e7, 1e7].
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public int SubarraySum(int[] nums, int k)
        {
            int res = 0;
            int sum = 0;
            // empty array sum is 0
            var m = new Dictionary<int, int> { { 0, 1 } };
            foreach (int n in nums)
            {
                sum += n;
                if (m.ContainsKey(sum - k))
                {
                    res += m[sum - k];
                }

                if (!m.ContainsKey(sum))
                {
                    m[sum] = 0;
                }

                ++m[sum];
            }

            return res;
        }
    }
}
