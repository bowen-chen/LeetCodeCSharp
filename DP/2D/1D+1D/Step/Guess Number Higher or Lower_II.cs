﻿/*
375. Guess Number Higher or Lower II

We are playing the Guess Game. The game is as follows:

I pick a number from 1 to n. You have to guess which number I picked.

Every time you guess wrong, I'll tell you whether the number I picked is higher or lower.

However, when you guess a particular number x, and you guess wrong, you pay $x. You win the game when you guess the number I picked.

Example:

n = 10, I pick 8.

First round:  You guess 5, I tell you that it's higher. You pay $5.
Second round: You guess 7, I tell you that it's higher. You pay $7.
Third round:  You guess 9, I tell you that it's lower. You pay $9.

Game over. 8 is the number I picked.

You end up paying $5 + $7 + $9 = $21.
 

Given a particular n ≥ 1, find out how much money you need to have to guarantee a win.

Hint:

The best strategy to play the game is to minimize the maximum loss you could possibly face. Another strategy is to minimize the expected loss. Here, we are interested in the first scenario.
Take a small example (n = 3). What do you end up paying in the worst case?
Check out this article if you're still stuck.
The purely recursive implementation of minimax would be worthless for even a small n. You MUST use dynamic programming.
As a follow-up, how would you modify your code to solve the problem of minimizing the expected loss, instead of the worst-case loss?
*/

using System;

namespace Demo
{
    public partial class Solution
    {
        public int GetMoneyAmount(int n)
        {
            // dp[i,j], the min cost of guess the nums[i->j]  
            var dp = new int[n + 2, n + 2];

            // dp[i,i] = 0, when rang size is 1
            // k is num range
            for (int step = 2; step <= n; step++)
            {
                for (int i = 1; i + step - 1 <= n; i++)
                {
                    // fill dp[i, i+ step -1]. i+k-1<=n
                    //choose i-> i+step-1 and guess on j
                    var k = i + step - 1;
                    dp[i, k] = int.MaxValue;
                    for (int j = i; j <= k; j++)
                    {
                        // guess on j
                        // j - 1 could be 0, j + 1 could be n+1
                        dp[i, k] = Math.Min(dp[i, k], j + Math.Max(dp[i, j - 1], dp[j + 1, k]));
                    }
                }
            }

            return dp[1, n];
        }
    }
}
