/*
290	Word Pattern
easy, hashtable, *
Word Pattern

Given a pattern and a string str, find if str follows the same pattern.

Here follow means a full match, such that there is a bijection between a letter in pattern and a non-empty word in str.

Examples:
pattern = "abba", str = "dog cat cat dog" should return true.
pattern = "abba", str = "dog cat cat fish" should return false.
pattern = "aaaa", str = "dog cat cat dog" should return false.
pattern = "abba", str = "dog dog dog dog" should return false.
Notes:
You may assume pattern contains only lowercase letters, and str contains lowercase letters separated by a single space.
*/

using System;
using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public bool WordPattern2(string pattern, string str)
        {
            var words = str.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            if (words.Length != pattern.Length)
            {
                return false;
            }

            var m1 = new Dictionary<char, int>();
            var m2 = new Dictionary<string, int>();
            for (int i = 0; i < words.Length; i++)
            {
                if (!m1.ContainsKey(pattern[i]))
                {
                    m1[pattern[i]] = i;
                }

                if (!m2.ContainsKey(words[i]))
                {
                    m2[words[i]] = i;
                }

                if (m1[pattern[i]] != m2[words[i]])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
