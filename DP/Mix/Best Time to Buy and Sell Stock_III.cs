/*
123	Best Time to Buy and Sell Stock III
medium, dp
Say you have an array for which the ith element is the price of a given stock on day i.

Design an algorithm to find the maximum profit. You may complete at most two transactions.

Note:
You may not engage in multiple transactions at the same time (ie, you must sell the stock before you buy again).
*/

using System;

namespace Demo
{
    public partial class Solution
    {
        public int MaxProfit3(int[] prices)
        {
            // null check
            int len = prices.Length;
            if (len == 0)
                return 0;

            // max profit till 0->i
            int[] dp = new int[len];
            int low = prices[0];

            // forward, calculate max profit until this time
            for (int i = 0; i < len; ++i)
            {
                low = Math.Min(low, prices[i]);
                if (i > 0)
                {
                    dp[i] = Math.Max(dp[i - 1], prices[i] - low);
                }
            }

            // max profit from i-end
            int[] dp2 = new int[len];
            int high = prices[len - 1];
            int maxProfit = 0;

            // backward, calculate max profit from now, and the sum with history
            for (int i = len - 1; i >= 0; --i)
            {
                high = Math.Max(high, prices[i]);
                if (i < len - 1)
                {
                    dp2[i] = Math.Max(dp2[i + 1], high - prices[i]);
                }

                maxProfit = Math.Max(maxProfit, dp[i] + dp2[i]);
            }

            return maxProfit;
        }
    }
}
