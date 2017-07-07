/*
198	House Robber
easy, dp
You are a professional robber planning to rob houses along a street. Each house has a certain amount of money stashed, the only constraint stopping you from robbing each of them is that adjacent houses have security system connected and it will automatically contact the police if two adjacent houses were broken into on the same night.

Given a list of non-negative integers representing the amount of money of each house, determine the maximum amount of money you can rob tonight without alerting the police.
*/
using System;

namespace Demo
{
    public partial class Solution
    {
        public int Rob(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            if (nums.Length == 1)
            {
                return nums[0];
            }

            int[] dp = new int[nums.Length];
            dp[0] = nums[0];
            dp[1] = Math.Max(dp[0], nums[1]);
            for (int i = 2; i < nums.Length; i++)
            {
                // don't rub + rub
                dp[i] = Math.Max(dp[i - 1], dp[i - 2] + nums[i]);
            }

            return dp[nums.Length - 1];
        }

        public int Rob2(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            if (nums.Length == 1)
            {
                return nums[0];
            }
            
            int p2 = nums[0];
            int p1 = Math.Max(p2, nums[1]);
            int c = p1;
            
            for (int i = 2; i < nums.Length; i++)
            {
                c = Math.Max(p1, p2 + nums[i]);
                p2 = p1;
                p1 = c;
            }

            return c;
        }

        public int Rob3(int[] nums)
        {
            int a = 0;
            int b = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (i % 2 == 0)
                {
                    a = Math.Max(a + nums[i], b);
                }
                else
                {
                    b = Math.Max(a, b + nums[i]);
                }
            }

            return Math.Max(a, b);
        }
    }
}
