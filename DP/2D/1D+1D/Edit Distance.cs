/*
72	Edit Distance
medium, dp
Given two words word1 and word2, find the minimum number of steps required to convert word1 to word2. (each operation is counted as 1 step.)

You have the following 3 operations permitted on a word:

a) Insert a character
b) Delete a character
c) Replace a character
*/
using System;

namespace Demo
{
    public partial class Solution
    {
        /*
        dp[i,0] = i;
        dp[0,j] = j;
        dp[i,j] = dp[i - 1,j - 1], if word1[i - 1] = word2[j - 1];
        dp[i,j] = min(dp[i - 1,j - 1] + 1 (replace), dp[i - 1,j] + 1 (remove), dp[i,j - 1] + 1 (add)), otherwise.
        */
        public int MinDistance(string word1, string word2)
        {
            int m = word1.Length;
            int n = word2.Length;

            // min distance from word1[0,m] to word2[0,n]
            int[,] dp = new int[m + 1, n + 1];
            for (int i = 1; i <= m; i++)
            {
                dp[i, 0] = i;
            }

            for (int j = 1; j <= n; j++)
            {
                dp[0, j] = j;
            }

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (word1[i - 1] == word2[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1];
                    }
                    else
                    {
                        // replace, add, add
                        dp[i, j] = Math.Min(dp[i - 1, j - 1] + 1, Math.Min(dp[i, j - 1] + 1, dp[i - 1, j] + 1));
                    }
                }
            }
            return dp[m, n];
        }

        public int MinDistance2(string word1, string word2)
        {
            int m = word1.Length;
            int n = word2.Length;
            int[] dp = new int[m + 1];
            for (int i = 1; i <= m; i++)
            {
                dp[i] = i;
            }

            for (int j = 1; j <= n; j++)
            {
                int pre = dp[0];
                dp[0] = j;
                for (int i = 1; i <= m; i++)
                {
                    int temp = dp[i];
                    if (word1[i - 1] == word2[j - 1])
                    {
                        dp[i] = pre;
                    }
                    else
                    {
                        dp[i] = Math.Min(pre + 1, Math.Min(dp[i] + 1, dp[i - 1] + 1));
                    }
                    pre = temp;
                }
            }
            return dp[m];
        }
    }
}
