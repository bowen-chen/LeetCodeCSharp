/*
485. Max Consecutive Ones
Given a binary array, find the maximum number of consecutive 1s in this array.

Example 1:
Input: [1,1,0,1,1,1]
Output: 3
Explanation: The first two digits or the last three digits are consecutive 1s.
    The maximum number of consecutive 1s is 3.
Note:

The input array will only contain 0 and 1.
The length of input array is a positive integer and will not exceed 10,000
*/

using System;

namespace Demo
{
    public partial class Solution
    {
        public int FindMaxConsecutiveOnes(int[] nums)
        {
            int res = 0;
            int cnt = 0;
            foreach (int num in nums)
            {
                cnt = (num == 0) ? 0 : cnt + 1;
                res = Math.Max(res, cnt);
            }

            return res;
        }
    }
}
