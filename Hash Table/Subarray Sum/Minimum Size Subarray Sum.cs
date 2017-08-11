/*
209	Minimum Size Subarray Sum
easy, window
Given an array of n positive integers and a positive integer s, find the minimal length of a subarray of which the sum ≥ s. If there isn't one, return 0 instead.

For example, given the array [2,3,1,2,4,3] and s = 7,
the subarray [4,3] has the minimal length under the problem constraint.

click to show more practice.

More practice:
If you have figured out the O(n) solution, try coding another solution of which the time complexity is O(n log n).
*/

using System;

namespace Demo
{
    public partial class Solution
    {
        public int MinSubArrayLen(int s, int[] nums)
        {
            // all positive number
            int start = 0;
            int sum = 0;
            int minlen = int.MaxValue;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                while (sum >= s)
                {
                    minlen = Math.Min(minlen, i - start + 1);
                    sum -= nums[start++];
                }
            }

            return minlen == int.MaxValue ? 0 : minlen;
        }
    }
}
