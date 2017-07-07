/*
395. Longest Substring with At Least K Repeating Characters
Find the length of the longest substring T of a given string (consists of lowercase letters only) such that every character in T appears no less than k times.

Example 1:

Input:
s = "aaabb", k = 3

Output:
3

The longest substring is "aaa", as 'a' is repeated 3 times.
Example 2:

Input:
s = "ababbc", k = 2

Output:
5

The longest substring is "ababb", as 'a' is repeated 2 times and 'b' is repeated 3 times.
*/

using System;

namespace Demo
{
    public partial class Solution
    {
        public int LongestSubstring(string s, int k)
        {
            int res = 0, i = 0, n = s.Length;
            while (i + k <= n)
            {
                int[] m = new int[26];
                int mask = 0;
                int max_idx = i;
                for (int j = i; j < n; ++j)
                {
                    int t = s[j] - 'a';
                    ++m[t];
                    if (m[t] < k) mask |= (1 << t);
                    else mask &= (~(1 << t));
                    if (mask == 0)
                    {
                        res = Math.Max(res, j - i + 1);
                        max_idx = j;
                    }
                }
                i = max_idx + 1;
            }
            return res;
        }

        public int LongestSubstring2(string s, int k)
        {
            var m = new int[26];
            foreach (char c in s)
            {
                ++m[c - 'a'];
            }

            foreach (char c in s)
            {
                if (m[c - 'a'] < k)
                {
                    var res = 0;
                    foreach (var ss in s.Split(c))
                    {
                        res = Math.Max(res, LongestSubstring2(ss, k));
                    }
                    return res;
                }
            }
            return s.Length;
        }
    }
}
