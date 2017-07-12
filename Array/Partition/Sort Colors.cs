/*
75	Sort Colors
easy, 3 way partition
Given an array with n objects colored red, white or blue, sort them so that objects of the same color are adjacent, with the colors in the order red, white and blue.

Here, we will use the integers 0, 1, and 2 to represent the color red, white, and blue respectively.

Note:
You are not suppose to use the library's sort function for this problem.

click to show follow up.

Follow up:
A rather straight forward solution is a two-pass algorithm using counting sort.
First, iterate the array counting number of 0's, 1's, and 2's, then overwrite array with total number of 0's, then 1's and followed by 2's.

Could you come up with an one-pass algorithm using only constant space?
*/

namespace Demo
{
    public partial class Solution
    {
        public void SortColors(int[] nums)
        {
            //zero) = 0, [one, second] = 1, (second = 2
            int zero = 0;
            int one = 0;
            int second = nums.Length - 1;
            while(one<=second)
            {
                if (nums[one] == 2)
                {
                    int temp = nums[one];
                    nums[one] = nums[second];
                    nums[second] = temp;
                    second--;
                }
                else if (nums[one] == 0)
                {
                    int temp = nums[one];
                    nums[one] = nums[zero];
                    nums[zero] = temp;
                    zero++;
                    one++;
                }
                else
                {
                    one++;
                }
            }
        }
    }
}
