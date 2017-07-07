/*
153. Find Minimum in Rotated Sorted Array
medium, low high
Suppose a sorted array is rotated at some pivot unknown to you beforehand.

(i.e., 0 1 2 4 5 6 7 might become 4 5 6 7 0 1 2).

Find the minimum element.

You may assume no duplicate exists in the array.
*/

namespace Demo
{
    public partial class Solution
    {
        public int FindMin(int[] nums)
        {
            int lo = 0;
            int hi = nums.Length - 1;

            // find first low, nums[low]<=nums[low+1]
            while (lo <= hi)
            {
                int mid = (lo + hi)/2;
                if (nums[mid] > nums[hi])
                {
                    lo = mid + 1;
                }
                else
                {
                    hi = mid;
                }
            }

            return lo;
        }
    }
}
