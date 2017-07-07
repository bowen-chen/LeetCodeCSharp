/*
364 Nested List Weight Sum II
easy, tree
Given a nested list of integers, return the sum of all integers in the list weighted by their depth.

Each element is either an integer, or a list -- whose elements may also be integers or other lists.

Different from the previous question where weight is increasing from root to leaf, now the weight is defined from bottom up. i.e., the leaf level integers have weight 1, and the root level integers have the largest weight.

Example 1:
Given the list [[1,1],2,[1,1]], return 8. (four 1's at depth 1, one 2 at depth 2)

Example 2:
Given the list [1,[4,[6]]], return 17. (one 1 at depth 3, one 4 at depth 2, and one 6 at depth 1; 1*3 + 4*2 + 6*1 = 17) 
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public int DepthSumInverse(IList<NestedInteger> nestedList)
        {
            int unweighted = 0;
            int weighted = 0;
            Queue<NestedInteger> q = new Queue<NestedInteger>();
            foreach (var n in nestedList)
            {
                q.Enqueue(n);
            }

            q.Enqueue(null);
            while (q.Count != 0)
            {
                var c = q.Dequeue();
                if (c == null)
                {
                    weighted += unweighted;
                    if (q.Count > 0)
                    {
                        q.Enqueue(null);
                    }
                }
                else if(c.IsInteger())
                {
                    unweighted += c.GetInteger();
                }
                else
                {
                    foreach (var n in c.GetList())
                    {
                        q.Enqueue(n);
                    }
                }
            }
            return weighted;
        }
    }
}