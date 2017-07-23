/*
276	Paint Fence $
There is a fence with n posts, each post can be painted with one of the k colors.

You have to paint all the posts such that no more than two adjacent fence posts have the same color.

Return the total number of ways you can paint the fence.

Note: n and k are non-negative integers.
*/

namespace Demo
{
    public partial class Solution
    {
        public int NumWays(int n, int k)
        {
            if (n <= 1)
            {
                return n * k;
            }

            // ways, diff color ending at i
            var dp1 = new int[n];
            dp1[1] = k * (k - 1);

            // ways, same color ending at i
            var dp2 = new int[n];
            dp2[1] = k;

            for (int i = 2; i < n; i++)
            {
                dp1[i] = (dp1[i - 1] + dp2[i - 1]) * (k - 1);
                dp2[i] = dp1[i - 1];
            }

            return (dp1[n - 1] + dp1[n - 1]);
        }

        public int NumWays2(int n, int k)
        {
            if (n <= 1)
                return n * k;

            int diffColor = k * (k - 1);
            int sameColor = k;
            for (int i = 2; i < n; i++)
            {
                int preDiffColor = diffColor;
                int preSameColor = sameColor;
                diffColor = (preDiffColor + preSameColor) * (k - 1);
                sameColor = preDiffColor;
            }

            return (diffColor + sameColor);
        }
    }
}
