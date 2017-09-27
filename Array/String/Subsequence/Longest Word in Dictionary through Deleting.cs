/*
524. Longest Word in Dictionary through Deleting
*
Given a string and a string dictionary, find the longest string in the dictionary that can be formed by deleting some characters of the given string. If there are more than one possible results, return the longest word with the smallest lexicographical order. If there is no possible result, return the empty string.

Example 1:
Input:
s = "abpcplea", d = ["ale","apple","monkey","plea"]

Output: 
"apple"
Example 2:
Input:
s = "abpcplea", d = ["a","b","c"]

Output: 
"a"
Note:
All the strings in the input will only contain lower-case letters.
The size of the dictionary won't exceed 1,000.
The length of all the strings in the input won't exceed 1,000.

*/

using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    public partial class Solution
    {
        public string FindLongestWord(string s, IList<string> d)
        {
            var ret = "";
            foreach (string str in d)
            {
                int i = 0;
                for (int j = 0; j < s.Length && i < str.Length; j++)
                {
                    if (s[j] == str[i])
                    {
                        i++;
                    }
                }

                if (i == str.Length &&
                   (str.Length > ret.Length ||
                     (str.Length == ret.Length && str.CompareTo(ret) < 0)))
                {
                    ret = str;
                }
            }
            return ret;
        }
    }
}
