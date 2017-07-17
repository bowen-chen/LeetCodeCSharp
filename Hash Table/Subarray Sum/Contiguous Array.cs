/*
525. Contiguous Array
easy
Given a binary array, find the maximum length of a contiguous subarray with equal number of 0 and 1.

Example 1:
Input: [0,1]
Output: 2
Explanation: [0, 1] is the longest contiguous subarray with equal number of 0 and 1.
Example 2:
Input: [0,1,0]
Output: 2
Explanation: [0, 1] (or [1, 0]) is a longest contiguous subarray with equal number of 0 and 1.
Note: The length of the given binary array will not exceed 50,000.
*/

using System;
using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public int FindMaxLength(int[] nums)
        {
            int res = 0;
            int sum = 0;
            var st = new Dictionary<int, int>();
            // 0 at index -1
            st[0] = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += (nums[i] == 0 ? -1 : 1);
                if (st.ContainsKey(sum))
                {
                    res = Math.Max(res, i - st[sum]);
                }
                else
                {
                    st[sum] = i;
                }
            }

            return res;
        }
    }
}

