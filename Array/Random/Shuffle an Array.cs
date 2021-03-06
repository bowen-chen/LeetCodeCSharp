﻿/*
384. Shuffle an Array
easy, *
Shuffle a set of numbers without duplicates.

Example:

// Init an array with set 1, 2, and 3.
int[] nums = {1,2,3};
Solution solution = new Solution(nums);

// Shuffle the array [1,2,3] and return its result. Any permutation of [1,2,3] must equally likely to be returned.
solution.shuffle();

// Resets the array back to its original configuration [1,2,3].
solution.reset();

// Returns the random shuffling of array [1,2,3].
solution.shuffle();
*/

using System;

namespace Demo
{
    public class Solution2
    {
        private readonly int[] _nums;
        private readonly Random _random = new Random();

        public Solution2(int[] nums)
        {
            _nums = nums;
        }

        /** Resets the array to its original configuration and return it. */
        public int[] Reset()
        {
            return _nums;
        }

        /** Returns a random shuffling of the array. */
        public int[] Shuffle()
        {
            int[] res = new int[_nums.Length];
            _nums.CopyTo(res, 0);
            for (int i = 0; i < res.Length; ++i)
            {
                int j = _random.Next(res.Length);

                // 1/res.length chance keep here
                int t = res[i];
                res[i] = res[j];
                res[j] = t;
            }

            return res;
        }
    }

    /**
     * Your Solution object will be instantiated and called as such:
     * Solution obj = new Solution(nums);
     * int[] param_1 = obj.Reset();
     * int[] param_2 = obj.Shuffle();
     */
}
