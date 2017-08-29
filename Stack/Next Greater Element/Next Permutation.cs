/*
31	Next Permutation
hard
Implement next permutation, which rearranges numsbers into the lexicographically next greater permutation of numsbers.

If such arrangement is not possible, it must rearrange it as the lowest possible order (ie, sorted in ascending order).

The replacement must be in-place, do not allocate extra memory.

Here are some examples. Inputs are in the left-hand column and its corresponding outputs are in the right-hand column.
1,2,3 → 1,3,2
3,2,1 → 1,2,3
1,1,5 → 1,5,1
*/

using System;

namespace Demo
{
    public partial class Solution
    {
        public void NextPermutation(int[] nums)
        {

            int i = nums.Length - 1;
            // from right to left, find the first nums[i-1] < nums[i], we need switch nums[i-1]
            for (; i > 0 && nums[i - 1] >= nums[i]; i--) { }
            if (i == 0)
            {
                Array.Reverse(nums);
                return;
            }
            i--;

            // from right to left, find the first nums[j] > nums[i]
            int j = nums.Length - 1;
            for (; j > i && nums[j] <= nums[i]; j--) { }
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;

            // now i+1 => n-1 is decresase order, so reverse it
            Array.Reverse(nums, i + 1, nums.Length - i - 1);
        }
    }
}
