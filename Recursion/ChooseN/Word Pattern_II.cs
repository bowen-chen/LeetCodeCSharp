/*
291	Word Pattern II
Given a pattern and a string str, find if str follows the same pattern.

Here follow means a full match, such that there is a bijection between a letter in pattern and a non-empty substring in str.

Examples:

pattern = "abab", str = "redblueredblue" should return true.
pattern = "aaaa", str = "asdasdasdasd" should return true.
pattern = "aabb", str = "xyzabcxzyabc" should return false. 
Notes:
You may assume both pattern and str contains only lowercase letters.
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public bool WordPatternMatch(string pattern, string str)
        {
            var st = new HashSet<string>();
            var mp = new Dictionary<char, string>();
            return WordPatternMatch(str, 0, pattern, 0, st, mp);
        }

        public bool WordPatternMatch(string str, int i, string pat, int j, HashSet<string> visited, Dictionary<char, string> mp)
        {
            int m = str.Length, n = pat.Length;
            if (i == m && j == n)
            {
                return true;
            }

            if (i == m || j == n)
            {
                return false;
            }

            char c = pat[j];

            // existing pattern
            if (mp.ContainsKey(c))
            {
                string s = mp[c];
                int l = s.Length;
                if (s != str.Substring(i, l))
                {
                    return false;
                }
                return WordPatternMatch(str, i + l, pat, j + 1, visited, mp);
            }

            // new pattern
            for (int len = 1; len + i < m; len++)
            {
                string s = str.Substring(i, len);

                // s should be a new parttern
                if (visited.Contains(s))
                {
                    continue;
                }

                visited.Add(s);
                mp.Add(c, s);
                if (WordPatternMatch(str, len + i, pat, j + 1, visited, mp))
                {
                    return true;
                }
                visited.Remove(s);
                mp.Remove(c);
            }
            return false;
        }
    }
}
