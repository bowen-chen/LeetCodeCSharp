/*
80	Remove Duplicates from Sorted Array II
medium
Follow up for "Remove Duplicates":
What if duplicates are allowed at most twice?

For example,
Given sorted array nums = [1,1,1,2,2,3],

Your function should return length = 5, with the first five elements of nums being 1, 1, 2, 2 and 3. It doesn't matter what you leave beyond the new length.
*/

namespace Demo
{
    public partial class Solution
    {
        public int DeleteDuplicatesArray2(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }
            
            int pos = 0;
            int count = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == nums[pos])
                {
                    count++;
                    if (count <= 2)
                    {
                        nums[++pos] = nums[i];
                    }
                }
                else
                {
                    nums[++pos] = nums[i];
                    count = 1;
                }
            }

            return pos + 1;
        }
    }
}
