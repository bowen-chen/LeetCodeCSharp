/*
410. Split Array Largest Sum
Given an array which consists of non-negative integers and an integer m, you can split the array into m non-empty continuous subarrays. Write an algorithm to minimize the largest sum among these m subarrays.

Note:
If n is the length of array, assume the following constraints are satisfied:

1 ≤ n ≤ 1000
1 ≤ m ≤ min(50, n)
Examples:

Input:
nums = [7,2,5,10,8]
m = 2

Output:
18

Explanation:
There are four ways to split nums into two subarrays.
The best way is to split it into [7,2,5] and [10,8],
where the largest sum among the two subarrays is only 18.
*/

using System;

namespace Demo
{
    public partial class Solution
    {
        public int SplitArray(int[] nums, int m)
        {
            // dp[i,j] the min larget sum, when split j parts from [0, i]
            var dp = new int[nums.Length, m];
            var sum = new int[nums.Length + 1];
            for (int i = 0; i < nums.Length; i++)
            {
                sum[i + 1] = sum[i] + nums[i];
                dp[i, 1] = sum[i + 1];
            }

            // Sum[i->j] = sum[j+1]-sum[i]
            // Sum[2,3] = sum[4] - sum[2]

            for (int k = 2; k <= m; k++)
            {
                for (int i = nums.Length - 1; i >= 0; i--)
                {
                    dp[i, m] = int.MaxValue;

                    // make a array from [j+1 to i] 
                    for (int j = i - 1; j >= k - 2; j--)
                    {
                        // when maxvalue, means [0, j] cannot be split as k-1 parts
                        if (dp[j, k-1] != int.MaxValue)
                        {
                            // sum[j+1->i]= sum[i+1]-sum[j+1]
                            dp[i,k] = Math.Min(dp[i,k], Math.Max(dp[j,k-1], sum[i + 1] - sum[j + 1]));
                        }
                    }
                }
            }

            return dp[nums.Length - 1, m];
        }

        public int SplitArray2(int[] nums, int m)
        {
            var dp = new int[nums.Length];
            var sum = new int[nums.Length + 1];
            for (int i = 0; i < nums.Length; i++)
            {
                sum[i + 1] = sum[i] + nums[i];
                dp[i] = sum[i + 1];
            }

            // Sum[i->j] = sum[j+1]-sum[i]
            // Sum[2,3] = sum[4] - sum[2]

            for (int k = 2; k <= m; k++)
            {
                for (int i = nums.Length -1; i >= 0 ; i--)
                {
                    dp[i] = int.MaxValue;
                    for (int j = i - 1; j >= k - 2; j--)
                    {
                        if (dp[j] != int.MaxValue)
                        {
                            // sum[j+1->i]= sum[i+1]-sum[j+1]
                            dp[i] = Math.Min(dp[i], Math.Max(dp[j], sum[i+1] - sum[j+1]));
                        }
                    }
                }
            }

            return dp[nums.Length - 1];
        }
    }
}
