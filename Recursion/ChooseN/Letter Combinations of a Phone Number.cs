/*
17	Letter Combinations of a Phone Number
easy
Given a digit string, return all possible letter combinations that the number could represent.

A mapping of digit to letters (just like on the telephone buttons) is given below.

Input:Digit string "23"
Output: ["ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf"].
*/

using System.Collections.Generic;
using System.Text;

namespace Demo
{
    public partial class Solution
    {
        public void LetterCombinations_Tests()
        {
            LetterCombinations("");
            LetterCombinations("2");
        }

        public IList<string> LetterCombinations(string digits)
        {
            List<string> ret = new List<string>();
            LetterCombinations(ret, digits, 0, new StringBuilder(digits.Length));
            return ret;
        }

        private static readonly string[] Keys = { "", "", "abc", "def", "ghi", "jkl", "mno",
            "pqrs", "tuv", "wxyz" };

        private void LetterCombinations(List<string> ret, string digits, int start, StringBuilder sb)
        {
            if (start >= digits.Length)
            {
                ret.Add(sb.ToString());
                return;
            }

            foreach (char c in Keys[digits[start] - '0'])
            {
                sb[start] = c;
                LetterCombinations(ret, digits, start + 1, sb);
            }
        }
    }
}
