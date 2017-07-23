/*
354. Russian Doll Envelopes
easy
You have a number of envelopes with widths and heights given as a pair of integers (w, h). One envelope can fit into another if and only if both the width and height of one envelope is greater than the width and height of the other envelope.

What is the maximum number of envelopes can you Russian doll? (put one inside other)

Example:
Given envelopes = [[5,4],[6,4],[6,7],[2,3]], the maximum number of envelopes you can Russian doll is 3 ([2,3] => [5,4] => [6,7]).
*/

using System;
using System.Linq;

namespace Demo
{
    public partial class Solution
    {
        public int MaxEnvelopes(int[,] envelopes)
        {
            int res = 0;
            int n = envelopes.GetLength(0);

            int[][] jagged = new int[n][];
            for (int i = 0; i < n; i++)
            {
                jagged[i] = new[]{ envelopes[i, 0], envelopes[i, 1]};
            }

            jagged = jagged.OrderBy(e => e[0]).ThenByDescending(e => e[1]).ToArray();
            
            int[] dp = new int[n];
            for (int i = 0; i < n; i++)
            {
                dp[i] = 1;
                for (int j = 0; j < i; j++)
                {
                    if (jagged[i][0] > jagged[j][0] && jagged[i][1] > jagged[j][1])
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                    }
                }

                res = Math.Max(res, dp[i]);
            }

            return res;
        }
    }
}
