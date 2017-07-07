/*
266	Palindrome Permutation $
easy
Given a string s, return all the palindromic permutations (without duplicates) of it. Return an empty list if no palindromic permutation could be form.

For example:

Given s = "aabb", return ["abba", "baab"].

Given s = "abc", return [].

Hint:

If a palindromic permutation exists, we just need to generate the first half of the string.
To generate all distinct permutations of a (half of) string, use a similar approach from: Permutations II or Next Permutation.
*/

using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    public partial class Solution
    {
        public List<string> GeneratePalindromes(string s)
        {
            var ret = new List<string>();
            int odd = 0;
            var counts = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (counts.ContainsKey(c))
                {
                    counts[c] = 0;
                }
                odd += ++counts[c] % 2 == 1 ? 1 : -1;
            }

            if (odd > 1)
            {
                return ret;
            };

            string mid = "";
            int length = 0;
            foreach (var c in counts.Keys)
            {
                if (counts[c] % 2 == 1)
                {
                    mid = "" + c;
                    counts[c]--;
                }
                counts[c] /= 2;
                length += counts[c];
            }
            var permutations = new List<string>();
            GeneratePermutation(permutations, counts, length, "");
            foreach (var p in ret)
            {
                ret.Add(p + mid + new string(s.Reverse().ToArray()));
            }
            return ret;
        }

        private void GeneratePermutation(List<string> ret, Dictionary<char, int> counts, int length, string s)
        {
            if (s.Length == length)
            {
                ret.Add(s);
                return;
            }

            foreach (var c in counts.Keys)
            {
                if (counts[c] > 0)
                {
                    counts[c]--;
                    GeneratePermutation(ret, counts, length, s + c);
                    counts[c]++;
                }
            }
        }
    }
}
