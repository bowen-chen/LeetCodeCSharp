/*
70	Climbing Stairs
easy, dp
You are climbing a stair case. It takes n steps to reach to the top.

Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?
*/

namespace Demo
{
    public partial class Solution
    {
        public int ClimbStairs(int n)
        {
            if (n <=2)
            {
                return n;
            }
            int p1 = 1;
            int p2 = 2;
            int cur = 0;

            // dp[i] = dp[i-1] + dp[i-2]
            for (int i = 3; i <= n; i++)
            {
                cur = p1 + p2;
                p1 = p2;
                p2 = cur;

            }

            return cur;
        }
    }
}
