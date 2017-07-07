/*
97	Interleaving String
dp, medium
Given s1, s2, s3, find whether s3 is formed by the interleaving of s1 and s2.

For example,
Given:
s1 = "aabcc",
s2 = "dbbca",

When s3 = "aadbbcbcac", return true.
When s3 = "aadbbbaccc", return false.
*/

namespace Demo
{
    public partial class Solution
    {
        public bool IsInterleave(string s1, string s2, string s3)
        {
            if (s3.Length != s1.Length + s2.Length)
            {
                return false;
            }

            // If s3[i+j] is interleave of s1[i], s2[j]
            // Init value dp[0, 0] = true;
            bool[,] dp = new bool[s1.Length + 1, s2.Length + 1];

            for (int i = 0; i <= s1.Length; i++)
            {
                for (int j = 0; j <= s2.Length; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        dp[i, j] = true;
                    }
                    else if (i == 0)
                    {
                        dp[i, j] = (dp[i, j - 1] && s2[j - 1] == s3[i + j - 1]);
                    }
                    else if (j == 0)
                    {
                        dp[i, j] = (dp[i - 1, j] && s1[i - 1] == s3[i + j - 1]);
                    }
                    else
                    {
                        dp[i, j] = (dp[i - 1, j] && s1[i - 1] == s3[i + j - 1]) ||
                                   (dp[i, j - 1] && s2[j - 1] == s3[i + j - 1]);
                    }
                }
            }

            return dp[s1.Length, s2.Length];
        }

        public bool IsInterleave2(string s1, string s2, string s3)
        {
            if (s3.Length != s1.Length + s2.Length)
            {
                return false;
            }

            // If s3[X+j] is interleave of s1[X], s2[j]
            bool[] dp = new bool[s2.Length + 1];

            for (int i = 0; i < s1.Length + 1; i++)
            {
                bool[] dp2 = new bool[s2.Length + 1];
                for (int j = 0; j < s2.Length + 1; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        dp2[j] = true;
                    }
                    else if (i == 0)
                    {
                        dp2[j] = (dp2[j - 1] && s2[j - 1] == s3[i + j - 1]);
                    }
                    else if (j == 0)
                    {
                        dp2[j] = (dp[j] && s1[i - 1] == s3[i + j - 1]);
                    }
                    else
                    {
                        dp2[j] = (dp[j] && s1[i - 1] == s3[i + j - 1]) ||
                                   (dp2[j - 1] && s2[j - 1] == s3[i + j - 1]);
                    }
                }
                dp = dp2;
            }

            return dp[s2.Length];
        }
    }
}
