/*
easy, dp
Note: This is an extension of House Robber.

After robbing those houses on that street, the thief has found himself a new place for his thievery so that he will not get too much attention. This time, all houses at this place are arranged in a circle. That means the first house is the neighbor of the last one. Meanwhile, the security system for these houses remain the same as for those in the previous street.

Given a list of non-negative integers representing the amount of money of each house, determine the maximum amount of money you can rob tonight without alerting the police.
*/
using System;

namespace Demo
{
    public partial class Solution
    {
        public void Test_Rob4()
        {
            Rob4(new[] {2, 1, 1, 2});
        }

        public int Rob4(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            if (nums.Length == 1)
            {
                return nums[0];
            }

            return Math.Max(Rob4(nums, true), Rob4(nums, false));
        }

        public int Rob4(int[] nums, bool robfirst)
        {
            int p2 = robfirst ? nums[0] : 0;
            int p1 = Math.Max(p2, nums[1]);
            int c = p1;

            int lasthouse = robfirst ? nums.Length - 2 : nums.Length - 1;
            for (int i = 2; i <= lasthouse; i++)
            {
                c = Math.Max(p1, p2 + nums[i]);
                p2 = p1;
                p1 = c;
            }

            return c;
        }

        public int Rob22(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            if (nums.Length == 1)
            {
                return nums[0];
            }

            return Math.Max(Rob22(nums, 0, nums.Length - 1), Rob22(nums, 1, nums.Length));
        }
        private int Rob22(int[] nums, int left, int right)
        {
            int p2 = nums[left];
            int p1 = Math.Max(p2, nums[left+1]);
            int c = p1;

            for (int i = 2; i <= right; i++)
            {
                c = Math.Max(p1, p2 + nums[i]);
                p2 = p1;
                p1 = c;
            }

            return c;
        }
    }
}
