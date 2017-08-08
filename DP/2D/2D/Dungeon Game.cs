/*
174	Dungeon Game
easy, dp
The demons had captured the princess (P) and imprisoned her in the bottom-right corner of a dungeon. The dungeon consists of M x N rooms laid out in a 2D grid. Our valiant knight (K) was initially positioned in the top-left room and must fight his way through the dungeon to rescue the princess.

The knight has an initial health point represented by a positive integer. If at any point his health point drops to 0 or below, he dies immediately.

Some of the rooms are guarded by demons, so the knight loses health (negative integers) upon entering these rooms; other rooms are either empty (0's) or contain magic orbs that increase the knight's health (positive integers).

In order to reach the princess as quickly as possible, the knight decides to move only rightward or downward in each step.


Write a function to determine the knight's minimum initial health so that he is able to rescue the princess.

For example, given the dungeon below, the initial health of the knight must be at least 7 if he follows the optimal path RIGHT-> RIGHT -> DOWN -> DOWN.

-2 (K)	-3	3
-5	    -10	1
10	    30	-5 (P)

    10, -4
35, 25, -5

Notes:

The knight's health has no upper bound.
Any room can contain threats or power-ups, even the first room the knight enters and the bottom-right room where the princess is imprisoned.
*/
using System;

namespace Demo
{
    public partial class Solution
    {
        public void Test_CalculateMinimumHP()
        {
            CalculateMinimumHP(new [,] {{-2, -3, 3}, {-5, -10, 1}, {10, 30, -5}});
            CalculateMinimumHP(new[,] { { -2}, { 1 } });
        }

        public int CalculateMinimumHP(int[,] dungeon)
        {
            int m = dungeon.GetLength(0);
            int n = dungeon.GetLength(1);
            var dp = new int[n + 1];
            for (int i = 0; i < n-1; i++)
            {
                dp[i] = int.MinValue;
            }

            dp[n-1] = 0;
            dp[n] = int.MinValue;
            for (int i = m - 1; i >= 0; i--)
            {
                var newrow = new int[n + 1];

                // block the right wall
                newrow[n] = int.MinValue;
                for (int j = n - 1; j >= 0; j--)
                {
                    // tomorrow's health point cannot save your life today
                    int need = Math.Max(newrow[j + 1], dp[j]);
                    if (need > 0)
                    {
                        need = 0;
                    }

                    newrow[j] = need + dungeon[i, j];
                }

                dp = newrow;
            }

            return dp[0] > 0 ? 1 : -dp[0] + 1;
        }
    }
}
