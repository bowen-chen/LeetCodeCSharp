/*
46	Permutations
easy, recursion
Given a collection of distinct numbers, return all possible permutations.

For example,
[1,2,3] have the following permutations:
[1,2,3], [1,3,2], [2,1,3], [2,3,1], [3,1,2], and [3,2,1].
*/
using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public IList<IList<int>> Permute2(int[] nums)
        {
            var ret = new List<IList<int>>();
            Permute2(ret, nums, 0);
            return ret;
        }

        private void Permute2(IList<IList<int>> ret, int[] nums, int index)
        {
            if (index == nums.Length)
            {
                ret.Add(new List<int>(nums));
                return;
            }

            for (int i = index; i < nums.Length; i++)
            {
                int tmp = nums[i];
                nums[i] = nums[index];
                nums[index] = tmp;
                Permute2(ret, nums, index + 1);
                tmp = nums[i];
                nums[i] = nums[index];
                nums[index] = tmp;
            }
        }
    }
}
