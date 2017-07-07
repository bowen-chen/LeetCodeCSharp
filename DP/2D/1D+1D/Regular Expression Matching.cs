/*
10	Regular Expression Matching
medium,dp
Implement regular expression matching with support for '.' and '*'.

'.' Matches any single character.
'*' Matches zero or more of the preceding element.

The matching should cover the entire input string (not partial).

The function prototype should be:
bool isMatch(const char *s, const char *p)

Some examples:
isMatch("aa","a") → false
isMatch("aa","aa") → true
isMatch("aaa","aa") → false
isMatch("aa", "a*") → true
isMatch("aa", ".*") → true
isMatch("ab", ".*") → true
isMatch("aab", "c*a*b") → true
*/
using System;

namespace Demo
{
    public partial class Solution
    {
        public void IsMatch_Test()
        {
            Console.WriteLine(IsMatch("aa","a"));
            Console.WriteLine(IsMatch("aa", "aa"));
            Console.WriteLine(IsMatch("aaa", "aa"));
            Console.WriteLine(IsMatch("aa", "a*"));
            Console.WriteLine(IsMatch("aa", ".*"));
            Console.WriteLine(IsMatch("ab", ".*"));
            Console.WriteLine(IsMatch("aab", "c*a*b"));
            Console.WriteLine(IsMatch("abc", "*c"));
        }

        public bool IsMatch(string s, string p)
        {
            int m = s.Length, n = p.Length;
            // we need match empty string to .*, so we need consider 0
            bool[,] dp = new bool[m + 1, n + 1];
            dp[0, 0] = true;
            for (int i = 0; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    // p[j - 1] current p
                    // s[i - 1] current s
                    if (j > 1 && p[j - 1] == '*') // current is *, * cannot be the first there much be another char p[j-2] in p before current one
                    {
                        dp[i, j] = dp[i, j - 2] /*Match zero*/||
                                   (i > 0 && (s[i - 1] == p[j - 2] || p[j - 2] == '.') && dp[i - 1, j] /*Match one more*/);
                    }
                    else
                    {
                        dp[i, j] = i > 0 && (s[i - 1] == p[j - 1] || p[j - 1] == '.') && dp[i - 1, j - 1];
                    }
                }
            }
            return dp[m, n];
        }
    }
}
