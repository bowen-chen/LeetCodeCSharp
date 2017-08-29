/*
91	Decode Ways
easy, dp, *
A message containing letters from A-Z is being encoded to numbers using the following mapping:

'A' -> 1
'B' -> 2
...
'Z' -> 26
Given an encoded message containing digits, determine the total number of ways to decode it.

For example,
Given encoded message "12", it could be decoded as "AB" (1 2) or "L" (12).

The number of ways decoding "12" is 2.
*/

namespace Demo
{
    public partial class Solution
    {
        public int NumDecodings(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }

            var dp = new int[s.Length+1];
            dp[0] = 1;
            dp[1] = s[0] == '0' ? 0 : 1;
            for (int i = 1; i < s.Length; i++)
            {
                // decode s[i] as the single digital
                if (s[i] != '0')
                {
                    dp[i + 1] += dp[i];
                }

                // decode this digital with previous one
                if (s[i-1]!='0' && int.Parse(s.Substring(i - 1, 2)) <= 26)
                {
                    dp[i + 1] += dp[i-1];
                }
            }

            return dp[s.Length];
        }

        public int NumDecodings2(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }

            int p2 = 1;
            int p1 = s[0] == '0' ? 0 : 1;
            if (s.Length == 1)
            {
                return p1;
            }

            int p = 0;
            for (int i = 1; i < s.Length; i++)
            {
                p = 0;
                if (s[i] != '0')
                {
                    p += p1;
                }

                if (s[i - 1] != '0' && int.Parse(s.Substring(i - 1, 2)) <= 26)
                {
                    p += p2;
                }

                p2 = p1;
                p1 = p;
            }

            return p;
        }
    }
}
