/*
35. Search Insert Position
easy, low/high
Given a sorted array and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.

You may assume no duplicates in the array.

Here are few examples.
[1,3,5,6], 5 → 2
[1,3,5,6], 2 → 1
[1,3,5,6], 7 → 4
[1,3,5,6], 0 → 0
*/

namespace Demo
{
    public partial class Solution
    {
        public int SearchInsert(int[] nums, int target)
        {
            int low = 0;
            int high = nums.Length - 1;
            // find first low, where nums[low] >= target
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (nums[mid] == target)
                {
                    return mid;
                }

                if (nums[mid] < target)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            return low;
        }
    }
}
