/*
33. Search in Rotated Sorted Array
medium, low/high
Suppose a sorted array is rotated at some pivot unknown to you beforehand.

(i.e., 0 1 2 4 5 6 7 might become 4 5 6 7 0 1 2).

You are given a target value to search. If found in the array return its index, otherwise return -1.

You may assume no duplicate exists in the array.
*/

namespace Demo
{
    public partial class Solution
    {
        public int Search2(int[] nums, int target)
        {
            int lo = 0;
            int hi = nums.Length - 1;
            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;
                if (nums[mid] == target)
                {
                    return mid;
                }
                // Range low to mid, is sorted 
                if (nums[lo] <= nums[mid])
                {
                    // In range low to mid
                    if (target >= nums[lo] && target < nums[mid])
                    {
                        hi = mid - 1;
                    }
                    else
                    {
                        lo = mid + 1;
                    }
                }
                // Range mid to high, is sorted
                else
                {
                    // In range mid to high
                    if (target > nums[mid] && target <= nums[hi])
                    {
                        lo = mid + 1;
                    }
                    else
                    {
                        hi = mid - 1;
                    }
                }
            }
            return -1;
        }
    }
}
