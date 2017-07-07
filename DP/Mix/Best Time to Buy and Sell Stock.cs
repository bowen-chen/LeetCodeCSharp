/*
121	Best Time to Buy and Sell Stock
easy
Say you have an array for which the ith element is the price of a given stock on day i.

If you were only permitted to complete at most one transaction (ie, buy one and sell one share of the stock), design an algorithm to find the maximum profit.
*/

using System;

namespace Demo
{
    public partial class Solution
    {
        public int MaxProfit(int[] prices)
        {
            int max = 0;
            int low = int.MaxValue;
            foreach (int i in prices)
            {
                if (i <= low)
                {
                    low = i;
                }
                else
                {
                    var profit = i - low;
                    max = Math.Max(max, profit);
                }
            }
            return max;
        }
    }
}
