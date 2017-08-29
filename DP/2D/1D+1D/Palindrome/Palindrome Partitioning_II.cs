/*
132	Palindrome Partitioning II
hard, dp, *
Given a string s, partition s such that every substring of the partition is a palindrome.

Return the minimum cuts needed for a palindrome partitioning of s.

For example, given s = "aab",
Return 1 since the palindrome partitioning ["aa","b"] could be produced using 1 cut.
*/

namespace Demo
{
    public partial class Solution
    {
        public int MinCut_4(string s)
        {
            var dp = new int[s.Length, s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                int minCut = i;
                for (int j = i; j >= 0; j--)
                {
                    dp[j, i] = i - j;
                    if (s[i] == s[j] && (i - j <= 2 || dp[j + 1, i - 1] == 0))
                    {
                        dp[j, i] = 0;
                        var c = j == 0 ? 0 : dp[0, j - 1] + 1;
                        if (minCut > c)
                        {
                            minCut = c;
                        }
                    }
                }

                dp[0, i] = minCut;
            }

            return dp[0, s.Length - 1];
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

                // try cut at j
                for (int j = i; j <= n - 1; j++)
                {
                    if (s[i] == s[j]
                        && (j - i < 2 /*only 1 char*/
                            || dp[i + 1, j - 1]) /*only 2 more char*/)
                    {
                        dp[i, j] = true;

                        // keep s[i,j] in the min cut 
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
