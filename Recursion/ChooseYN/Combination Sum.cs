/*
39	Combination Sum
easy, recursive, *
Given a set of candidate numbers (C) and a target number (T), find all unique combinations in C where the candidate numbers sums to T.

The same repeated number may be chosen from C unlimited number of times.

Note:
All numbers (including target) will be positive integers.
Elements in a combination (a1, a2, … , ak) must be in non-descending order. (ie, a1 ≤ a2 ≤ … ≤ ak).
The solution set must not contain duplicate combinations.
For example, given candidate set 2,3,6,7 and target 7, 
A solution set is: 
[7] 
[2, 2, 3] 
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            IList<IList<int>> ret = new List<IList<int>>();
            CombinationSum(ret, candidates, 0, target, new List<int>());
            return ret;
        }

        public void CombinationSum(IList<IList<int>> ret, int[] candidates, int index, int target, List<int> c)
        {
            if (target == 0)
            {
                ret.Add(new List<int>(c));
                return;
            }

            if (index >= candidates.Length || target < 0)
            {
                return;
            }

            c.Add(candidates[index]);
            CombinationSum(ret, candidates, index, target - candidates[index], c);
            c.RemoveAt(c.Count - 1);

            CombinationSum(ret, candidates, index + 1, target, c);
        }
    }
}
