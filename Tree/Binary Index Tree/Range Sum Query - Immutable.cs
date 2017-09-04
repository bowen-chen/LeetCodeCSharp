﻿/*
303	Range Sum Query - Immutable
easy, *
Given an integer array nums, find the sum of the elements between indices i and j (i ≤ j), inclusive.

Example:
Given nums = [-2, 0, 3, -5, 2, -1]

sumRange(0, 2) -> 1
sumRange(2, 5) -> -1
sumRange(0, 5) -> -3
Note:
You may assume that the array does not change.
There are many calls to sumRange function.
*/
namespace Demo
{
    public class NumArray2
    {
        readonly int[] nums;

        public NumArray2(int[] nums)
        {
            for (int i = 1; i < nums.Length; i++)
            {
                nums[i] += nums[i - 1];
            }
            this.nums = nums;
        }

        public int SumRange(int i, int j)
        {
            if (i == 0)
            {
                return nums[j];
            }

            return nums[j] - nums[i - 1];
        }
    }
}
