/*
309	Best Time to Buy and Sell Stock with Cooldown 
easy, dp, *
Say you have an array for which the ith element is the price of a given stock on day i.

Design an algorithm to find the maximum profit. You may complete as many transactions as you like (ie, buy one and sell one share of the stock multiple times) with the following restrictions:

You may not engage in multiple transactions at the same time (ie, you must sell the stock before you buy again).
After you sell your stock, you cannot buy stock on next day. (ie, cooldown 1 day)
Example:

prices = [1, 2, 3, 0, 2]
maxProfit = 3
transactions = [buy, sell, cooldown, buy, sell]
*/

using System;

namespace Demo
{
    public partial class Solution
    {
        public int MaxProfit6(int[] prices)
        {
            int[] sell = new int[prices.Length + 2];
            int[] buy = new int[prices.Length + 2];

            buy[1] = int.MinValue;

            // buy[i] = max(sell[i - 2]-price, buy[i-1])
            // sell[i] = max(buy[i - 1] + price, sell[i - 1])
            for (int i = 2; i < prices.Length + 2; i++)
            {
                int p = prices[i - 2];
                buy[i] = Math.Max(sell[i - 2] - p, buy[i - 1]);
                sell[i] = Math.Max(buy[i - 1] + p, sell[i - 1]);
            }

            return sell[prices.Length + 1];
        }

        public int MaxProfit5(int[] prices)
        {
            // buy[i] = max(sell[i-2]-price, buy[i-1])
            // sell[i] = max(buy[i - 1] + price, sell[i - 1])
            int buy_2 = int.MinValue;
            int sell_2 = 0;
            int buy_1 = int.MinValue;
            int sell_1 = 0;
            foreach (int p in prices)
            {
                int buy = Math.Max(sell_2 - p, buy_1);
                int sell = Math.Max(sell_1, buy_1 + p);
                buy_2 = buy_1;
                sell_2 = sell_1;
                buy_1 = buy;
                sell_1 = sell;
            }

            return sell_1;
        }
    }
}
