/*
128. Longest Consecutive Sequence
hard, double link
Given an unsorted array of integers, find the length of the longest consecutive elements sequence.

For example,
Given [100, 4, 200, 1, 3, 2],
The longest consecutive elements sequence is [1, 2, 3, 4]. Return its length: 4.

Your algorithm should run in O(n) complexity.
*/

using System;
using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public int LongestConsecutive3(int[] nums)
        {
            int res = 0;

            // the longest sequence includes i
            // We only keept the start and end of the sequence accurate
            var m = new Dictionary<int, int>();
            foreach (int d in nums)
            {
                if (!m.ContainsKey(d))
                {
                    int left = m.ContainsKey(d - 1) ? m[d - 1] : 0;
                    int right = m.ContainsKey(d + 1) ? m[d + 1] : 0;
                    int sum = left + right + 1;
                    m[d] = sum;
                    m[d - left] = sum;
                    m[d + right] = sum;
                    res = Math.Max(res, sum);
                }
            }

            return res;
        }
    }
}
