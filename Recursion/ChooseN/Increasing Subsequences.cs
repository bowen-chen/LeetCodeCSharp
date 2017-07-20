/*
491. Increasing Subsequences
Given an integer array, your task is to find all the different possible increasing subsequences of the given array, and the length of an increasing subsequence should be at least 2 .

Example:
Input: [4, 6, 7, 7]
Output: [[4, 6], [4, 7], [4, 6, 7], [4, 6, 7, 7], [6, 7], [6, 7, 7], [7,7], [4,7,7]]
Note:
The length of the given array will not exceed 15.
The range of integer in the given array is [-100,100].
The given array may contain duplicates, and two equal integers should also be considered as a special case of increasing sequence.
*/
using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    public partial class Solution
    {
        public IList<IList<int>> FindSubsequences(int[] nums)
        {
            var res = new List<IList<int>>();
            var cur = new List<int>();
            FindSubsequences(nums, 0, cur, res);
            return res;
        }

        public void FindSubsequences(int[] nums, int start, List<int> cur, List<IList<int>> res)
        {
            if (cur.Count >= 2)
            {
                res.Add(cur.ToList());
            }

            var st = new HashSet<int>();
            for (int i = start; i < nums.Length; ++i)
            {
                if ((cur.Count != 0 && cur[cur.Count - 1] > nums[i]) || st.Contains(nums[i]))
                {
                    continue;
                }

                cur.Add(nums[i]);

                // we only choose nums[i] once at this location
                st.Add(nums[i]);
                FindSubsequences(nums, i + 1, cur, res);
                cur.RemoveAt(cur.Count - 1);
            }
        }
    }
}
