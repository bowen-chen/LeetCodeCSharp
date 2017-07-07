/*
562. Longest Line of Consecutive One in Matrix

Given a 01 matrix M, find the longest line of consecutive one in the matrix. The line could be horizontal, vertical, diagonal or anti-diagonal.

Example:

Input:
[[0,1,1,0],
 [0,1,1,0],
 [0,0,0,1]]
Output: 3
Hint: The number of elements in the given matrix will not exceed 10,000.
*/

using System;

namespace Demo
{
    public partial class Solution
    {
        public int LongestLine(int[,] M)
        {
            int m = M.GetLength(0);
            int n = M.GetLength(1);

            // h[x][y] = M[x,y] * (h[x - 1][y]  + 1)
            // v[x][y] = M[x,y] * (v[x][y - 1] + 1)
            // d[x][y] = M[x,y] * (d[x - 1][y - 1] + 1)
            // a[x][y] = M[x,y] * (a[x + 1][y - 1] + 1)
            //dp[x][hvda]
            var dp = new int[m + 2, 4];
            int res = 0;
            for (int i=0;i<m; i++)
            {
                var dp2 = new int[m + 2, 4];
                for (int j = 0; j < n; j++)
                {
                    if (M[i, j] == 1)
                    {
                        int a = i + 1;
                        dp2[a, 0] = dp2[a - 1,0] + 1;
                        res = Math.Max(res, dp2[a, 0]);
                        dp2[a, 1] = dp[a, 1] + 1;
                        res = Math.Max(res, dp2[a, 1]);
                        dp2[a, 2] = dp[a - 1, 2] + 1;
                        res = Math.Max(res, dp2[a, 2]);
                        dp2[a, 3] = dp[a + 1, 3] + 1;
                        res = Math.Max(res, dp2[a, 3]);
                    }
                }
                dp = dp2;
            }

            return res;
        }
    }
}
