/*
214	Shortest Palindrome
revisit
Given a string S, you are allowed to convert it to a palindrome by adding characters in front of it. Find and return the shortest palindrome you can find by performing this transformation.

For example:

Given "aacecaaa", return "aaacecaaa".

Given "abcd", return "dcbabcd".
*/

using System;

namespace Demo
{
    public partial class Solution
    {
        public void Test_ShortestPalindrome()
        {
            ShortestPalindrome("ba");
        }

        public string ShortestPalindrome(string s)
        {
            var ca = s.ToCharArray();
            Array.Reverse(ca);
            string r = new string(ca);
            string t = s + "#" + r + "?";
            int[] next = new int[t.Length];
            next[0] = -1;
            int i = 0;
            int j = -1;
            while (i < t.Length - 1)
            {
                // s[j] is prefix，s[i] is post fix
                // j == -1, s[0] != s[i], so next[i+1] = 0, i++
                // s[j] = s[i], next[i+1] = j+1; i++, j++
                if (j == -1 || t[j] == t[i])
                {
                    next[++i] = ++j;
                }
                else
                {
                    j = next[j];
                }
            }

            int maxCommon = next[t.Length - 1];
            return r.Substring(0, s.Length - maxCommon) + s;
        }

        public string ShortestPalindrome2(string s)
        {
            var ca = s.ToCharArray();
            Array.Reverse(ca);
            string t = new string(ca);

            // find the largest common prefix in s and postfix in t
            int n = s.Length;
            int i;
            for (i = n; i >= 0; --i)
            {
                if (s.Substring(0, i) == t.Substring(n - i))
                {
                    break;
                }
            }

            return t.Substring(0, n - i) + s;
        }
    }
}
