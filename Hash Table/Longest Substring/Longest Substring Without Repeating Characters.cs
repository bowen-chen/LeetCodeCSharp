/*
3	Longest Substring Without Repeating Characters
Given a string, find the length of the longest substring without repeating characters. For example, the longest substring without repeating letters for "abcabcbb" is "abc", which the length is 3. For "bbbbb" the longest substring is "b", with the length of 1.
*/
using System;
using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public void LengthOfLongestSubstring_Test()
        {
            string a = "aaaaa";
            Console.WriteLine(LengthOfLongestSubstring(a));
            a = "abcde";
            Console.WriteLine(LengthOfLongestSubstring(a));

            a = "aaaaa";
            Console.WriteLine(LengthOfLongestSubstring2(a));
            a = "abcde";
            Console.WriteLine(LengthOfLongestSubstring2(a));
        }

        public int LengthOfLongestSubstring(string s)
        {
            int res = 0, left = 0;
            var m = new int[128];
            for (int i = 0; i < s.Length; ++i)
            {
                m[s[i]]++;
                while (m[s[i]] >1)
                {
                    m[s[left++]]--;
                }
                res = Math.Max(res, i - left + 1);
            }
            return res;
        }

        public int LengthOfLongestSubstring3(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }

            int last = 1; // The last non repeat string length, initial value 1, the first char itself.
            int ret = 1;
            for (int i = 1; i < s.Length; i++)
            {
                int currentlast = last + 1;

                // search if current charactor can be added to current non-repeat string 
                for (int j = 0; j < last; j++)
                {
                    if (s[i - j - 1] == s[i])
                    {
                        currentlast = j + 1;
                        break;
                    }
                }
                ret = Math.Max(ret, currentlast);
                last = currentlast;
            }
            return ret;
        }

        public int LengthOfLongestSubstring2(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }

            Dictionary<char, int> h = new Dictionary<char, int>();
            h.Add(s[0], 0);
            int last = 1;
            int ret = 1;
            for (int i = 1; i < s.Length; i++)
            {
                char c = s[i];
                if (!h.ContainsKey(c) || h[c] < i - last)
                {
                    last++;
                }
                else
                {
                    last = i - h[c];
                }
                h[c] = i;
                ret = Math.Max(ret, last);
            }
            return ret;
        }
    }
}
