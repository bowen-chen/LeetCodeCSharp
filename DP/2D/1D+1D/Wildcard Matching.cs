/*
44	Wildcard Matching
dp
Implement wildcard pattern matching with support for '?' and '*'.

'?' Matches any single character.
'*' Matches any sequence of characters (including the empty sequence).

The matching should cover the entire input string (not partial).

The function prototype should be:
bool isMatch(const char *s, const char *p)

Some examples:
isMatch("aa","a") → false
isMatch("aa","aa") → true
isMatch("aaa","aa") → false
isMatch("aa", "*") → true
isMatch("aa", "a*") → true
isMatch("ab", "?*") → true
isMatch("aab", "c*a*b") → false
*/

namespace Demo
{
    public partial class Solution
    {
        public bool IsMatch4(string s, string p)
        {
            int m = s.Length, n = p.Length;
            bool[,] dp = new bool[m + 1, n + 1];
            dp[0, 0] = true;
            for (int i = 0; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (p[j - 1] == '*') // current is *
                    {
                        dp[i, j] = dp[i, j - 1] /*Match zero*/|| (i > 0 && dp[i - 1, j] /*Match one more*/);
                    }
                    else
                    {
                        dp[i, j] = i > 0 && dp[i - 1, j - 1] && (s[i - 1] == p[j - 1] || p[j - 1] == '?');
                    }
                }
            }

            return dp[m, n];
        }
    }
}
