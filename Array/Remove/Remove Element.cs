/*
27	Remove Element
easy
Given an array and a value, remove all instances of that value in place and return the new length.

The order of elements can be changed. It doesn't matter what you leave beyond the new length.
*/

namespace Demo
{
    public partial class Solution
    {
        public void Test_RemoveElement()
        {
            RemoveElement(new[] {3, 3}, 5);
        }

        public int RemoveElement(int[] nums, int val)
        {
            int i = 0;
            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[j] != val)
                {
                    nums[i++] = nums[j];
                }
            }
            return i;
        }
    }
}
