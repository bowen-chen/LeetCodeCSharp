/*
329	Longest Increasing Path in a Matrix
easy, dp
Given an integer matrix, find the length of the longest increasing path.

From each cell, you can either move to four directions: left, right, up or down. You may NOT move diagonally or move outside of the boundary (i.e. wrap-around is not allowed).

Example 1:

nums = [
  [9,9,4],
  [6,6,8],
  [2,1,1]
]
Return 4
The longest increasing path is [1, 2, 6, 9].

Example 2:

nums = [
  [3,4,5],
  [3,2,6],
  [2,2,1]
]
Return 4
The longest increasing path is [3, 4, 5, 6]. Moving diagonally is not allowed.
*/

using System;

namespace Demo
{
    public partial class Solution
    {
        public int LongestIncreasingPath(int[,] matrix)
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            int[,] dp = new int[m, n];
            int ret = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    LongestIncreasingPath(matrix, dp, i, j);
                    ret = Math.Max(ret, dp[i, j]);
                }
            }

            return ret;
        }

        private int LongestIncreasingPath(int[,] matrix, int[,] dp, int i, int j)
        {
            if (dp[i, j] != 0)
            {
                return dp[i, j];
            }

            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);

            int max = 0;
            foreach (var dir in new[] {new[] {0, 1}, new[] {0, -1}, new[] {1, 0}, new[] {-1, 0}})
            {
                int a = i + dir[0];
                int b = j + dir[1];
                if (a >= 0 && a < m && b >= 0 && b < n && matrix[a, b] > matrix[i, j])
                {
                    max = Math.Max(max, LongestIncreasingPath(matrix, dp, a, b));
                }
            }

            dp[i, j] = max + 1;
            return dp[i, j];
        }
    }
}
