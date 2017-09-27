﻿/*
462. Minimum Moves to Equal Array Elements II
*
Given a non-empty integer array, find the minimum number of moves required to make all array elements equal, where a move is incrementing a selected element by 1 or decrementing a selected element by 1.

You may assume the array's length is at most 10,000.

Example:

Input:
[1,2,3]

Output:
2

Explanation:
Only two moves are needed (remember each move increments or decrements one element):

[1,2,3]  =>  [2,2,3]  =>  [2,2,2]
*/

using System;

namespace Demo
{
    public partial class Solution
    {
        public int MinMoves2(int[] nums)
        {
            // meeting point, meet in the median
            Array.Sort(nums);
            int res = 0;
            int i = 0;
            int j = nums.Length - 1;
            while (i < j)
            {
                res += nums[j--] - nums[i++];
            }

            return res;
        }
    }
}
