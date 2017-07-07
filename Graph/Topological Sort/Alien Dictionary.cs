/*
269	Alien Dictionary
easy
There is a new alien language which uses the latin alphabet. However, the order among letters are unknown to you. You receive a list of words from the dictionary, wherewords are sorted lexicographically by the rules of this new language. Derive the order of letters in this language.

For example,
Given the following words in dictionary,

[
  "wrt",
  "wrf",
  "er",
  "ett",
  "rftt"
]
The correct order is: "wertf".

Note:

You may assume all letters are in lowercase.
If the order is invalid, return an empty string.
There may be multiple valid order of letters, return any one of them is fine.
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    public partial class Solution
    {
        public void Test_AlienOrder()
        {
            Console.WriteLine(AlienOrder(new[] { "wrt", "wrf", "er", "ett", "rftt" }));
        }
        public string AlienOrder(string[] words)
        {
            var i = new Dictionary<char, int>();
            var o = new Dictionary<char, ISet<char>>();
            foreach (string w in words)
            {
                char? pre = null;
                foreach (char c in w)
                {
                    if (!i.ContainsKey(c))
                    {
                        i.Add(c, 0);
                    }

                    if (!o.ContainsKey(c))
                    {
                        o.Add(c, new HashSet<char>());
                    }

                    if (pre != null && pre != c)
                    {
                        if (!o[pre.Value].Contains(c))
                        {
                            o[pre.Value].Add(c);
                            i[c]++;
                        }
                    }

                    pre = c;
                }
            }

            var s = new Stack<char>();
            foreach (var p in i.Where(kv => kv.Value == 0))
            {
                s.Push(p.Key);
            }

            string ret = "";
            while (s.Count != 0) {
                var c = s.Pop();
                ret += c;
                foreach (var n in o[c]) {
                    if (--i[n] == 0)
                    {
                        s.Push(n);
                    }
                }
            }

            return ret;
        }
    }
}
