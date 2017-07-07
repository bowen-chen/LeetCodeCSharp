/*
53	Maximum Subarray
easy
Find the contiguous subarray within an array (containing at least one number) which has the largest sum.

For example, given the array [−2,1,−3,4,−1,2,1,−5,4],
the contiguous subarray [4,−1,2,1] has the largest sum = 6.

click to show more practice.

More practice:
If you have figured out the O(n) solution, try coding another solution using the divide and conquer approach, which is more subtle.
*/
using System;

namespace Demo
{
    public partial class Solution
    {
        public int MaxSubArray(int[] nums)
        {
            int ret = int.MinValue;
            int cur = 0;
            foreach (int n in nums)
            {
                if (cur >= 0)
                {
                    cur += n;
                }
                else
                {
                    cur = n;
                }
                ret = Math.Max(cur, ret);
            }
            return ret;
        }
    }
}
