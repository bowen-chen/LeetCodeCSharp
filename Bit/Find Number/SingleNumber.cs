/*
136	Single Number
easy
Given an array of integers, every element appears twice except for one. Find that single one.

Note:
Your algorithm should have a linear runtime complexity. Could you implement it without using extra memory?
*/

namespace Demo
{
    public partial class Solution
    {
        public int SingleNumber(int[] nums)
        {
            int ret = 0;
            foreach (int i in nums)
            {
                ret ^= i;
            }

            return ret;
        }
    }
}
