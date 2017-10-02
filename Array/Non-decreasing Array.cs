/*
665. Non-decreasing Array
Given an array with n integers, your task is to check if it could become non-decreasing by modifying at most 1 element.

We define an array is non-decreasing if array[i] <= array[i + 1] holds for every i (1 <= i < n).

Example 1:
Input: [4,2,3]
Output: True
Explanation: You could modify the first 
4
 to 
1
 to get a non-decreasing array.
Example 2:
Input: [4,2,1]
Output: False
Explanation: You can't get a non-decreasing array by modify at most one element.
Note: The n belongs to [1, 10,000].


*/

namespace Demo
{
    public partial class Solution
    {
        public bool CheckPossibility(int[] nums)
        {
            if (nums == null || nums.Length <= 1)
            {
                return true;
            }

            bool f = false;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] < nums[i - 1])
                {
                    if (f)
                    {
                        return false;
                    }
                    // keep nums[i] as low as possible
                    if (i == 1 || nums[i] >= nums[i - 2])
                    {
                        nums[i - 1] = nums[i];
                    }
                    else
                    {
                        nums[i] = nums[i - 1];
                    }
                    f = true;
                }
            }

            return true;
        }
    }
}
