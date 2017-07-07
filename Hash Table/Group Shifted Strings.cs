/*
easy
Given a string, we can “shift” each of its letter to its successive letter, for example: “abc” -> “bcd”. We can keep “shifting” which forms the sequence:

"abc" -> "bcd" -> ... -> "xyz"
Given a list of strings which contains only lowercase alphabets, group all strings that belong to the same shifting sequence.

For example,

given: ["abc", "bcd", "acef", "xyz", "az", "ba", "a", "z"], Return:

[
  ["abc","bcd","xyz"],
  ["az","ba"],
  ["acef"],
  ["a","z"]
]
Note: For the return value, each inner list’s elements must follow the lexicographic order.
*/

using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    public partial class Solution
    {
        public List<List<string>> groupStrings(string[] strings)
        {
            var map = new Dictionary<string, List<string>>();
            foreach (string s in strings)
            {
                // we shift all string to start with "a"
                int offset = s[0] - 'a';
                string key = "";
                foreach (char c in s)
                {
                    char c2 = (char)(c - offset);
                    if (c2 < 'a')
                    {
                        c2 = (char)(c2 + 26);
                    }
                    key += c2;
                }
                if (!map.ContainsKey(key))
                {
                    map.Add(key, new List<string>());
                }
                map[key].Add(s);
            }
            foreach (var v in map.Values)
            {
                v.Sort();
            }
            return map.Values.ToList();
        }
    }
}
