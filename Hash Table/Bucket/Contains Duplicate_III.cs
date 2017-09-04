/*
220	Contains Duplicate III
hard, hashable, bucket
Contains Duplicate III

Given an array of integers, find out whether there are two distinct indices i and j in the array such that the difference between nums[i] and nums[j] is at most t and the difference between i and j is at most k.
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t)
        {
            if (k < 1 || t < 0)
            {
                return false;
            }

            // bucket size t+1
            // the possible pair is in nearby bucket or same bucket
            var map = new Dictionary<long, long>();
            int left = 0;
            for (int right = 0; right < nums.Length; right++)
            {
                long bucket = ((long)nums[left] - int.MinValue) / ((long)t + 1);
                if (map.ContainsKey(bucket)
                    || (map.ContainsKey(bucket - 1) && nums[left] - map[bucket - 1] <= t)
                    || (map.ContainsKey(bucket + 1) && map[bucket + 1] - nums[left] <= t))
                {
                    return true;
                }

                map[bucket] = nums[right];

                // remove the last bucket
                if (right - left == k)
                {
                    map.Remove(((long)nums[left++] - int.MinValue) / ((long)t + 1));
                }
            }

            return false;
        }
    }
}
