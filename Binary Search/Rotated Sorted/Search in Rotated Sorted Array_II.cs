/*
81. Search in Rotated Sorted Array II
medium, low/high
Follow up for "Search in Rotated Sorted Array":
What if duplicates are allowed?

Would this affect the run-time complexity? How and why?
Suppose an array sorted in ascending order is rotated at some pivot unknown to you beforehand.

(i.e., 0 1 2 4 5 6 7 might become 4 5 6 7 0 1 2).

Write a function to determine if a given target is in the array.

The array may contain duplicates.
*/

namespace Demo
{
    public partial class Solution
    {
        public bool Search3(int[] nums, int target)
        {
            int lo = 0;
            int hi = nums.Length - 1;
            while (lo <= hi)
            {
                int mid = lo + (hi-lo) / 2;
                if (nums[mid] == target)
                {
                    return true;
                }

                // Range low to mid, is sorted 
                if (nums[lo] < nums[mid])
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
                else if (nums[lo] > nums[mid])
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
                // low = mid
                else
                {
                    lo++;
                }
            }
            return false;
        }
    }
}
