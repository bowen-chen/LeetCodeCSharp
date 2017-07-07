/*
16	3Sum Closest
easy, high/low
Given an array S of n integers, find three integers in S such that the sum is closest to a given number, target. Return the sum of the three integers. You may assume that each input would have exactly one solution.

    For example, given array S = {-1 2 1 -4}, and target = 1.

    The sum that is closest to the target is 2. (-1 + 2 + 1 = 2).
*/
using System;

namespace Demo
{
    public partial class Solution
    {
        public int ThreeSumClosest(int[] nums, int target)
        {
            int ret = 0;
            Array.Sort(nums);

            for (int i = 0; i < nums.Length && i < 3; i++)
            {
                ret += nums[i];
            }

            if (nums.Length <= 3)
            {
                return ret;
            }

            for (int i = 0; i < nums.Length - 2; i++)
            {
                int lo = i + 1, hi = nums.Length - 1;
                while (lo < hi)
                {
                    var cur = nums[i] + nums[lo] + nums[hi];
                    if (cur == target)
                    {
                        return cur;
                    }

                    if (Math.Abs(cur - target) < Math.Abs(ret - target))
                    {
                        ret = cur;
                    }

                    if (cur < target)
                    {
                        lo++;
                    }
                    else
                    {
                        hi--;
                    }
                }
            }
            return ret;
        }
    }
}
