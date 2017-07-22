/*
493. Reverse Pairs
hard
Given an array nums, we call (i, j) an important reverse pair if i < j and nums[i] > 2*nums[j].

You need to return the number of important reverse pairs in the given array.

Example1:

Input: [1,3,2,3,1]
Output: 2
Example2:

Input: [2,4,3,5,1]
Output: 3
Note:
The length of the given array will not exceed 50,000.
All the numbers in the input array are in the range of 32-bit integer.

*/

using System;

namespace Demo
{
    public partial class Solution
    {
        public int ReversePairs(int[] nums)
        {
            return ReversePairs(nums, 0, nums.Length - 1);
        }

        // merge sort
        public int ReversePairs(int[] nums, int left, int right)
        {
            if (left >= right)
            {
                return 0;
            }
            
            // sort
            int mid = left + (right - left)/2;
            int res = ReversePairs(nums, left, mid) + ReversePairs(nums, mid + 1, right);

            // check valid rang pair with nums[i]
            for (int i = left, j = mid + 1;i <= mid;i++)
            {
                while (j <= right && nums[i]/2.0 > nums[j])
                {
                    ++j;
                }

                // all number from [mid + 1, j) x 2.0 < nums[i]
                res += j - (mid + 1);
            }

            // merge [left, mid] and [mid+1, right]
            var cache = new int[right - left + 1];
            for (int i = left, j = mid + 1, c = 0; i <= mid || j <= right;)
            {
                if (i <= mid && j <= right)
                {
                    cache[c++] = nums[i] < nums[j] ? nums[i++] : nums[j++];
                }
                else
                {
                    cache[c++] = i <= mid ? nums[i++] : nums[j++];
                }
            }

            Array.Copy(cache, 0, nums, left, right - left + 1);
            return res;
        }
    };
}
