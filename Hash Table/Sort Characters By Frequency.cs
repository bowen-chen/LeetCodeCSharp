/*
451	Sort Characters By Frequency
easy
Given a string, sort it in decreasing order based on the frequency of characters.

Example 1:

Input:
"tree"

Output:
"eert"

Explanation:
'e' appears twice while 'r' and 't' both appear once.
So 'e' must appear before both 'r' and 't'. Therefore "eetr" is also a valid answer.
Example 2:

Input:
"cccaaa"

Output:
"cccaaa"

Explanation:
Both 'c' and 'a' appear three times, so "aaaccc" is also a valid answer.
Note that "cacaca" is incorrect, as the same characters must be together.
Example 3:

Input:
"Aabb"

Output:
"bbAa"

Explanation:
"bbaA" is also a valid answer, but "Aabb" is incorrect.
Note that 'A' and 'a' are treated as two different characters.
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    public partial class Solution
    {
        public string FrequencySort(string s)
        {
            var res = new StringBuilder();
            var charToInt = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (!charToInt.ContainsKey(c))
                {
                    charToInt[c] = 0;
                }
                charToInt[c]++;
            }

            int max = 0;
            var intToString = new Dictionary<int, string>();
            foreach (var kvp in charToInt)
            {
                if (!intToString.ContainsKey(kvp.Value))
                {
                    intToString[kvp.Value] = "";
                }
                intToString[kvp.Value] += new string(kvp.Key, kvp.Value);
                max = Math.Max(max, kvp.Value);
            }
            for (int i = max; i > 0; --i)
            {
                if (intToString.ContainsKey(i))
                {
                    res.Append(intToString[i]);
                }
            }
            return res.ToString();
        }
    }
}
