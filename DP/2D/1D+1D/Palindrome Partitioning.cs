/*
131	Palindrome Partitioning
midium, dp
Given a string s, partition s such that every substring of the partition is a palindrome.

Return all possible palindrome partitioning of s.

For example, given s = "aab",
Return

  [
    ["aa","b"],
    ["a","a","b"]
  ]
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public bool[,] BuildPalindromeDP2(string s)
        {
            int n = s.Length;
            bool[,] dp = new bool[n, n]; // i to j is Palindrome.

            for (int i = n - 1; i >= 0; i--)
            {
                for (int j = i; j <= n - 1; j++)
                {
                    if (s[i] == s[j]
                        && (j - i < 2 /*only 1 char*/
                            || dp[i + 1, j - 1]) /*only 2 more char*/)
                    {
                        dp[i, j] = true;
                    }
                }
            }
            return dp;
        }

        public void Test_Partition()
        {
            Partition("aab");
        }

        // Recursive
        public List<List<string>> Partition(string s)
        {
            bool[,] dp = BuildPalindromeDP(s);
            List<List<string>> ret = new List<List<string>>();
            List<string> current = new List<string>();
            FindPalindromePartitioning(s, 0, ret, current, dp);
            return ret;
        }

        private void FindPalindromePartitioning(string s, int start,
                List<List<string>> ret, List<string> current, bool[,] dp)
        {
            if (start >= s.Length)
            {
                ret.Add(new List<string>(current));
                return;
            }

            for (int i = start; i < s.Length; i++)
            {
                if (dp[start, i])
                {
                    current.Add(s.Substring(start, i - start + 1));
                    FindPalindromePartitioning(s, i + 1, ret, current, dp);
                    current.RemoveAt(current.Count - 1);
                }
            }
        }
    }
}
