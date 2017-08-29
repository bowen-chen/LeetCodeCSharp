/*
187	Repeated DNA Sequences
easy, hashtable, *
All DNA is composed of a series of nucleotides abbreviated as A, C, G, and T, for example: "ACGAATTCCG". When studying DNA, it is sometimes useful to identify repeated sequences within the DNA.

Write a function to find all the 10-letter-long sequences (substrings) that occur more than once in a DNA molecule.

For example,

Given s = "AAAAACCCCCAAAAACCCCCCAAAAAGGGTTT",

Return:
["AAAAACCCCC", "CCCCCAAAAA"].
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public IList<string> FindRepeatedDnaSequences(string s)
        {
            var res = new List<string>();
            if (s.Length <= 10)
            {
                return res;
            }

            var seen = new Dictionary<int, int>();
            var m = new Dictionary <char, int>{ { 'A', 0}, { 'C', 1}, { 'G', 2}, { 'T', 3} };

            // ACGT can be presented in 2 bit
            // 32 bit can save 16 char, we only use 20bit, 0xfffff
            int cur = 0;
            int i = 0;
            while (i < 9)
            {
                cur = cur << 2 | m[s[i++]];
            }

            while (i < s.Length)
            {
                cur = ((cur << 2) | m[s[i++]]) & 0xfffff;
                if (!seen.ContainsKey(cur))
                {
                    seen[cur] = 0;
                }

                if (seen[cur]++ == 1)
                {
                    res.Add(s.Substring(i - 10, 10));
                }
            }
            return res;
        }
    }
}
