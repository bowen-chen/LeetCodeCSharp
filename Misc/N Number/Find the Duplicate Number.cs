/*
287	Find the Duplicate Number
medium, loop
Find the Duplicate Number

Given an array nums containing n + 1 integers where each integer is between 1 and n (inclusive), prove that at least one duplicate number must exist. Assume that there is only one duplicate number, find the duplicate one.

Note:
You must not modify the array (assume the array is read only).
You must use only constant, O(1) extra space.
Your runtime complexity should be less than O(n2).
There is only one duplicate number in the array, but it could be repeated more than once.
*/

using System.Linq;

namespace Demo
{
    public partial class Solution
    {
        public int FindDuplicate(int[] nums)
        {
            // ! (count <=mid)
            // count<=mid, dup is in high part
            int low = 1;
            int high = nums.Length - 1;
            while (low <= high)
            {
                int mid = low + (high - low)/2;
                int count = nums.Count(i => i <= mid);
                if (count <= mid)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid-1;
                }
            }
            return low;
        }

        public int FindDuplicate2(int[] nums)
        {
            // after knock out the number at nums[number] place, rest of them should be a link
            int slow = nums[0];
            int fast = nums[nums[0]];
            while (slow != fast)
            {
                slow = nums[slow];
                fast = nums[nums[fast]];
            }

            fast = 0;
            while (fast != slow)
            {
                fast = nums[fast];
                slow = nums[slow];
            }
            return slow;
        }
    }
}
