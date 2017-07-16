/*
442. Find All Duplicates in an Array
Given an array of integers, 1 ≤ a[i] ≤ n (n = size of array), some elements appear twice and others appear once.

Find all the elements that appear twice in this array.

Could you do it without extra space and in O(n) runtime?

Example:
Input:
[4,3,2,7,8,2,3,1]

Output:
[2,3]
*/
using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public IList<int> FindDuplicates(int[] nums)
        {
            for (int i = 0; i < nums.Length; ++i)
            {
                // put nums[i] in right position
                if (nums[i] != nums[nums[i] - 1])
                {
                    var t = nums[i];
                    nums[i] = nums[t - 1];
                    nums[t - 1] = t;
                    i--;
                }
            }

            var res = new List<int>();
            for (int i = 0; i < nums.Length; ++i)
            {
                if (nums[i] != i + 1)
                {
                    res.Add(nums[i]);
                }
            }

            return res;
        }
    }
}
