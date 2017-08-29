/*
40 Combination Sum II   
easy, recursion, *
Given a collection of candidate numbers (C) and a target number (T), find all unique combinations in C where the candidate numbers sums to T.

Each number in C may only be used once in the combination.

Note:
All numbers (including target) will be positive integers.
Elements in a combination (a1, a2, … , ak) must be in non-descending order. (ie, a1 ≤ a2 ≤ … ≤ ak).
The solution set must not contain duplicate combinations.
For example, given candidate set 10,1,2,7,6,1,5 and target 8, 
A solution set is: 
[1, 7] 
[1, 2, 5] 
[2, 6] 
[1, 1, 6] 
*/

using System;
using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            Array.Sort(candidates);
            IList<IList<int>> ret = new List<IList<int>>();
            CombinationSum2(ret, candidates, target, 0, new List<int>());
            return ret;
        }

        private void CombinationSum2(IList<IList<int>> ret, int[] candidates, int target, int index, List<int> current)
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
            CombinationSum2(ret, candidates, target - candidates[index], index + 1 /*use once*/, current);
            current.RemoveAt(current.Count - 1);

            // not choose
            int c = candidates[index];

            /*unique*/
            while (index + 1 < candidates.Length && candidates[index + 1] == c)
            {
                index++;
            }

            CombinationSum2(ret, candidates, target, index + 1, current);
        }
    }
}
