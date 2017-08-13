/*
358	Rearrange String k Distance Apart

Given a non-empty string str and an integer k, rearrange the string such that the same characters are at least distance k from each other.

All input strings are given in lowercase letters. If it is not possible to rearrange the string, return an empty string "".

Example 1:
str = "aabbcc", k = 3

Result: "abcabc"

The same letters are at least distance 3 from each other.
Example 2:
str = "aaabc", k = 3 

Answer: ""

It is not possible to rearrange the string.
Example 3:
str = "aaadbbcc", k = 2

Answer: "abacabcd"

Another possible answer is: "abcabcda"

The same letters are at least distance 2 from each other.
*/
using System;
using System.Collections.Generic;
using Demo.Common;

namespace Demo
{
    public partial class Solution
    {
        public string RearrangeString(string str, int k)
        {
            if (k == 0)
            {
                return str;
            }

            var m = new Dictionary<char, int>();
            foreach (var a in str)
            {
                if (!m.ContainsKey(a))
                {
                    m[a] = 0;
                }

                m[a]++;
            }

            var q = new PriorityQueue<Tuple<int, char>>(m.Count,
                Comparer<Tuple<int, char>>.Create((i, j) => i.Item1.CompareTo(j.Item1)));
            foreach (var it in m)
            {
                q.Push(Tuple.Create(it.Value, it.Key));
            }

            string res = "";
            int len = str.Length;
            while (q.Count != 0)
            {
                var v = new List<Tuple<int, char>>();
                int cnt = Math.Min(k, len);
                for (int i = 0; i < cnt; ++i)
                {
                    if (q.Count == 0)
                    {
                        // not possible
                        return "";
                    }
                    var t = q.Pop();
                    res += t.Item2;
                    if (t.Item1 > 1)
                    {
                        v.Add(Tuple.Create(t.Item1 - 1, t.Item2));
                    }

                    --len;
                }

                foreach (var a in v)
                {
                    q.Push(a);
                }
            }

            return res;
        }
    }
}
