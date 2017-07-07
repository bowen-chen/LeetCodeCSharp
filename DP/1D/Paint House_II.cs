/*
265	Paint House II $
There are a row of n houses, each house can be painted with one of the k colors. The cost of painting each house with a certain color is different. You have to paint all the houses such that no two adjacent houses have the same color.

The cost of painting each house with a certain color is represented by a n x k cost matrix. For example, costs[0][0] is the cost of painting house 0 with color 0; costs[1][2] is the cost of painting house 1 with color 2, and so on... Find the minimum cost to paint all houses.

Note:
All costs are positive integers.

Follow up:
Could you solve it in O(nk) runtime?
*/

namespace Demo
{
    public partial class Solution
    {
        public int MinCostII(int[,] costs)
        {
            if (costs == null)
            {
                return 0;
            }
            int len = costs.GetLength(0);
            int k = costs.GetLength(1);
            if (len == 0 || k == 0)
            {
                return 0;
            }

            int min_1 = 0, min_2 = 0;
            int min_1_color = -1;
            for (int i = 0; i < len; i++)
            {
                int pre_min_1 = min_1;
                int pre_min_2 = min_2;
                int pre_min_1_color = min_1_color;
                min_1 = int.MaxValue;
                min_2 = int.MaxValue;
                for (int j = 0; j < k; j++)
                {
                    int current;
                    if (j != pre_min_1_color)
                    {
                        current = pre_min_1 + costs[i, j];
                    }
                    else
                    {
                        current = pre_min_2 + costs[i, j];
                    }

                    if (current <= min_1)
                    {
                        min_2 = min_1;
                        min_1_color = j;
                        min_1 = current;
                    }
                    else if (current < min_2)
                    {
                        min_2 = current;
                    }
                }
            }
            return min_1;
        }
    }
}
