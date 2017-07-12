/*
18	4Sum
medium, high/low
Given an array S of n integers, are there elements a, b, c, and d in S such that a + b + c + d = target? Find all unique quadruplets in the array which gives the sum of target.

Note:
Elements in a quadruplet (a,b,c,d) must be in non-descending order. (ie, a ≤ b ≤ c ≤ d)
The solution set must not contain duplicate quadruplets.
    For example, given array S = {1 0 -1 0 -2 2}, and target = 0.

    A solution set is:
    (-1,  0, 0, 1)
    (-2, -1, 1, 2)
    (-2,  0, 0, 2)
*/

using System;
using System.Collections.Generic;
namespace Demo
{
    public partial class Solution
    {
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            Array.Sort(nums);
            IList<IList<int>> res = new List<IList<int>>();
            for (int i = 0; i <= nums.Length - 3; i++)
            {
                if (i == 0 || (i > 0 && nums[i] != nums[i - 1])) // skip the same int
                {
                    for (int j = i + 1; j <= nums.Length - 2; j++)
                    {
                        if (j == i + 1 || (j > i + 1 && nums[j] != nums[j - 1])) // skip the same int
                        {
                            int lo = j + 1, hi = nums.Length - 1;
                            while (lo < hi)
                            {
                                int cur = nums[i] + nums[j] + nums[lo] + nums[hi];
                                if (cur == target)
                                {
                                    res.Add(new List<int> {nums[i], nums[j], nums[lo], nums[hi]});
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
                                else if (cur < target)
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
                }
            }
            return res;
        }
    }
}
