/*
55 Jump Game
easy
Given an array of non-negative integers, you are initially positioned at the first index of the array.

Each element in the array represents your maximum jump length at that position.

Determine if you are able to reach the last index.

For example:
A = [2,3,1,1,4], return true.

A = [3,2,1,0,4], return false.
*/

using System;
using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public bool CanJump(int[] nums)
        {
            var q = new Queue<int>();
            q.Enqueue(0);
            int max = 0;
            while (q.Count != 0)
            {
                var i = q.Dequeue();
                int j = i + nums[i];
                if (j >= nums.Length - 1)
                {
                    return true;
                }

                // max is visited
                for (; j > i && j > max; j--)
                {
                    q.Enqueue(j);
                }

                max = Math.Max(max, j);
            }

            return false;
        }

        public bool CanJump2(int[] nums)
        {
            int last = 0;
            for (int i = 0; last < nums.Length - 1 && i <= last; i++)
            {
                last = Math.Max(last, i + nums[i]);
            }

            return last >= nums.Length - 1;
        }
    }
}
