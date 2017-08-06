﻿/*
408	Valid Word Abbreviation $
Given a non-empty string s and an abbreviation abbr, return whether the string matches with the given abbreviation.

A string such as "word" contains only the following valid abbreviations:

["word", "1ord", "w1rd", "wo1d", "wor1", "2rd", "w2d", "wo2", "1o1d", "1or1", "w1r1", "1o2", "2r1", "3d", "w3", "4"]
Notice that only the above abbreviations are valid abbreviations of the string "word". Any other string is not a valid abbreviation of "word".

Note:
Assume s contains only lowercase letters and abbr contains only lowercase letters and digits.

Example 1:

Given s = "internationalization", abbr = "i12iz4n":

Return true.
 

Example 2:

Given s = "apple", abbr = "a2e":

Return false.
*/

namespace Demo
{
    public partial class Solution
    {
        public bool ValidWordAbbreviation(string word, string abbr)
        {
            int m = word.Length;
            int i = 0;
            int cnt = 0;
            foreach (char a in abbr)
            {
                if (a >= '0' && a <= '9')
                {
                    // a09b
                    if (cnt == 0 && a == '0')
                    {
                        return false;
                    }

                    cnt = 10*cnt + abbr[i] - '0';
                }
                else
                {
                    i += cnt;
                    cnt = 0;
                    if (i >= m || word[i++] != a)
                    {
                        return false;
                    }
                }
            }

            return i + cnt == m;
        }
    };
}