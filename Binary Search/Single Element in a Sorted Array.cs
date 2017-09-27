/*
540. Single Element in a Sorted Array
*
Given a sorted array consisting of only integers where every element appears twice except for one element which appears once. Find this single element that appears only once.

Example 1:
Input: [1,1,2,3,3,4,4,8,8]
Output: 2
Example 2:
Input: [3,3,7,7,10,11,11]
Output: 10
Note: Your solution should run in O(log n) time and O(1) space.
*/

namespace Demo
{
    public partial class Solution
    {
        public int SingleNonDuplicate(int[] nums)
        {
            // find first lo does not meet condition ( nums[lo] == nums[lo+1])
            int n = nums.Length, lo = 0, hi = n-1;
            while (lo <= hi)
            {
                int m = (lo + hi)/2;
                m &= ~1; // round down to even number
                if (m != n - 1 && nums[m] == nums[m + 1])
                {
                    lo = m + 2;
                }
                else
                {
                    hi = m - 2;
                }
            }

            return nums[lo];
        }
    }
}
