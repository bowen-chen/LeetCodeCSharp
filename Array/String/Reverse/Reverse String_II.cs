/*
541. Reverse String II
Given a string and an integer k, you need to reverse the first k characters for every 2k characters counting from the start of the string. If there are less than k characters left, reverse all of them. If there are less than 2k but greater than or equal to k characters, then reverse the first k characters and left the other as original.
Example:
Input: s = "abcdefg", k = 2
Output: "bacdfeg"
Restrictions:
The string consists of lower English letters only.
Length of the given string and k will in the range [1, 10000]
*/

using System;

namespace Demo
{
    public partial class Solution
    {
        public string ReverseStr(string s, int k)
        {
            var c = s.ToCharArray();
            for (int i = 0; i < s.Length; i += 2 * k)
            {
                ReverseStr(c, i, Math.Min(i + k - 1, s.Length - 1));
            }

            return new string(c);
        }

        public void ReverseStr(char[] s, int i, int j)
        {
            while (i < j)
            {
                var t = s[i];
                s[i] = s[j];
                s[j] = t;
                i++;
                j--;
            }
        }
    }
}
