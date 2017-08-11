/*
219	Contains Duplicate II   
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
            int len = k + 1;
            var h = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                var n = nums[i];
                if (h.Contains(n))
                {
                    return true;
                }
                
                h.Add(n);

                int left = i - len + 1;
                if (left >= 0)
                {
                    h.Remove(nums[left]);
                }
            }

            return false;
        }
    }
}
