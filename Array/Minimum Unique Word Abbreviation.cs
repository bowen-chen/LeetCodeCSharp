/*
411	Minimum Unique Word Abbreviation
A string such as "word" contains the following abbreviations:

["word", "1ord", "w1rd", "wo1d", "wor1", "2rd", "w2d", "wo2", "1o1d", "1or1", "w1r1", "1o2", "2r1", "3d", "w3", "4"]
Given a target string and a set of strings in a dictionary, find an abbreviation of this target string with thesmallest possible length such that it does not conflict with abbreviations of the strings in the dictionary.

Each number or letter in the abbreviation is considered length = 1. For example, the abbreviation "a32bc" has length = 4.

Note:

In the case of multiple answers as shown in the second example below, you may return any one of them.
Assume length of target string = m, and dictionary size = n. You may assume that m ≤ 21, n ≤ 1000, and log2(n) + m ≤ 20.
 

Examples:

"apple", ["blade"] -> "a4" (because "5" or "4e" conflicts with "blade")

"apple", ["plain", "amber", "blade"] -> "1p3" (other valid answers include "ap3", "a3e", "2p2", "3le", "3l1").
*/

using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    public partial class Solution
    {
        public string MinAbbreviation(string target, List<string> dic)
        {
            // Preprocessing with bit manipulation
            int n = target.Length;
            int maxMark = 0;
            var bitDic = new HashSet<int>();
            foreach (var w in dic)
            {
                int word = 0;
                if (w.Length != n)
                {
                    continue;
                }

                for (int i = n - 1, bit = 1; i >= 0; --i, bit <<= 1)
                {
                    if (target[i] != w[i])
                    {
                        word |= bit;
                    }
                }

                bitDic.Add(word);
                maxMark |= word; /* cmark is the longest mark, each 1 is at least differentiate two word */
            }


            int minLine = int.MaxValue;
            int minMark = 0;
            DFS(bitDic, n, maxMark, 1, 0, ref minLine, ref minMark);

            // Reconstruct abbreviation from bit sequence
            string res = "";
            for (int i = n - 1, count = 0; i >= 0; --i, minMark >>= 1)
            {
                if ((minMark & 1) != 0)
                {
                    if (count > 0)
                    {
                        res = count + res;
                    }

                    count = 0;
                    res = target[i] + res;
                }
                else
                {
                    count++;
                    if (i == 0)
                    {
                        res = count + res;
                    }
                }
            }

            return res;
        }

        // DFS backtracking
        private void DFS(ISet<int> dict, int n, int maxMark, int bit, int cmask,  ref int minLen, ref int minMark)
        {
            int len = AbbrLen(cmask, n);
            if (len >= minLen)
            {
                return;
            }

            if (dict.All(w => (cmask & w) != 0))
            {
                minLen = len;
                minMark = cmask;
            }
            else
            {
                
                int bn = 1 << n; // 1<<2 100
                for (int b = bit; b < bn; b <<= 1)
                {
                    if ((maxMark & b) != 0)
                    {
                        DFS(dict, n, maxMark, b << 1, cmask | b, ref minLen, ref minMark);
                    }
                }
            }
        }

        // Return the length of abbreviation given bit sequence
        private int AbbrLen(int mask, int n)
        {
            int count = n;
            int bn = 1 << n; // 1<<2 100
            for (int b = 3; b < bn; b <<= 1)
            {
                if ((mask & b) == 0)
                {
                    count--;
                }
            }

            return count;
        }
    }
}
