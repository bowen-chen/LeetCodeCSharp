/*
561. Array Partition I
Given an array of 2n integers, your task is to group these integers into n pairs of integer, say (a1, b1), (a2, b2), ..., (an, bn) which makes sum of min(ai, bi) for all i from 1 to n as large as possible.

Example 1:
Input: [1,4,3,2]

Output: 4
Explanation: n is 2, and the maximum sum of pairs is 4.
Note:
n is a positive integer, which is in the range of [1, 10000].
All the integers in the array will be in the range of [-10000, 10000].
*/

using System;

namespace Demo
{
    public partial class Solution
    {
        public int ArrayPairSum(int[] nums)
        {
            int res = 0;
            int n = nums.Length;
            Array.Sort(nums);
            for (int i = 0; i < n; i += 2)
            {
                res += nums[i];
            }
            return res;
        }
    }
}
