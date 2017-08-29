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
            
            while (lo < hi)
            {
                int mid = (lo + hi) / 2;
                if (nums[mid] > nums[hi]) // the min must be in mid+1->hi
                {
                    lo = mid + 1;
                }
                else // the min must be low to mid
                {
                    hi = mid;
                }
            }

            return nums[lo];
        }
    }
}
