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
        public bool ContainsNearbyAlmostDuplicate2(int[] nums, int k, int t)
        {
            if (k < 1 || t < 0) return false;

            // bucket size t+1
            // the possible pair is in nearby bucket or same bucket
            var map = new Dictionary<long, long>();
            for (int i = 0; i < nums.Length; i++)
            {
                long bucket = ((long)nums[i] - int.MinValue) / ((long)t + 1);
                if (map.ContainsKey(bucket)
                    || (map.ContainsKey(bucket - 1) && nums[i] - map[bucket - 1] <= t)
                    || (map.ContainsKey(bucket + 1) && map[bucket + 1] - nums[i] <= t))
                {
                    return true;
                }

                // remove the last bucket
                if (map.Count >= k)
                {
                    long lastBucket = ((long)nums[i - k] - int.MinValue) / ((long)t + 1);
                    map.Remove(lastBucket);
                }

                //add
                map.Add(bucket, nums[i]);
            }

            return false;
        }
    }
}
