/*
268	Missing Number
easy, *
Missing Number
Given an array containing n distinct numbers taken from 0, 1, 2, ..., n, find the one that is missing from the array.

For example,
Given nums = [0, 1, 3] return 2.

Note:
Your algorithm should run in linear runtime complexity. Could you implement it using only constant extra space complexity?
*/

namespace Demo
{
    public partial class Solution
    {
        public int MissingNumber(int[] nums)
        {
            long ret = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                ret += i - nums[i];
            }

            return (int)(ret + nums.Length);
        }

        public int MissingNumber_2(int[] nums)
        {
            int result = nums.Length;
            int i = 0;
            foreach (int num in nums)
            {
                result ^= num;
                result ^= i;
                i++;
            }

            return result;
        }
    }
}
