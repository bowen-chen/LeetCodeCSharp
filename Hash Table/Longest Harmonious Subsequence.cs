/*
594. Longest Harmonious Subsequence
We define a harmonious array is an array where the difference between its maximum value and its minimum value is exactly 1.

Now, given an integer array, you need to find the length of its longest harmonious subsequence among all its possible subsequences.

Example 1:
Input: [1,3,2,2,5,2,3,7]
Output: 5
Explanation: The longest harmonious subsequence is [3,2,2,2,3].
Note: The length of the input array will not exceed 20,000.
*/

using System;
using System.Collections.Generic;

namespace Demo
{
   public partial class Solution
    {
        public int FindLHS(int[] nums)
        {
            int res = 0;
            var m = new Dictionary<int, int>();
            foreach (int num in nums)
            {
                if (!m.ContainsKey(num))
                {
                    m[num] = 0;
                }
                ++m[num];
            }

            foreach (var a in m)
            {
                if (m.ContainsKey(a.Key + 1))
                {
                    res = Math.Max(res, a.Value + m[a.Key + 1]);
                }
            }
            return res;
        }
    }
}
