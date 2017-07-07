/*
398. Random Pick Index
Given an array of integers with possible duplicates, randomly output the index of a given target number. You can assume that the given target number must exist in the array.

Note:
The array size can be very large. Solution that uses too much extra space will not pass the judge.

Example:

int[] nums = new int[] {1,2,3,3,3};
Solution solution = new Solution(nums);

// pick(3) should return either index 2, 3, or 4 randomly. Each index should have equal probability of returning.
solution.pick(3);

// pick(1) should return 0. Since in the array only nums[0] is equal to 1.
solution.pick(1);
*/
using System;

namespace Demo
{
    class RandomPickIndex
    {
        private readonly int[] _nums;
        private readonly Random _random = new Random();
        public RandomPickIndex(int[] nums)
        {
            _nums = nums;
        }

        public int Pick(int target)
        {
            int cnt = 1;
            int res = -1;
            for (int i = 0; i < _nums.Length; ++i)
            {
                if (_nums[i] != target)
                {
                    continue;
                }

                // cnt-1/cnt chance keep same
                if (_random.Next(cnt) == 0)
                {
                    res = i;
                }

                ++cnt;
            }
            return res;
        }
    };

    /**
     * Your Solution object will be instantiated and called as such:
     * Solution obj = new Solution(nums);
     * int param_1 = obj.pick(target);

    1, 1/2, 1/2, 1/3
     */
}
