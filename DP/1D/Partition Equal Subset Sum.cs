﻿/*
416	Partition Equal Subset Sum
Given a non-empty array containing only positive integers, find if the array can be partitioned into two subsets such that the sum of elements in both subsets is equal.

Note:
Each of the array element will not exceed 100.
The array size will not exceed 200.
Example 1:

Input: [1, 5, 11, 5]

Output: true

Explanation: The array can be partitioned as [1, 5, 5] and [11].
Example 2:

Input: [1, 2, 3, 5]

Output: false

Explanation: The array cannot be partitioned into equal sum subsets.
*/

using System.Collections;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;

namespace Demo
{
    public partial class Solution
    {
        public bool CanPartition(int[] nums)
        {
            int sum = nums.Sum();
            if (sum%2 == 1)
            {
                return false;
            }

            int target = sum / 2;
            
            // if there is sum of array is target
            var dp = new bool[target + 1];
            dp[0] = true;
            foreach (int n in nums)
            {
                for (int j = target; j >= n; --j)
                {
                    dp[j] = dp[j] || dp[j - n];
                }
            }

            return dp[target];
        }

        public bool CanPartition2(int[] nums)
        {
            var bits = new BitVector32(0);
            int sum = nums.Sum();
            foreach (int num in nums)
            {
                // bits |= bits << num;
            }
            return (sum % 2 == 0) && bits[sum >> 1];
        }
    }
}
