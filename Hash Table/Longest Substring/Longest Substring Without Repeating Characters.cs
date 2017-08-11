/*
3	Longest Substring Without Repeating Characters
Given a string, find the length of the longest substring without repeating characters. For example, the longest substring without repeating letters for "abcabcbb" is "abc", which the length is 3. For "bbbbb" the longest substring is "b", with the length of 1.
*/
using System;

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
            Console.WriteLine(LengthOfLongestSubstring(a));
            a = "abcde";
            Console.WriteLine(LengthOfLongestSubstring(a));
        }

        public int LengthOfLongestSubstring(string s)
        {
            int res = 0;
            int left = 0;
            var m = new int[26];
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
    }
}
