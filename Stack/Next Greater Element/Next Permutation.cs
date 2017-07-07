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

namespace Demo
{
    public partial class Solution
    {
        public void NextPermutation(int[] nums)
        {
            int n = nums.Length;
            for (int i = n - 2; i >= 0; --i)
            {
                // from right to left, find the first nums[i] < nums[i+1], we need switch nums[i]
                if (nums[i] < nums[i + 1])
                {
                    int j;

                    // from right to left, find the first nums[j] > nums[i]
                    for (j = n - 1; j >= i; --j)
                    {
                        if (nums[j] > nums[i])
                        {
                            break;
                        }
                    }
                    Swap(nums, i, j);

                    // now i+1 => n-1 is decresase order, so reverse it
                    Reverse(nums, i + 1, nums.Length - 1);
                    return;
                }
            }
            Reverse(nums, 0, nums.Length - 1);
        }

        public void Swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }

        public void Reverse(int[] nums, int start, int end)
        {
            if (start > end)
            {
                return;
            }

            for (int i = start; i <= (end + start)/2; i++)
            {
                Swap(nums, i, start + end - i);
            }
        }
    }
}
