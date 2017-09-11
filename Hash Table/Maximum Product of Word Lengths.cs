/*
318	Maximum Product of Word Lengths
medium, *
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

namespace Demo
{
    public partial class Solution
    {
        public int MaxProduct(string[] words)
        {
            var ret = 0;
            var m = new Dictionary<int, int>();
            foreach (var w in words)
            {
                var mask = 0;
                foreach (var c in w)
                {
                    mask |= 1 << (c - 'a');
                }

                if (!m.ContainsKey(mask) || m[mask] < w.Length)
                {
                    m[mask] = w.Length;
                    foreach (var kvp in m)
                    {
                        if ((kvp.Key & mask) == 0)
                        {
                            ret = Math.Max(ret, kvp.Value * w.Length);
                        }
                    }
                }
            }

            return ret;
        }
    }
}
