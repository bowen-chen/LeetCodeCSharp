﻿/*
90	Subsets II
easy, recursion, *
Given a collection of integers that might contain duplicates, nums, return all possible subsets.

Note:
Elements in a subset must be in non-descending order.
The solution set must not contain duplicate subsets.
For example,
If nums = [1,2,2], a solution is:

[
  [2],
  [1],
  [1,2,2],
  [2,2],
  [1,2],
  []
]
*/

using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    public partial class Solution
    {
        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            nums = nums.OrderBy(n => n).ToArray();
            var ret = new List<IList<int>> {new List<int>()};
            SubsetsWithDup(ret, nums, 0, new List<int>());
            return ret;
        }

        public void SubsetsWithDup(IList<IList<int>> ret, int[] nums, int i, List<int> cur)
        {
            if (i >= nums.Length)
            {
                return;
            }

            // choose
            cur.Add(nums[i]);
            ret.Add(new List<int>(cur));
            SubsetsWithDup(ret, nums, i + 1, cur);
            cur.RemoveAt(cur.Count - 1);

            // not choose
            int c = nums[i];
            while (i + 1 < nums.Length && nums[i + 1] == c)
            {
                i++;
            }

            SubsetsWithDup(ret, nums, i + 1, cur);
        }
    }
}
