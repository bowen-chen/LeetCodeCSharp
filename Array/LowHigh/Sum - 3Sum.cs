/*
15	3Sum
medium, high/low
Given an array S of n integers, are there elements a, b, c in S such that a + b + c = 0? Find all unique triplets in the array which gives the sum of zero.

Note:
Elements in a triplet (a,b,c) must be in non-descending order. (ie, a ≤ b ≤ c)
The solution set must not contain duplicate triplets.
    For example, given array S = {-1 0 1 2 -1 -4},

    A solution set is:
    (-1, 0, 1)
    (-1, -1, 2)
*/

using System;
using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums);
            IList<IList<int>> res = new List<IList<int>>();
            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (i == 0 || (i > 0 && nums[i] != nums[i - 1])) // skip the same int
                {
                    int lo = i + 1, hi = nums.Length - 1, sum = 0 - nums[i];
                    while (lo < hi)
                    {
                        int cur = nums[i] + nums[lo] + nums[hi];
                        if (cur == sum)
                        {
                            res.Add(new List<int> {nums[i], nums[lo], nums[hi]});
                            while (lo < hi && nums[lo] == nums[lo + 1]) // skip the same int
                            {
                                lo++;
                            }
                            while (lo < hi && nums[hi] == nums[hi - 1]) // skip the same int
                            {
                                hi--;
                            }
                            lo++;
                            hi--;
                        }
                        else if (nums[lo] + nums[hi] < sum)
                        {
                            lo++;
                        }
                        else
                        {
                            hi--;
                        }
                    }
                }
            }
            return res;
        }
    }
}
