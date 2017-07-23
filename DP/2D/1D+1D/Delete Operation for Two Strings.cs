﻿/*
583. Delete Operation for Two Strings
Given two words word1 and word2, find the minimum number of steps required to make word1 and word2 the same, where in each step you can delete one character in either string.

Example 1:
Input: "sea", "eat"
Output: 2
Explanation: You need one step to make "sea" to "ea" and another step to make "eat" to "ea".
Note:
The length of given words won't exceed 500.
Characters in given words can only be lower-case letters.
*/

using System;

namespace Demo
{
    public partial class Solution
    {
        public int MinDistance10(string word1, string word2)
        {
            return word1.Length + word2.Length - 2*LongestCommonSubsequence2(word1, word2);
        }

        private int LongestCommonSubsequence(string word1, string word2)
        {
            int len1 = word1.Length;
            int len2 = word2.Length;

            // dp[i,j], the max subsequence of take i from word1 and take j from word2
            // init value dp[0,j]=0, dp[i,0]=0
            var dp = new int[len1+1, len2+1];
            for (int i = 1; i <= len1; i++)
            {
                for (int j = 1; j <= len2; j++)
                {
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    if (word1[i-1] == word2[j-1])
                    {
                        dp[i, j] = Math.Max(dp[i, j], dp[i - 1, j - 1] + 1);
                    }
                }
            }

            return dp[len1, len2];
        }

        private int LongestCommonSubsequence2(string word1, string word2)
        {
            int len1 = word1.Length;
            int len2 = word2.Length;
            var dp = new int[len2 + 1];
            for (int i = 1; i <= len1; i++)
            {
                var dp2 = new int[len2 + 1];
                for (int j = 1; j <= len2; j++)
                {
                    dp2[j] = Math.Max(dp[j], dp2[j - 1]);
                    if (word1[i-1] == word2[j-1])
                    {
                        dp2[j] = Math.Max(dp2[j], dp[j - 1] + 1);
                    }
                }

                dp = dp2;
            }

            return dp[len2];
        }
    }
}
