/*
646. Maximum Length of Pair Chain
You are given n pairs of numbers. In every pair, the first number is always smaller than the second number.

Now, we define a pair (c, d) can follow another pair (a, b) if and only if b < c. Chain of pairs can be formed in this fashion.

Given a set of pairs, find the length longest chain which can be formed. You needn't use up all the given pairs. You can select pairs in any order.

Example 1:
Input: [[1,2], [2,3], [3,4]]
Output: 2
Explanation: The longest chain is [1,2] -> [3,4]
Note:
The number of given pairs will be in the range [1, 1000].
*/
using System;
using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public int FindLongestChain(int[,] pairs)
        {
            var ps= new int[pairs.GetLength(0)][];
            for (int i = 0; i < pairs.GetLength(0);i++)
            {
                ps[i] = new[] {pairs[i, 0], pairs[i, 1]};
            }

            Array.Sort(ps, Comparer<int[]>.Create((a, b) => a[0] - b[0]));
            int res = 1;
            int last = ps[0][1]; 
            for (int i = 1; i < ps.Length; i++)
            {
                if (ps[i][0] <= last)
                {
                    last = Math.Min(last, ps[i][1]);
                }
                else
                {
                    last = ps[i][1];
                    res++;
                }
            }

            return res;
        }
    }
}
