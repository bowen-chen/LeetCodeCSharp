/*
47	Permutations II
easy, recursion
Given a collection of numbers that might contain duplicates, return all possible unique permutations.

For example,
[1,1,2] have the following unique permutations:
[1,1,2], [1,2,1], and [2,1,1].
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            var ret = new List<IList<int>>();
            PermuteUnique(ret, nums, 0);
            return ret;
        }

        private void PermuteUnique(IList<IList<int>> ret, int[] nums, int index)
        {
            if (index == nums.Length)
            {
                ret.Add(new List<int>(nums));
                return;
            }

            // choose unique num at index
            var visited = new HashSet<int>();
            for (int i = index; i < nums.Length; i++)
            {
                if (!visited.Contains(nums[i]))
                {
                    visited.Add(nums[i]);
                    int tmp = nums[i];
                    nums[i] = nums[index];
                    nums[index] = tmp;
                    PermuteUnique(ret, nums, index + 1);
                    tmp = nums[i];
                    nums[i] = nums[index];
                    nums[index] = tmp;
                }
            }
        }
    }
}
