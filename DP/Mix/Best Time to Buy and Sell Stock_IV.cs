/*
188	Best Time to Buy and Sell Stock IV
hard, dp
Say you have an array for which the ith element is the price of a given stock on day i.

Design an algorithm to find the maximum profit. You may complete at most k transactions.

Note:
You may not engage in multiple transactions at the same time (ie, you must sell the stock before you buy again).
*/
using System;

namespace Demo
{
    public partial class Solution
    {
        /**
         * dp[i, j] represents the max profit up until prices[j] using at most i transactions. 
         * dp[i, j] = max(dp[i, j-1] /don't sell on j/ , 
                          prices[j] - prices[jj] + dp[i-1, jj] /sell on j when brought on jj/) { jj in range of [0, j-1] }
         *          = max(dp[i, j-1], prices[j] + max(dp[i-1, jj] - prices[jj]) /the max balance, brought on jj/) 
         * dp[0, j] = 0; 0 transactions makes 0 profit
         * dp[i, 0] = 0; if there is only one price data point you can't make any transaction.
         */
        public int MaxProfit(int k, int[] prices)
        {
            int n = prices.Length;
            if (n <= 1)
            {
                return 0;
            }

            // if k >= n/2, then you can make maximum number of transactions.
            // fast track
            if (k >= n / 2)
            {
                int maxPro = 0;
                for (int i = 1; i < n; i++)
                {
                    if (prices[i] > prices[i - 1])
                        maxPro += prices[i] - prices[i - 1];
                }
                return maxPro;
            }

            int[,] dp = new int[k + 1, prices.Length];
            for (int i = 1; i <= k; i++)
            {
                // max of max(dp[i-1, jj] - prices[jj])
                // local max is the max balance at <= j-1 with status of bought
                int localMax = dp[i - 1, 0] - prices[0];
                for (int j = 1; j < n; j++)
                {
                    dp[i, j] = Math.Max(dp[i, j - 1], prices[j] + localMax);
                    localMax = Math.Max(localMax, dp[i - 1, j] - prices[j]);
                }
            }

            return dp[k,n - 1];
        }
    }
}
