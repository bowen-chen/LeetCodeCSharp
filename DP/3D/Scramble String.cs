/*
87	Scramble String
hard, dp
Given a string s1, we may represent it as a binary tree by partitioning it to two non-empty substrings recursively.

Below is one possible representation of s1 = "great":

    great
   /    \
  gr    eat
 / \    /  \
g   r  e   at
           / \
          a   t
To scramble the string, we may choose any non-leaf node and swap its two children.

For example, if we choose the node "gr" and swap its two children, it produces a scrambled string "rgeat".

    rgeat
   /    \
  rg    eat
 / \    /  \
r   g  e   at
           / \
          a   t
We say that "rgeat" is a scrambled string of "great".

Similarly, if we continue to swap the children of nodes "eat" and "at", it produces a scrambled string "rgtae".

    rgtae
   /    \
  rg    tae
 / \    /  \
r   g  ta  e
       / \
      t   a
We say that "rgtae" is a scrambled string of "great".

Given two strings s1 and s2 of the same length, determine if s2 is a scrambled string of s1.
*/

namespace Demo
{
    public partial class Solution
    {
        public bool IsScramble(string s1, string s2)
        {
            if (s1 == s2)
            {
                return true;
            }

            for (int i = 1; i < s1.Length; i++)
            {
                if (IsScramble(s1.Substring(0, i), s2.Substring(0, i))
                    && IsScramble(s1.Substring(i), s2.Substring(i)))
                {
                    return true;
                }

                if (IsScramble(s1.Substring(0, i), s2.Substring(s2.Length - i))
                    && IsScramble(s1.Substring(i), s2.Substring(0, s2.Length - i)))
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsScramble2(string s1, string s2)
        {
            if (s1.Length != s2.Length)
            {
                return false;
            }

            int size = s1.Length;
            if (0 == size) return true;
            if (1 == size) return s1 == s2;

            // dp[len,i,j]
            // if s1.SubString(i, len) and s2.SubString(j, len) is scramble
            bool[,,] dp = new bool[size + 1, size, size];

            // init dp, dp[1, i, j] = s1[i] == s2[j]
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    dp[1, i, j] = s1[i] == s2[j];
                }
            }

            for (int len = 2; len <= size; len++)
            {
                for (int i = 0; i <= size - len; i++)
                {
                    for (int j = 0; j <= size - len; j++)
                    {
                        dp[len, i, j] = false;
                        for (int k = 1; k < len && !dp[len, i, j] /*break loop if we found one*/; ++k)
                        {
                            // break at k at s1
                            dp[len, i, j] = dp[len, i, j] || (dp[k, i, j] && dp[len - k, i + k, j + k]);
                            dp[len, i, j] = dp[len, i, j] || (dp[k, i + len - k, j] && dp[len - k, i, j + k]);
                        }
                    }
                }
            }

            return dp[size, 0, 0];
        }
    }
}
