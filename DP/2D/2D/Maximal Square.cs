/*
221	Maximal Square
easy
Given a 2D binary matrix filled with 0's and 1's, find the largest square containing all 1's and return its area.

For example, given the following matrix:

1 0 1 0 0
1 0 1 1 1
1 1 1 1 1
1 0 0 1 0
Return 4.
*/

using System;

namespace Demo
{
    public partial class Solution
    {
        public void Test_MaximalSquare()
        {
            MaximalSquare2(new [,] {{'0', '0'}});
        }

        public int MaximalSquare(char[,] matrix)
        {
            int max = 0;
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            // sqaure ending at matrix[i,j]
            var dp = new int[m+1, n+1];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] == '0')
                    {
                        dp[i + 1, j + 1] = 0;
                    }
                    else
                    {
                        dp[i + 1, j + 1] = 1 + Math.Min(Math.Min(dp[i, j], dp[i, j + 1]), dp[i + 1, j]);
                        max = Math.Max(max, dp[i + 1, j + 1]);
                    }
                }
            }
            return max*max;
        }

        public int MaximalSquare2(char[,] matrix)
        {
            int max = 0;
            var pre = new int[matrix.GetLength(1) + 1];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var current = new int[matrix.GetLength(1) + 1];
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == '0')
                    {
                        current[j + 1] = 0;
                    }
                    else
                    {
                        current[j + 1] = 1 + Math.Min(Math.Min(pre[j], pre[j + 1]), current[j]);
                        max = Math.Max(max, current[j + 1]);
                    }
                }

                pre = current;
            }
            return max * max;
        }
    }
}
