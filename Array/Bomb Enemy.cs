/*
361	Bomb Enemy
Given a 2D grid, each cell is either a wall 'W', an enemy 'E' or empty '0' (the number zero), return the maximum enemies you can kill using one bomb.
The bomb kills all the enemies in the same row and column from the planted point until it hits the wall since the wall is too strong to be destroyed.
Note that you can only put the bomb at an empty cell.

Example:
For the given grid

0 E 0 0
E 0 W E
0 E 0 0

return 3. (Placing a bomb at (1,1) kills 3 enemies)
*/

using System;

namespace Demo.Misc
{
    public partial class Solution
    {
        public int MaxKilledEnemies(char[,] grid)
        {
            int m = grid.GetLength(0);
            int n = grid.GetLength(1);
            int res = 0;

            if (m == 0 || n == 0)
            {
                return 0;
            }

            int[,] v1 = new int[m, n]; // from left
            int[,] v2 = new int[m, n]; // from right
            int[,] v3 = new int[m, n]; // from above
            int[,] v4 = new int[m, n]; // from below

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int t = (j == 0 || grid[i,j] == 'W') ? 0 : v1[i,j - 1];
                    v1[i,j] = grid[i,j] == 'E' ? t + 1 : t;
                }

                for (int j = n - 1; j >= 0; --j)
                {
                    int t = (j == n - 1 || grid[i,j] == 'W') ? 0 : v2[i,j + 1];
                    v2[i,j] = grid[i,j] == 'E' ? t + 1 : t;
                }
            }

            for (int j = 0; j < n; ++j)
            {
                for (int i = 0; i < m; ++i)
                {
                    int t = (i == 0 || grid[i,j] == 'W') ? 0 : v3[i - 1,j];
                    v3[i,j] = grid[i,j] == 'E' ? t + 1 : t;
                }

                for (int i = m - 1; i >= 0; --i)
                {
                    int t = (i == m - 1 || grid[i,j] == 'W') ? 0 : v4[i + 1,j];
                    v4[i,j] = grid[i,j] == 'E' ? t + 1 : t;
                }
            }

            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (grid[i,j] == '0')
                    {
                        res = Math.Max(res, v1[i,j] + v2[i,j] + v3[i,j] + v4[i,j]);
                    }
                }
            }

            return res;
        }
    }
}
