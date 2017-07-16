/*
41	First Missing Positive
easy, number is in the its index
Given an unsorted integer array, find the first missing positive integer.

For example,
Given [1,2,0] return 3,
and [3,4,-1,1] return 2.

Your algorithm should run in O(n) time and uses constant space.
*/

namespace Demo
{
    public partial class Solution
    {
        public int FirstMissingPositive(int[] nums)
        {
            for (int i = 0; i < nums.Length; ++i)
            {
                if (nums[i] > 0 && nums[i] <= nums.Length && nums[i] != nums[nums[i] - 1])
                {
                    int temp = nums[i];
                    nums[i] = nums[temp - 1];
                    nums[temp - 1] = temp;
                    i--;
                }
            }

            for (int i = 0; i < nums.Length; ++i)
            {
                if (nums[i] != i + 1)
                {
                    return i + 1;
                }
            }

            return nums.Length + 1;
        }
    }
}
