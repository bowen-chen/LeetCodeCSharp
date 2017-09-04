/*
219	Contains Duplicate II   
Easy, *
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
            int left = 0;
            for (int right = 0; right < nums.Length; right++)
            {
                if (!h.Add(nums[right]))
                {
                    return true;
                }

                if (right - left == k)
                {
                    h.Remove(nums[left++]);
                }
            }

            return false;
        }
    }
}
