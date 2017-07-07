/*
Easy
Contains Duplicate II

Given an array of integers and an integer k, find out whether there are two distinct indices i and j in the array such that nums[i] = nums[j] and the difference between i and j is at most k.
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {

        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            var h = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (i > k)
                {
                    h.Remove(nums[i - k]);
                }
                var n = nums[i];
                if (h.Contains(n))
                {
                    return true;
                }
                h.Add(n);
            }
            return false;
        }

        public bool ContainsNearbyDuplicate2(int[] nums, int k)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j <= i + k && j < nums.Length; j++)
                {
                    if (nums[i] == nums[j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
