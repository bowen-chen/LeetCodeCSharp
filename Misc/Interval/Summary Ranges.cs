/*
easy
Summary Ranges

Given a sorted integer array without duplicates, return the summary of its ranges.

For example, given [0,1,2,4,5,7], return ["0->2","4->5","7"].
*/
using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public IList<string> SummaryRanges(int[] nums)
        {
            var ret = new List<string>();
            if (nums == null || nums.Length == 0)
            {
                return ret;
            }
            int start = nums[0];
            int end = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                if (end + 1 != nums[i])
                {
                    ret.Add(start == end ? start.ToString() : start + "->" + end);
                    start = nums[i];
                }

                end = nums[i];
            }
            ret.Add(start == end ? start.ToString() : start + "->" + end);
            return ret;
        }
    }
}
