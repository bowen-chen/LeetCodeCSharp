﻿/*
463. Island Perimeter
*
You are given a map in form of a two-dimensional integer grid where 1 represents land and 0 represents water. Grid cells are connected horizontally/vertically (not diagonally). The grid is completely surrounded by water, and there is exactly one island (i.e., one or more connected land cells). The island doesn't have "lakes" (water inside that isn't connected to the water around the island). One cell is a square with side length 1. The grid is rectangular, width and height don't exceed 100. Determine the perimeter of the island.

Example:

[[0,1,0,0],
 [1,1,1,0],
 [0,1,0,0],
 [1,1,0,0]]

Answer: 16
Explanation: The perimeter is the 16 yellow stripes in the image below:
*/

namespace Demo
{
    public partial class Solution
    {
        public int IslandPerimeter(int[,] grid)
        {
            if (grid== null || grid.Length ==0) return 0;
            int m = grid.GetLength(0), n = grid.GetLength(1), res = 0;
            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (grid[i,j] == 0) continue;
                    if (j == 0 || grid[i,j - 1] == 0) ++res;
                    if (i == 0 || grid[i - 1,j] == 0) ++res;
                    if (j == n - 1 || grid[i,j + 1] == 0) ++res;
                    if (i == m - 1 || grid[i + 1,j] == 0) ++res;
                }
            }
            return res;
        }

        public int IslandPerimeter2(int[,] grid)
        {
            if (grid == null || grid.Length == 0) return 0;
            int m = grid.GetLength(0), n = grid.GetLength(1), res = 0;
            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (grid[i,j] == 0) continue;
                    res += 4;
                    if (i > 0 && grid[i - 1,j] == 1) res -= 2;
                    if (j > 0 && grid[i,j - 1] == 1) res -= 2;
                }
            }
            return res;
        }
    }
}
