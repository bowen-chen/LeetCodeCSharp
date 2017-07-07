/*
78	Subsets
easy, recursion
Given a set of distinct integers, nums, return all possible subsets.

Note:
Elements in a subset must be in non-descending order.
The solution set must not contain duplicate subsets.
For example,
If nums = [1,2,3], a solution is:

[
  [3],
  [1],
  [2],
  [1,2,3],
  [1,3],
  [2,3],
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
        public void Test_Subsets()
        {
            Subsets(new[] {1, 2, 3});
        }

        public IList<IList<int>> Subsets(int[] nums)
        {
            nums = nums.OrderBy(n => n).ToArray();
            var ret = new List<IList<int>> {new List<int>()};
            Subsets(ret, nums, 0, new List<int>());
            return ret;
        }

        private void Subsets(IList<IList<int>> ret, int[] nums, int index, IList<int> cur)
        {
            // unhappy
            if (index >= nums.Length)
            {
                return;
            }
            //choose
            cur.Add(nums[index]);
            ret.Add(new List<int>(cur));
            Subsets(ret, nums, index + 1, cur);
            cur.RemoveAt(cur.Count - 1);

            //not choose
            Subsets(ret, nums, index + 1, cur);
        }
    }
}
