﻿/*
456. 132 Pattern
revisit
Given a sequence of n integers a1, a2, ..., an, a 132 pattern is a subsequence ai, aj, ak such that i < j < k and ai < ak < aj. Design an algorithm that takes a list of n numbers as input and checks whether there is a 132 pattern in the list.

Note: n will be less than 15,000.

Example 1:
Input: [1, 2, 3, 4]

Output: False

Explanation: There is no 132 pattern in the sequence.
Example 2:
Input: [3, 1, 4, 2]

Output: True

Explanation: There is a 132 pattern in the sequence: [1, 4, 2].
Example 3:
Input: [-1, 3, 2, 0]

Output: True

Explanation: There are three 132 patterns in the sequence: [-1, 3, 2], [-1, 3, 0] and [-1, 2, 0].


*/

using System;
using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public bool Find132pattern(int[] nums)
        {
            // the min number at left of nums[i]
            var dp = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                dp[i] = int.MaxValue;
                for (int j = i - 1; j >= 0; j--)
                {
                    if (nums[i] < nums[j])
                    {
                        if (nums[i] > dp[j])
                        {
                            return true;
                        }
                    }
                    else
                    {
                        dp[i] = Math.Min(dp[i], nums[j]);
                    }
                }
            }

            return false;
        }

        public bool Find132pattern2(int[] nums)
        {
            // keep third as high as possible
            int third = int.MinValue;

            // the nums in s is sorted, use any of nums as highest.
            var s = new Stack<int>();
            for (int i = nums.Length - 1; i >= 0; --i)
            {
                if (nums[i] < third)
                {
                    return true;
                }

                // use nums[i] as 1, highest
                while (s.Count != 0 && nums[i] > s.Peek())
                {
                    third = s.Pop();
                }

                s.Push(nums[i]);
            }

            return false;
        }
    }
}
