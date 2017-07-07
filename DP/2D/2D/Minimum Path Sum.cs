/*
64	Minimum Path Sum
easy, dp
Given a m x n grid filled with non-negative numbers, find a path from top left to bottom right which minimizes the sum of all numbers along its path.

Note: You can only move either down or right at any point in time.
*/
using System;

namespace Demo
{
    public partial class Solution
    {
        public void MinPathSum_Test()
        {
            int[,] m = new int[3,3];
            int c = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    m[i,j] = c++;
                }
            }

            Console.WriteLine(MinPathSum2(m));
        }

        public int MinPathSum2(int[,] grid)
        {
            if (grid == null)
            {
                return 0;
            }

            int m = grid.GetLength(0);
            int n = grid.GetLength(1);
            if (m == 0 || n == 0)
            {
                return 0;
            }

            int[,] dp = new int[m + 1, n + 1];

            for (int i = 0; i <= m; i++)
            {
                dp[i, n] = int.MaxValue;
            }

            for (int i = 0; i < n; i++)
            {
                dp[m, i] = int.MaxValue;
            }

            dp[m - 1, n] = 0;

            for (int r = m - 1; r >= 0; r--)
            {
                for (int c = n - 1; c >= 0; c--)
                {
                    dp[r, c] = Math.Min(dp[r, c + 1], dp[r + 1, c]) + grid[r, c];
                }
            }

            return dp[0, 0];
        }

        public int MinPathSum(int[,] grid)
        {
            if (grid == null)
            {
                return 0;
            }

            int m = grid.GetLength(0);
            int n = grid.GetLength(1);
            if (m == 0 || n ==0)
            {
                return 0;
            }

            int[] dp = new int[n];

            for (int i = 0; i < n; i++)
            {
                dp[i] = int.MaxValue;
            }
            dp[n - 1] = 0;

            for (int r = m - 1; r >= 0; r--)
            {
                var cur = new int[n];
                for (int c = n - 1; c >= 0; c--)
                {
                    if (c == n - 1)
                    {
                        cur[c] = dp[c] + grid[r,c];
                    }
                    else
                    {
                        cur[c] = Math.Min(cur[c + 1], dp[c]) + grid[r, c];
                    }
                }
                dp = cur;
            }

            return dp[0];
        }
    }
}
