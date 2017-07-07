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

        // O(n)
        // http://en.wikipedia.org/wiki/Longest_palindromic_substring

        public string LongestPalindrome2(string s)
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
    }
}
