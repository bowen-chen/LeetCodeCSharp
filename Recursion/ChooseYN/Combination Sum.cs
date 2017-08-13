/*
39	Combination Sum
easy, recursive
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
using System.Linq;

namespace Demo
{
    public partial class Solution
    {
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            candidates = candidates.OrderBy(c => c).Distinct()/*unique combination*/.ToArray();
            IList<IList<int>> ret = new List<IList<int>>();
            CombinationSum(ret, candidates, target, 0, new List<int>());
            return ret;
        }

        private void CombinationSum(IList<IList<int>> ret, int[] candidates, int target, int index, List<int> current)
        {
            // happy
            if (target == 0)
            {
                ret.Add(new List<int>(current));
                return;
            }

            // unhappy
            if (index >= candidates.Length || target < candidates[index])
            {
                return;
            }

            // choose
            current.Add(candidates[index]);
            CombinationSum(ret, candidates, target - candidates[index], index /*use multiple times*/, current);
            current.RemoveAt(current.Count - 1);

            // not choose
            CombinationSum(ret, candidates, target, index + 1, current);
        }
    }
}
