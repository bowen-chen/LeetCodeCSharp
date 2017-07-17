/*
438. Find All Anagrams in a String
easy
Given a string s and a non-empty string p, find all the start indices of p's anagrams in s.

Strings consists of lowercase English letters only and the length of both strings s and p will not be larger than 20,100.

The order of output does not matter.

Example 1:

Input:
s: "cbaebabacd" p: "abc"

Output:
[0, 6]

Explanation:
The substring with start index = 0 is "cba", which is an anagram of "abc".
The substring with start index = 6 is "bac", which is an anagram of "abc".
Example 2:

Input:
s: "abab" p: "ab"

Output:
[0, 1, 2]

Explanation:
The substring with start index = 0 is "ab", which is an anagram of "ab".
The substring with start index = 1 is "ba", which is an anagram of "ab".
The substring with start index = 2 is "ab", which is an anagram of "ab".
*/
using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public IList<int> FindAnagrams(string s, string p)
        {
            var res = new List<int>();
            if (string.IsNullOrEmpty(p) || string.IsNullOrEmpty(p))
            {
                return res;
            }

            int[] m = new int[26];
            foreach (char c in p)
            {
                m[c - 'a']++;
            }

            // count is sum of all the positive hash value
            int left = 0;
            int right = 0;
            int count = p.Length;
            while (right < s.Length)
            {
                if (m[s[right++] - 'a']-- >= 1)
                {
                    count--;
                }

                if (count == 0)
                {
                    res.Add(left);
                }

                if (right - left == p.Length)
                {
                    if (m[s[left++] - 'a']++ >= 0)
                    {
                        count++;
                    }
                }
            }

            return res;
        }
    }
}
