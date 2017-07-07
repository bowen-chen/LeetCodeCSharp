/*
132	Palindrome Partitioning II
hard, dp
Given a string s, partition s such that every substring of the partition is a palindrome.

Return the minimum cuts needed for a palindrome partitioning of s.

For example, given s = "aab",
Return 1 since the palindrome partitioning ["aa","b"] could be produced using 1 cut.
*/
using System;

namespace Demo
{
    public partial class Solution
    {
        public int MinCut(string s)
        {
            bool[,] dp = BuildPalindromeDP(s);
            return findPalindromePartitioning2(s, 0, int.MaxValue, 0, dp);
        }

        private int findPalindromePartitioning2(string s, int start, int min, int current, bool[,] dp)
        {
            if (start >= s.Length)
            {
                return current;
            }

            current++;
            if (current >= min)
            {
                return min;
            }

            for (int i = s.Length - 1; i >= start; i--)
            {
                if (dp[start, i])
                {
                    min = findPalindromePartitioning2(s, i + 1, min, current, dp);

                }
            }
            return min;
        }

        public int MinCut_2(string s)
        {
            bool[,] dp = BuildPalindromeDP(s);
            int[] dp2 = new int[s.Length];
            dp2[s.Length - 1] = 1; // min cut from i to end.
            for (int i = s.Length - 2; i >= 0; i--)
            {
                dp2[i] = int.MaxValue;
                for (int j = i; j < s.Length; j++)
                {
                    if (dp[i, j])
                    {
                        if (j == s.Length - 1)
                        {
                            dp2[i] = 0;
                        }
                        else if ((dp2[j + 1] + 1 < dp2[i]))
                        {
                            dp2[i] = Math.Min(dp2[j + 1] + 1, dp2[i]) ;
                        }
                    }
                }
            }
            return dp2[0];
        }

        // prefer
        public int MinCut_3(string s)
        {
            int n = s.Length;
            bool[,] dp = new bool[n, n]; // i to j is Palindrome.
            int[] d = new int[n]; // min cut s[i -> end]. 

            //d[i] = if(dp[i,j] == true) min(d[j+1] + 1) where j = i to n-1
            for (int i = n - 1; i >= 0; i--)
            {
                // we cut between every char
                d[i] = n - 1 - i;
                for (int j = i; j <= n - 1; j++)
                {
                    if (s[i] == s[j]
                        && (j - i < 2 /*only 1 char*/
                            || dp[i + 1, j - 1]) /*only 2 more char*/)
                    {
                        dp[i, j] = true;
                        if (j == n - 1)
                        {
                            d[i] = 0;
                        }
                        else if (d[j + 1] + 1 < d[i])
                        {
                            d[i] = d[j + 1] + 1;
                        }
                    }
                }
            }
            return d[0];
        }
    }
}
