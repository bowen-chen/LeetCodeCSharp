/*
30	Substring with Concatenation of All Words	
easy, hashtable
You are given a string, s, and a list of words, words, that are all of the same length. Find all starting indices of substring(s) in s that is a concatenation of each word in words exactly once and without any intervening characters.

For example, given:
s: "barfoothefoobarman"
words: ["foo", "bar"]

You should return the indices: [0,9].
(order does not matter).
*/
using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public List<int> FindSubstring(string s, string[] words)
        {
            var res = new List<int>();
            if (string.IsNullOrEmpty(s) || words == null || words.Length == 0)
            {
                return res;
            }

            var m1 = new Dictionary<string, int>();
            foreach (string w in words)
            {
                if (!m1.ContainsKey(w))
                {
                    m1[w] = 0;
                }

                m1[w]++;
            }

            int n = s.Length;
            int len = words[0].Length;
            for (int i = 0; i < len; ++i)
            {
                int count = words.Length;
                var m2 = new Dictionary<string, int>(m1); /* make a copy */
                for (int j = i; j <= n - len; j += len)
                {
                    string t = s.Substring(j, len);
                    if (m2.ContainsKey(t))
                    {
                        if (m2[t]-- >= 1)
                        {
                            count--;
                        }
                    }

                    int left = j - (words.Length - 1)*len;
                    if (count == 0)
                    {
                        res.Add(left);
                    }

                    if (left >= 0)
                    {
                        string o = s.Substring(left, len);
                        if (m2.ContainsKey(o))
                        {
                            if (m2[o]++ >= 0)
                            {
                                count++;
                            }
                        }
                    }
                }
            }

            return res;
        }
    }
}
