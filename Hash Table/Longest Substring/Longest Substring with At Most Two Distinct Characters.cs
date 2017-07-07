/*
159 Longest Substring with At Most Two Distinct Characters
easy, hashtable
Given a string S, find the length of the longest substring T that contains at most two distinct characters.
For example,
Given S = “eceba”,
T is “ece” which its length is 3.
*/

using System;
using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public int LengthOfLongestSubstringTwoDistinct(string s)
        {
            int res = 0, left = 0;
            Dictionary<char, int> m = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; ++i)
            {
                ++m[s[i]];
                while (m.Count > 2)
                {
                    if (--m[s[left]] == 0)
                    {
                        m.Remove(s[left]);
                    }
                    ++left;
                }
                res = Math.Max(res, i - left + 1);
            }
            return res;
        }
    }
}
