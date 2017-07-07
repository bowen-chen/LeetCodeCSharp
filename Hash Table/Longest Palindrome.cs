/*
409. Longest Palindrome
Given a string which consists of lowercase or uppercase letters, find the length of the longest palindromes that can be built with those letters.

This is case sensitive, for example "Aa" is not considered a palindrome here.

Note:
Assume the length of given string will not exceed 1,010.

Example:

Input:
"abccccdd"

Output:
7

Explanation:
One longest palindrome that can be built is "dccaccd", whose length is 7.
*/

using System;
using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public int LongestPalindrome3(string s)
        {
            var t = new HashSet<char>();
            foreach (char c in s)
            {
                if (!t.Contains(c))
                {
                    t.Add(c);
                }
                else
                {
                    t.Remove(c);
                }
            }

            return s.Length - Math.Max(0, t.Count - 1);
        }
    }
}
