/*
revisit
456. 132 Pattern
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
            if (nums.Length <= 2) return false;
            int n = nums.Length, i = 0, j = 0, k = 0;
            while (i < n)
            {
                while (i < n - 1 && nums[i] >= nums[i + 1]) ++i;
                j = i + 1;
                while (j < n - 1 && nums[j] <= nums[j + 1]) ++j;
                k = j + 1;
                while (k < n)
                {
                    if (nums[k] > nums[i] && nums[k] < nums[j]) return true;
                    ++k;
                }
                i = j + 1;
            }
            return false;
        }
    }
}
