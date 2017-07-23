/*
63	Unique Paths II
easy, dp
Unique Paths II

Follow up for "Unique Paths":

Now consider if some obstacles are added to the grids. How many unique paths would there be?

An obstacle and empty space is marked as 1 and 0 respectively in the grid.

For example,
There is one obstacle in the middle of a 3x3 grid as illustrated below.

[
  [0,0,0],
  [0,1,0],
  [0,0,0]
]
The total number of unique paths is 2.

Note: m and n will be at most 100.
*/

namespace Demo
{
    public partial class Solution
    {
        public int UniquePathsWithObstacles(int[,] obstacleGrid)
        {
            int m = obstacleGrid.GetLength(0);
            int n = obstacleGrid.GetLength(1);
            int[,] dp = new int[m + 1, n + 1];
            dp[m - 1, n] = 1;
            for (int r = m - 1; r >= 0; r--)
            {
                for (int c = n - 1; c >= 0; c--)
                {
                    if (obstacleGrid[r, c] == 1)
                    {
                        dp[r, c] = 0;
                    }
                    else
                    {
                        dp[r, c] = dp[r + 1, c] + dp[r, c + 1];
                    }
                }
            }

            return dp[0, 0];
        }
    }
}
