/*
487	Max Consecutive Ones II 
Given a binary array, find the maximum number of consecutive 1s in this array if you can flip at most one 0.

Example 1:

Input: [1,0,1,1,0]
Output: 4
Explanation: Flip the first zero will get the the maximum number of consecutive 1s.
    After flipping, the maximum number of consecutive 1s is 4.
 

Note:

The input array will only contain 0 and 1.
The length of input array is a positive integer and will not exceed 10,000
 

Follow up:
What if the input numbers come in one by one as an infinite stream? In other words, you can't store all numbers coming from the stream as it's too large to hold in memory. Could you solve it efficiently?
*/
using System;
using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public int FindMaxConsecutiveOnes3(int[] nums)
        {
            int k = 1; // can flip k
            int res = 0;
            int left = 0;
            var q = new Queue<int>();
            for (int right = 0; right < nums.Length; ++right)
            {
                if (nums[right] == 0)
                {
                    q.Enqueue(right);
                }

                if (q.Count > k)
                {
                    left = q.Dequeue() + 1;
                }

                res = Math.Max(res, right - left + 1);
            }

            return res;
        }
    }
}
