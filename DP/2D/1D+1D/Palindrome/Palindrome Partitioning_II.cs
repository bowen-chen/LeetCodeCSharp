/*
132	Palindrome Partitioning II
hard, dp
Given a string s, partition s such that every substring of the partition is a palindrome.

Return the minimum cuts needed for a palindrome partitioning of s.

For example, given s = "aab",
Return 1 since the palindrome partitioning ["aa","b"] could be produced using 1 cut.
*/

namespace Demo
{
    public partial class Solution
    {
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
