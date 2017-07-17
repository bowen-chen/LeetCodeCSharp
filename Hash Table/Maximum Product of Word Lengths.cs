/*
318	Maximum Product of Word Lengths
medium
Given a string array words, find the maximum value of length(word[i]) * length(word[j]) where the two words do not share common letters. You may assume that each word will contain only lower case letters. If no such two words exist, return 0.

Example 1:
Given ["abcw", "baz", "foo", "bar", "xtfn", "abcdef"]
Return 16
The two words can be "abcw", "xtfn".

Example 2:
Given ["a", "ab", "abc", "d", "cd", "bcd", "abcd"]
Return 4
The two words can be "ab", "cd".

Example 3:
Given ["a", "aa", "aaa", "aaaa"]
Return 0
No such pair of words.
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    public partial class Solution
    {
        public int MaxProduct(string[] words)
        {
            int res = 0;
            var mask = new Dictionary<int, int>();
            for (int i = 0; i < words.Length; ++i)
            {
                mask[i] = 0;
                foreach (char c in words[i])
                {
                    mask[i] |= 1 << (c - 'a');
                }

                for (int j = 0; j < i; ++j)
                {
                    if ((mask[i] & mask[j]) == 0)
                    {
                        res = Math.Max(res, words[i].Length * words[j].Length);
                    }
                }
            }

            return res;
        }

        public int MaxProduct2(string[] words)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            foreach (var word in words)
            {
                int i = 0;
                foreach (var c in word)
                {
                    i |= 1 << (c - 'a');
                }

                if (!dic.ContainsKey(i) || dic[i] < word.Length)
                {
                    dic[i] = word.Length;
                }
            }

            var p = dic.OrderByDescending(kvp => kvp.Value).ToArray();
            int ret = 0;
            for (int i = 0; i < p.Length; i++)
            {
                if (p[i].Value * p[i].Value <= ret)
                {
                    break;
                }

                for (int j = i + 1; j < p.Length; j++)
                {
                    if ((p[i].Key & p[j].Key) == 0)
                    {
                        ret = Math.Max(p[i].Value * p[j].Value, ret);
                        break;
                    }
                }
            }

            return ret;
        }
    }
}
