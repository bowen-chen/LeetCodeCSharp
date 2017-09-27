/*
628. Maximum Product of Three Numbers
*
Given an integer array, find three numbers whose product is maximum and output the maximum product.

Example 1:
Input: [1,2,3]
Output: 6
Example 2:
Input: [1,2,3,4]
Output: 24
Note:
The length of the given array will be in range [3,104] and all elements are in the range [-1000, 1000].
Multiplication of any three numbers in the input won't exceed the range of 32-bit signed integer.
*/

using System;
using Demo.Common;

namespace Demo
{
    public partial class Solution
    {
        public int MaximumProduct(int[] nums)
        {
            int n = nums.Length;
            Array.Sort(nums);
            int c1 = nums[0]*nums[1]*nums[n - 1]; // when half negative and half positive
            int c2 = nums[n - 1]*nums[n - 2]*nums[n - 3]; // when all negative or all positve
            return Math.Max(c1, c2);
        }

        public int MaximumProduct2(int[] nums)
        {
            var minTop3 = new PriorityQueue<int>();
            var maxBottom2 = new PriorityQueue<int>();

            for (int i = 0; i < 3; i++)
            {
                minTop3.Push(-nums[i]);
                maxBottom2.Push(nums[i]);
            }

            maxBottom2.Pop();

            for (int i = 3; i < nums.Length; i++)
            {
                if (-nums[i] < minTop3.Top())
                {
                    minTop3.Pop();
                    minTop3.Push(-nums[i]);
                }

                if (nums[i] < maxBottom2.Top())
                {
                    maxBottom2.Pop();
                    maxBottom2.Push(nums[i]);
                }
            }

            var top3 = new[] {-minTop3.Pop(), -minTop3.Pop(), -minTop3.Pop()};
            var bottom2 = new[] {maxBottom2.Pop(), maxBottom2.Pop()};
            int c1 = bottom2[0]*bottom2[1]*top3[2]; // when half negative and half positive
            int c2 = top3[0]*top3[1]*top3[2]; // when all negative or all positve
            return Math.Max(c1, c2);
        }
    }
}
