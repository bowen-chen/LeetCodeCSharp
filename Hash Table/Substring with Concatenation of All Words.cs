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
        public List<int> FindSubstring2(string s, string[] words)
        {
            var res = new List<int>();
            if (string.IsNullOrEmpty(s) || words == null || words.Length == 0)
            {
                return res;
            }
            int n = s.Length;
            int cnt = words.Length;
            int len = words[0].Length;
            var m1 = new Dictionary<string, int>();
            foreach (string w in words)
            {
                if (!m1.ContainsKey(w))
                {
                    m1[w] = 0;
                }
                m1[w]++;
            }
            for (int i = 0; i < len; ++i)
            {
                int left = i;
                int count = 0;
                var m2 = new Dictionary<string, int>();
                for (int j = i; j <= n - len; j += len)
                {
                    string t = s.Substring(j, len);
                    if (m1.ContainsKey(t))
                    {
                        if (!m2.ContainsKey(t))
                        {
                            m2[t] = 0;
                        }

                        if (++m2[t] <= m1[t])
                        {
                            ++count;
                        }
                        else
                        {
                            while (m2[t] > m1[t])
                            {
                                var t1 = s.Substring(left, len);
                                if (--m2[t1] < m1[t1])
                                {
                                    --count;
                                }
                                left += len;
                            }
                        }

                        if (count == cnt)
                        {
                            res.Add(left);
                            --m2[s.Substring(left, len)];
                            --count;
                            left += len;
                        }
                    }
                    else
                    {

                        m2.Clear();
                        count = 0;
                        left = j + len;
                    }
                }
            }
            return res;
        }

        public IList<int> FindSubstring(string s, string[] words)
        {
            var expected = new Dictionary<string, int>();
            foreach (string word in words)
            {
                if(!expected.ContainsKey(word))
                {
                    expected[word] = 0;
                }
                expected[word]++;
            }

            int n = s.Length;
            int num = words.Length;
            int len = words[0].Length;

            var ret = new List<int>();
            for (int i = 0; i < n - num * len + 1; i++)
            {
                var seen = new Dictionary<string, int>();
                int j = 0;
                for (; j < num; j++)
                {
                    string word = s.Substring(i + j * len, len);
                    if (expected.ContainsKey(word))
                    {
                        if (!seen.ContainsKey(word))
                        {
                            seen[word] = 0;
                        }
                        seen[word]++;
                        if (seen[word] > expected[word])
                        {
                            // extra word
                            break;
                        }
                    }
                    else
                    {
                        // non match word
                        break;
                    }
                }
                if (j == num)
                {
                    ret.Add(i);
                }
            }
            return ret;
        }
    }
}
