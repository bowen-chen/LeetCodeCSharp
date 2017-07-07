/*
322	Coin Change
easy, dp
You are given coins of different denominations and a total amount of money amount. Write a function to compute the fewest number of coins that you need to make up that amount. If that amount of money cannot be made up by any combination of the coins, return -1.

Example 1:
coins = [1, 2, 5], amount = 11
return 3 (11 = 5 + 5 + 1)

Example 2:
coins = [2], amount = 3
return -1.

Note:
You may assume that you have an infinite number of each kind of coin.
*/

using System;
using System.Linq;

namespace Demo
{
    public partial class Solution
    {
        public int CoinChange2(int[] coins, int amount)
        {
            int[] dp = new int[amount + 1];
            dp[0] = 0;
            for (int i = 1; i <= amount; i++)
            {
                dp[i] = int.MaxValue;
                foreach (int c in coins)
                {
                    if (c <= i && dp[i - c] != int.MaxValue)
                    {
                        dp[i] = Math.Min(dp[i], dp[i - c] + 1);
                    }
                }
            }
            return dp[amount] == int.MaxValue ? -1 : dp[amount];
        }

        public int CoinChange(int[] coins, int amount)
        {
            coins = coins.Distinct().OrderByDescending(c => c).ToArray();
            int ret = -1;
            CoinChange(coins, amount, 0, 0, ref ret);
            return ret;
        }

        public void CoinChange(int[] coins, int amount, int index, int count, ref int currentBest)
        {
            if (currentBest != -1 && count >= currentBest)
            {
                return;
            }

            if (amount == 0)
            {
                currentBest = count;
            }

            if (index >= coins.Length)
            {
                return;
            }

            int coin = coins[index];
            if (amount >= coin)
            {
                CoinChange(coins, amount - coin, index, count + 1, ref currentBest);
            }

            CoinChange(coins, amount, index + 1, count, ref currentBest);
        }
    }
}
