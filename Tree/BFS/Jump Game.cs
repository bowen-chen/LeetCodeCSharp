/*
55 Jump Game
easy, *
Given an array of non-negative integers, you are initially positioned at the first index of the array.

Each element in the array represents your maximum jump length at that position.

Determine if you are able to reach the last index.

For example:
A = [2,3,1,1,4], return true.

A = [3,2,1,0,4], return false.
*/

using System;

namespace Demo
{
    public partial class Solution
    {
        public bool CanJump(int[] nums)
        {
            int last = 0;
            for (int i = 0; last < nums.Length - 1 && i <= last; i++)
            {
                last = Math.Max(last, i + nums[i]);
            }

            return last >= nums.Length - 1;
        }
    }
}
