/*
527	Word Abbreviation   
Given an array of n distinct non-empty strings, you need to generate minimal possible abbreviations for every word following rules below.

Begin with the first character and then the number of characters abbreviated, which followed by the last character.
If there are any conflict, that is more than one words share the same abbreviation, a longer prefix is used instead of only the first character until making the map from word to abbreviation become unique. In other words, a final abbreviation cannot map to more than one original words.
If the abbreviation doesn't make the word shorter, then keep it as original.
Example:

Input: ["like", "god", "internal", "me", "internet", "interval", "intension", "face", "intrusion"]
Output: ["l2e","god","internal","me","i6t","interval","inte4n","f2e","intr4n"]
 

Note:

Both n and the length of each word will not exceed 400.
The length of each word is greater than 1.
The words consist of lowercase English letters only.
The return answers should be in the same order as the original array.
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public List<string> WordsAbbreviation(List<string> dict)
        {
            int n = dict.Count;
            var res = new List<string>(n);
            var pre = new int[n];

            for (int i = 0; i < n; ++i)
            {
                pre[i] = 1;
                res[i] = Abbreviate(dict[i], pre[i]);
            }

            for (int i = 0; i < n; ++i)
            {
                bool dup = true;
                while (dup)
                {
                    dup = false;
                    for (int j = i + 1; j < n; ++j)
                    {
                        if (res[j] == res[i])
                        {
                            dup = true;
                            res[j] = Abbreviate(dict[j], ++pre[j]);
                        }
                    }

                    if (dup)
                    {
                        res[i] = Abbreviate(dict[i], ++pre[i]);
                    }
                }
            }

            return res;
        }

        // create a abbreviate and keep the first k chars
        private string Abbreviate(string s, int k)
        {
            return (k >= s.Length - 2) ? s : s.Substring(0, k) + (s.Length - k - 1) + s[s.Length - 1];
        }
    }
}
