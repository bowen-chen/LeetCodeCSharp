/*
34. Search for a Range
Easy, low/high
Given a sorted array of integers, find the starting and ending position of a given target value.

Your algorithm's runtime complexity must be in the order of O(log n).

If the target is not found in the array, return [-1, -1].

For example,
Given [5, 7, 7, 8, 8, 10] and target value 8,
return [3, 4].
*/

namespace Demo
{
    public partial class Solution
    {
        public int[] SearchRange(int[] nums, int target)
        {
            int start = FirstGreaterEqual(nums, target);

            // target greater than the last one
            // target less than the first one
            if (start == nums.Length || nums[start] != target)
            {
                return new [] { -1, -1 };
            }

            return new [] { start, FirstGreaterEqual(nums, target + 1) - 1 };
        }

        //find the first number that is greater than or equal to target.
        //could return A.length if target is greater than A[A.length-1].
        private int FirstGreaterEqual(int[] A, int target)
        {
            int low = 0;
            int high = A.Length-1;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (A[mid] < target)
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
