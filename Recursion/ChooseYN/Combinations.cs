/*
77	Combinations
easy, recursive, *
Given two integers n and k, return all possible combinations of k numbers out of 1 ... n.

For example,
If n = 4 and k = 2, a solution is:

[
  [2,4],
  [3,4],
  [2,3],
  [1,2],
  [1,3],
  [1,4],
]
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public IList<IList<int>> Combine(int n, int k)
        {
            var ret = new List<IList<int>>();
            Combine(ret, n, k, new List<int>());
            return ret;
        }

        public void Combine(IList<IList<int>> ret, int n, int k, List<int> c)
        {
            if (k == 0)
            {
                ret.Add(new List<int>(c));
                return;
            }

            if (n < k)
            {
                return;
            }

            c.Add(n);
            Combine(ret, n - 1, k - 1, c);
            c.RemoveAt(c.Count - 1);

            Combine(ret, n - 1, k, c);
        }
    }
}
