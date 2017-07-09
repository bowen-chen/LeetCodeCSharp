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

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public bool CanJump(int[] nums)
        {
            bool[] v = new bool[nums.Length];
            Stack<int> s = new Stack<int>();
            s.Push(0);
            while (s.Count != 0)
            {
                int i = s.Pop();
                if (i == nums.Length - 1)
                {
                    return true;
                }

                if (i + nums[i] >= nums.Length - 1)
                {
                    return true;
                }

                for (int j = i + nums[i]; j > i; j--)
                {
                    if (!v[j])
                    {
                        v[j] = true;
                        s.Push(j);
                    }
                }
            }
            return false;
        }

        public bool CanJump2(int[] nums)
        {
            int last = nums.Length - 1;
            for (int i = nums.Length - 2; i >= 0; i--)
            {
                if (i + nums[i] >= last) last = i;
            }
            return last <= 0;
        }

        public bool CanJump3(int[] nums)
        {
            int last = 0;
            for (int i = 0; i < nums.Length - 1 && i <= last; i++)
            {
                if (i + nums[i] > last)
                {
                    last = i + nums[i];
                }
            }
            return last >= nums.Length - 1;
        }
    }
}
