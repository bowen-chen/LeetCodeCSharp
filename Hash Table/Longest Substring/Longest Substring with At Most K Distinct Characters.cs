/*
340 Longest Substring with At Most K Distinct Characters
easy, hashtable
Given a string, find the length of the longest substring T that contains at most k distinct characters.

For example, Given s = “eceba” and k = 2,

T is "ece" which its length is 3.
*/

using System;

namespace Demo
{
    public partial class Solution
    {
        public int LengthOfLongestSubstringKDistinct(string s, int k)
        {
            int res = 0, left = 0;
            int count = 0;
            var m = new int[26];
            for (int i = 0; i < s.Length; ++i)
            {
                if (++m[s[i] - 'a'] == 1)
                {
                    count ++;
                }

                while (count > k)
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