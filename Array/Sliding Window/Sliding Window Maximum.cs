/*
239. Sliding Window Maximum
medium, *
Sliding Window Maximum

Given an array nums, there is a sliding window of size k which is moving from the very left of the array to the very right. You can only see the k numbers in the window. Each time the sliding window moves right by one position.

For example,
Given nums = [1,3,-1,-3,5,3,6,7], and k = 3.

Window position                Max
---------------               -----
[1  3  -1] -3  5  3  6  7       3
 1 [3  -1  -3] 5  3  6  7       3
 1  3 [-1  -3  5] 3  6  7       5
 1  3  -1 [-3  5  3] 6  7       5
 1  3  -1  -3 [5  3  6] 7       6
 1  3  -1  -3  5 [3  6  7]      7
Therefore, return the max sliding window as [3,3,5,5,6,7].

Note: 
You may assume k is always valid, ie: 1 ≤ k ≤ input array's size for non-empty array.

Follow up:
Could you solve it in linear time?

Hint:

How about using a data structure such as deque (double-ended queue)?
The queue size need not be the same as the window’s size.
Remove redundant elements and the queue should store only elements that need to be considered.
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public void Test_MaxSlidingWindow()
        {
            MaxSlidingWindow(new[] {1}, 1).Print();
            MaxSlidingWindow(new[] {7, 2, 4}, 2).Print();
        }

        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            if (nums == null)
            {
                return new int[] {};
            }

            var left = 0;
            var ret = new List<int>();
            var window = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                var n = nums[i];
                while (window.Count > 0 && n > window[window.Count - 1])
                {
                    window.RemoveAt(window.Count - 1);
                }

                window.Add(n);
                if (i - left + 1 == k)
                {
                    ret.Add(window[0]);
                    if (nums[left++] == window[0])
                    {
                        window.RemoveAt(0);
                    }
                }
            }

            return ret.ToArray();
        }
    }
}
