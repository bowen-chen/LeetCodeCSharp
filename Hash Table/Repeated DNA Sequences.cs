/*
187	Repeated DNA Sequences
easy, hashtable
All DNA is composed of a series of nucleotides abbreviated as A, C, G, and T, for example: "ACGAATTCCG". When studying DNA, it is sometimes useful to identify repeated sequences within the DNA.

Write a function to find all the 10-letter-long sequences (substrings) that occur more than once in a DNA molecule.

For example,

Given s = "AAAAACCCCCAAAAACCCCCCAAAAAGGGTTT",

Return:
["AAAAACCCCC", "CCCCCAAAAA"].
*/

using System.Collections.Generic;
using System.Linq;

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
            var m = new Dictionary < char, int>{ { 'A', 0}, { 'C', 1}, { 'G', 2}, { 'T', 3} };

            // 32 bit can save 16 char, we only use 20bit, 0xfffff
            int cur = 0;
            int i = 0;
            while (i < 9) cur = cur << 2 | m[s[i++]];
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

        public IList<string> FindRepeatedDnaSequences2(string s)
        {
            if (s.Length <= 10)
            {
                return new List<string>();
            }
            Dictionary<string, int> h = new Dictionary<string, int>();
            for (int i = 9; i < s.Length; i++)
            {
                string tmp = s.Substring(i - 9, 10);
                if (!h.ContainsKey(tmp))
                {
                    h.Add(tmp, 0);
                }
                h[tmp]++;
            }
            return h.Where(kp => kp.Value > 1).Select(kp => kp.Key).ToList();
        }
    }
}
