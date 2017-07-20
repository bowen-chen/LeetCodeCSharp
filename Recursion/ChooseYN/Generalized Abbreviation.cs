/*
320	Generalized Abbreviation
easy, backtracking
Write a function to generate the generalized abbreviations of a word.

Example:
Given word = "word", return the following list (order does not matter):
["word", "1ord", "w1rd", "wo1d", "wor1", "2rd", "w2d", "wo2", "1o1d", "1or1", "w1r1", "1o2", "2r1", "3d", "w3", "4"]
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public List<string> GenerateAbbreviations(string word)
        {
            var ret = new List<string>();
            GenerateAbbreviations(ret, word, 0, "", 0);
            return ret;
        }

        private void GenerateAbbreviations(List<string> ret, string word, int pos, string cur, int count)
        {
            // happy
            if (pos == word.Length)
            {
                if (count > 0)
                {
                    cur += count;
                }

                ret.Add(cur);
                return;
            }

            // Choose count
            GenerateAbbreviations(ret, word, pos + 1, cur, count + 1);

            // Not choose count
            GenerateAbbreviations(ret, word, pos + 1, cur + (count > 0 ? count.ToString() : "") + word[pos], 0);
        }
    }
}
