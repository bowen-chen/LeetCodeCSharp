/*
115	Distinct Subsequences
medium, dp
Given a string S and a string T, count the number of distinct subsequences of T in S.

A subsequence of a string is a new string which is formed from the original string by deleting some (can be none) of the characters without disturbing the relative positions of the remaining characters. (ie, "ACE" is a subsequence of "ABCDE" while "AEC" is not).

Here is an example:
S = "rabbbit", T = "rabbit"

Return 3.
*/

namespace Demo
{
    public partial class Solution
    {
        /**
         * Solution (DP):
         * We keep a m*n matrix and scanning through string S, while
         * m = T.length() + 1 and n = S.length() + 1
         * and each cell in matrix Path[i][j] means the number of distinct subsequences of 
         * T.substr(1...i) in S(1...j)
         * 
         * Path[i][j] = Path[i][j-1]            (discard S[j])
         *              +     Path[i-1][j-1]    (S[j] == T[i] and we are going to use S[j])
         *                 or 0                 (S[j] != T[i] so we could not use S[j])
         * while Path[0][j] = 1 and Path[i][0] = 0.
         */
        public int NumDistinct(string s, string t)
        {
            int m = t.Length;
            int n = s.Length;
            if (m>n)
            {
                return 0; // impossible for subsequence
            }

            int[,] dp = new int[m + 1, n + 1];
            for (int k = 0; k <= n; k++)
            {
                dp[0, k] = 1; // initialization
            }

            //dp[1~m, 0] = 0;

            for (int j = 1; j <= n; j++)
            {
                for (int i = 1; i <= m; i++)
                {
                    dp[i, j] = dp[i, j - 1] // Do not use S[j]
                        + (t[i - 1] == s[j - 1] ? dp[i - 1, j - 1] : 0); // Use S[]
                }
            }

            return dp[m,n];
        }

        public int NumDistinct2(string s, string t)
        {
            int m = t.Length;
            int n = s.Length;
            if (m > n)
            {
                return 0; // impossible for subsequence
            }

            int[] dp = new int[m + 1];
            dp[0] = 1;            // initial condition

            for (int j = 1; j <= n; j++)
            {
                // traversing backwards so we are using path[i-1] from last time step
                for (int i = m; i >= 1; i--)
                {
                    dp[i] = dp[i] + (t[i - 1] == s[j - 1] ? dp[i - 1] : 0);
                }
            }

            return dp[m];
        }
    }
}
