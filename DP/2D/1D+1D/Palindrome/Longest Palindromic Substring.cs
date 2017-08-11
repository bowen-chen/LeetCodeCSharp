/*
5	Longest Palindromic Substring
Longest Palindromic Substring
Given a string S, find the longest palindromic substring in S. You may assume that the maximum length of S is 1000, and there exists one unique longest palindromic substring.
*/

using System;

namespace Demo
{
    public partial class Solution
    {
        public void LongestPalindrome_Test()
        {
            string a = "aaabbbaaac";
            Console.WriteLine(LongestPalindrome(a));
        }
        
        public string LongestPalindrome(string s)
        {
            int len = s.Length;
            bool[,] dp = new bool[len, len];
            int max = 0, start = 0, end = 0;
            for (int i = 0; i < s.Length; i++)
            {
                dp[i, i] = true;
                for (int j = 0; j < i; j++)
                {
                    dp[j, i] = (s[j] == s[i] && (i - j < 2 || dp[j + 1, i - 1]));
                    if (dp[j, i] && max < (i - j + 1))
                    {
                        max = i - j + 1;
                        start = j;
                        end = i;
                    }
                }
            }

            return s.Substring(start, end - start + 1);
        }


        // O(n)
        // http://en.wikipedia.org/wiki/Longest_palindromic_substring
        public string longestPalindrome2(string s)
        {
            string t = "$#";
            for (int i = 0; i < s.Length; ++i)
            {
                t += s[i];
                t += '#';
            }
            int[] p = new int[t.Length];
            int id = 0; /*The center of the rightest palindromic*/
            int mx = 0; /*The rightest palindromic can reach*/
            int resId = 0; /*return center*/
            int resMx = 0; /*return radius*/

            // calc the palindromic center at i
            for (int i = 0; i < t.Length; ++i)
            {
                // If i >= mx, we then match from i
                // If i < mx, we could reuse the result till mx
                // The mirrored point is 2 * id -i, the match length is Math.Min(p[2 * id - i], mx - i)
                //  -mx  -i  idx i mx
                //       ---    ---   p[2 * id - i]
                // OR
                //  -mx -i idx i mx
                //   ---------
                //     ===== =====   mx - i
                p[i] = mx > i ? Math.Min(p[2 * id - i], mx - i) : 1;
                while (t[i + p[i]] == t[i - p[i]])
                {
                    ++p[i];
                }

                // move mx
                if (mx < i + p[i])
                {
                    mx = i + p[i];
                    id = i;
                }

                if (resMx < p[i])
                {
                    resMx = p[i];
                    resId = i;
                }
            }

            return s.Substring((resId - resMx) / 2, resMx - 1);
        }
    };
}

