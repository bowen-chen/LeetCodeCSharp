/*
169	Majority Element
easy
Majority Element

Given an array of size n, find the majority element. The majority element is the element that appears more than ⌊ n/2 ⌋ times.

You may assume that the array is non-empty and the majority element always exist in the array.
*/

using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    public partial class Solution
    {
        // http://gregable.com/2013/10/majority-vote-algorithm-find-majority.html
        public int MajorityElement(int[] nums)
        {
            int major = nums[0], count = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (count == 0)
                {
                    count++;
                    major = nums[i];
                }
                else if (major == nums[i])
                {
                    count++;
                }
                else
                {
                    count--;
                }
            }
            return major;
        }

        public int MajorityElement2(int[] nums)
        {
            int res = 0;
            for (int i = 0; i < 32; ++i)
            {
                int ones = 0, zeros = 0;
                foreach (int num in nums)
                {
                    if ((num & (1 << i)) != 0) ++ones;
                    else ++zeros;
                }

                if (ones > zeros)
                {
                    res |= (1 << i);
                }
            }
            return res;
        }
    }
}
