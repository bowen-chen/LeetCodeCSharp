/*
259	3Sum Smaller
easy
Given an array of n integers nums and a target, find the number of index triplets i, j, k with 0 <= i < j < k < n that satisfy the condition nums[i] + nums[j] + nums[k] < target.

For example, given nums = [-2, 0, 1, 3], and target = 2.

Return 2. Because there are two triplets which sums are less than 2:

[-2, 0, 1]
[-2, 0, 3]
Follow up:
Could you solve it in O(n^2) runtime?
*/

using System;

namespace Demo
{
    public partial class Solution
    {
        public int ThreeSumSmaller(int[] nums, int target)
        {
            Array.Sort(nums);
            int n = nums.Length;
            int ret = 0;
            for (int i = 0; i < n - 2; i++)
            {
                int low = i + 1, high = n - 1;
                while (low < high)
                {
                    if (nums[i] + nums[low] + nums[high] >= target)
                    {
                        high--;
                    }
                    else
                    {
                        // choose low and [low + 1 to high]
                        ret += (high - low);
                        low++;
                    }
                }
            }

            return ret;
        }
    }
}
