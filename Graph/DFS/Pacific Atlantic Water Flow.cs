/*
417. Pacific Atlantic Water Flow

Given an m x n matrix of non-negative integers representing the height of each unit cell in a continent, the "Pacific ocean" touches the left and top edges of the matrix and the "Atlantic ocean" touches the right and bottom edges.

Water can only flow in four directions (up, down, left, or right) from a cell to another one with height equal or lower.

Find the list of grid coordinates where water can flow to both the Pacific and Atlantic ocean.

Note:
The order of returned grid coordinates does not matter.
Both m and n are less than 150.
Example:

Given the following 5x5 matrix:

  Pacific ~   ~   ~   ~   ~ 
       ~  1   2   2   3  (5) *
       ~  3   2   3  (4) (4) *
       ~  2   4  (5)  3   1  *
       ~ (6) (7)  1   4   5  *
       ~ (5)  1   1   2   4  *
          *   *   *   *   * Atlantic

Return:

[[0, 4], [1, 3], [1, 4], [2, 2], [3, 0], [3, 1], [4, 0]] (positions with parentheses in above matrix).
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public IList<int[]> PacificAtlantic(int[,] matrix)
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            var res = new List<int[]>();
            if (m == 0 || n == 0)
            {
                return res;
            }

            var pacific = new bool[m, n];
            var atlantic = new bool[m, n];
            for (int i = 0; i < m; ++i)
            {
                PacificAtlantic(matrix, pacific, int.MinValue, i, 0);
                PacificAtlantic(matrix, atlantic, int.MinValue, i, n - 1);
            }

            for (int i = 0; i < n; ++i)
            {
                PacificAtlantic(matrix, pacific, int.MinValue, 0, i);
                PacificAtlantic(matrix, atlantic, int.MinValue, m - 1, i);
            }

            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (pacific[i, j] && atlantic[i, j])
                    {
                        res.Add(new[] {i, j});
                    }
                }
            }

            return res;
        }

        private void PacificAtlantic(int[,] matrix, bool[,] visited, int pre, int i, int j)
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            if (i < 0 || i >= m || j < 0 || j >= n || visited[i, j] || matrix[i, j] < pre)
            {
                return;
            }

            visited[i, j] = true;
            PacificAtlantic(matrix, visited, matrix[i, j], i + 1, j);
            PacificAtlantic(matrix, visited, matrix[i, j], i - 1, j);
            PacificAtlantic(matrix, visited, matrix[i, j], i, j + 1);
            PacificAtlantic(matrix, visited, matrix[i, j], i, j - 1);
        }
    }
}
