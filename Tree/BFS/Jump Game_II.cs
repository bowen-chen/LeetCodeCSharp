/*
45 Jump Game II
easy
Given an array of non-negative integers, you are initially positioned at the first index of the array.

Each element in the array represents your maximum jump length at that position.

Your goal is to reach the last index in the minimum number of jumps.

For example:
Given array A = [2,3,1,1,4]

The minimum number of jumps to reach the last index is 2. (Jump 1 step from index 0 to 1, then 3 steps to the last index.)

Note:
You can assume that you can always reach the last index.
*/
using System;
using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public void Test_Jump()
        {
            Jump(new[] {1, 2, 3});
        }

        public int Jump(int[] nums)
        {
            var q = new Queue<int?>();
            q.Enqueue(0);
            q.Enqueue(null);
            int max = 0;
            int level = 0;
            while (q.Count != 0)
            {
                var i = q.Dequeue();
                if (i == null)
                {
                    if (q.Count != 0)
                    {
                        level++;
                        q.Enqueue(null);
                    }
                }
                else
                {
                    int j = i.Value + nums[i.Value];
                    if (j >= nums.Length - 1)
                    {
                        return level + 1;
                    }

                    // max is visited
                    for (; j > i.Value && j > max; j--)
                    {
                        q.Enqueue(j);
                    }
                    max = Math.Max(max, j);
                }

            }
            return 0;
        }
    }
}
