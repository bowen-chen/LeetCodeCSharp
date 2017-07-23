/*
256	Paint House $
There are a row of n houses, each house can be painted with one of the three colors: red, blue or green. The cost of painting each house with a certain color is different. You have to paint all the houses such that no two adjacent houses have the same color.

The cost of painting each house with a certain color is represented by a n x 3 cost matrix. For example, costs[0][0] is the cost of painting house 0 with color red;costs[1][2] is the cost of painting house 1 with color green, and so on... Find the minimum cost to paint all houses.

Note:
All costs are positive integers.
*/

using System;

namespace Demo
{
    public partial class Solution
    {
        public int MinCost(int[,] costs)
        {
            int n = costs.GetLength(0);
            if (n == 0)
            {
                return 0;
            }
            // the min cost last house is painted with RGB
            int r = 0, g = 0, b = 0;
            for (int i = 0; i < n; i++)
            {
                int rr = r, bb = b, gg = g;
                r = costs[i, 0] + Math.Min(bb, gg);
                b = costs[i, 1] + Math.Min(rr, gg);
                g = costs[i, 2] + Math.Min(rr, bb);
            }

            return Math.Min(r, Math.Min(b, g));
        }
    }
}
