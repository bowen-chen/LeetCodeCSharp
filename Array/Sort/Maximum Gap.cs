/*
164	Maximum Gap
hard, bucket sorting
Given an unsorted array, find the maximum difference between the successive elements in its sorted form.

Try to solve it in linear time/space.

Return 0 if the array contains less than 2 elements.

You may assume all elements in the array are non-negative integers and fit in the 32-bit signed integer range.
*/
using System;

namespace Demo
{
    public partial class Solution
    {
        public int MaximumGap(int[] nums)
        {
            if (nums == null || nums.Length < 2)
            {
                return 0;
            }

            // get the max and min value of the array
            int min = nums[0];
            int max = nums[0];
            foreach (int i in nums)
            {
                min = Math.Min(min, i);
                max = Math.Max(max, i);
            }
            // the minimum possibale max gap, ceiling of the integer division.
            // max difference is not among the numbers in the same bucket.
            // max difference is the min of the bucket - the max of the previous bucket
            int gap = (int)Math.Ceiling((double)(max - min) / (nums.Length - 1));
            int?[] bucketsMIN = new int?[nums.Length - 1]; // store the min value in that bucket
            int?[] bucketsMAX = new int?[nums.Length - 1]; // store the max value in that bucket

            // put numsbers into buckets
            foreach (int i in nums)
            {
                if (i == min || i == max)
                {
                    continue;
                }

                int idx = (i - min) / gap; // index of the right position in the buckets
                bucketsMIN[idx] = Math.Min(i, bucketsMIN[idx]??int.MaxValue);
                bucketsMAX[idx] = Math.Max(i, bucketsMAX[idx]??int.MinValue);
            }

            // scan the buckets for the max gap
            int maxGap = int.MinValue;
            int previousMax = min;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (bucketsMIN[i] == null || bucketsMAX[i] == null)
                {
                    // empty bucket
                    continue;
                }

                // min value minus the previous value is the current gap
                maxGap = Math.Max(maxGap, bucketsMIN[i].Value - previousMax);

                // update previous bucket value
                previousMax = bucketsMAX[i].Value;
            }

            maxGap = Math.Max(maxGap, max - previousMax); // updata the final max value gap
            return maxGap;
        }
    }
}
