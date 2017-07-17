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
            int count = 0;
            var m = new int[26];
            for (int i = 0; i < s.Length; ++i)
            {
                if (++m[s[i] - 'a'] == 1)
                {
                    count++;
                }

                // at most 2
                while (count > 2)
                {
                    if (--m[s[left++] - 'a'] == 0)
                    {
                        count--;
                    }
                }

                res = Math.Max(res, i - left + 1);
            }

            return res;
        }
    }
}
