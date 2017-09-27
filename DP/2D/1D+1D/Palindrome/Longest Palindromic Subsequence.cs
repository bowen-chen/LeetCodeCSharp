/*
516. Longest Palindromic Subsequence
*
Given a string s, find the longest palindromic subsequence's length in s. You may assume that the maximum length of s is 1000.

Example 1:
Input:

"bbbab"
Output:
4
One possible longest palindromic subsequence is "bbbb".
Example 2:
Input:

"cbbd"
Output:
2
One possible longest palindromic subsequence is "bb".
*/

using System;

namespace Demo
{
    public partial class Solution
    {
        public int LongestPalindromeSubseq(string s)
        {
            int n = s.Length;

            // dp[i,j], the max length of palindrome subseq from s[i->j] 
            var dp = new int[n,n];
            for (int i = n - 1; i >= 0; --i)
            {
                dp[i, i] = 1;
                for (int j = i + 1; j < n; ++j)
                {
                    if (s[i] == s[j])
                    {
                        dp[i,j] = dp[i + 1,j - 1] + 2;
                    }
                    else
                    {
                        dp[i,j] = Math.Max(dp[i + 1, j], dp[i, j - 1]);
                    }
                }
            }

            return dp[0,n - 1];
        }

        public int LongestPalindromeSubseq2(string s)
        {
            int n = s.Length;
            var dp = new int[n];
            for (int i = n - 1; i >= 0; --i)
            {
                var dp2 = new int[n];
                dp2[i] = 1;
                for (int j = i + 1; j < n; ++j)
                {
                    if (s[i] == s[j])
                    {
                        dp2[j] = dp[j - 1] + 2;
                    }
                    else
                    {
                        dp2[j] = Math.Max(dp[j], dp2[j - 1]);
                    }
                }

                dp = dp2;
            }

            return dp[n - 1];
        }
    }
}
