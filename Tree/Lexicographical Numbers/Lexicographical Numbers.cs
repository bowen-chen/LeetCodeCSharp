/*
386. Lexicographical Numbers
easy
Given an integer n, return 1 - n in lexicographical order.

For example, given 13, return: [1,10,11,12,13,2,3,4,5,6,7,8,9].

Please optimize your algorithm to use less time and space. The input size may be as large as 5,000,000.
*/
using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public IList<int> LexicalOrder(int n)
        {
            List<int> res = new List<int>();
            for (int i = 1; i <= 9; ++i)
            {
                LexicalOrder(i, n, res);
            }

            return res;
        }

        // DFS
        private void LexicalOrder(int cur, int n, List<int> res)
        {
            if (cur > n)
            {
                return;
            }

            res.Add(cur);
            for (int i = 0; i <= 9; ++i)
            {
                LexicalOrder(cur*10 + i, n, res);
            }
        }
    }
}
