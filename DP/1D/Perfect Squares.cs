/*
279	Perfect Squares
easy, dp
Perfect Squares

Given a positive integer n, find the least number of perfect square numbers (for example, 1, 4, 9, 16, ...) which sum to n.

For example, given n = 12, return 3 because 12 = 4 + 4 + 4; given n = 13, return 2 because 13 = 4 + 9.

https://en.wikipedia.org/wiki/Lagrange%27s_four-square_theorem WTH?
*/

using System;

namespace Demo
{
    public partial class Solution
    {
        public void Test_NumSquares()
        {
            Console.WriteLine(NumSquares(7927));
            Console.WriteLine(NumSquares(2));
        }

        public int NumSquares(int n)
        {
            //dp[i] = min(dp[i-j*j] + 1)
            var dp = new int[n + 1];
            for (int i = 1; i <= n; i++)
            {
                dp[i] = int.MaxValue;
                for (int j = 1; j*j <= i; j++)
                {
                    dp[i] = Math.Min(dp[i], dp[i - j*j] + 1);
                }
            }

            return dp[n];
        }
    }
}
