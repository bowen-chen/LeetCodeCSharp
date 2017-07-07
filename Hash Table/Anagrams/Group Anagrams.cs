/*
49	Group Anagrams
easy
Given an array of strings, group anagrams together.

For example, given: ["eat", "tea", "tan", "ate", "nat", "bat"], 
Return:

[
  ["ate", "eat","tea"],
  ["nat","tan"],
  ["bat"]
]
Note:
For the return value, each inner list's elements must follow the lexicographic order.
All inputs will be in lower-case.
*/

using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    public partial class Solution
    {
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            return strs.OrderBy(s => s).GroupBy(s => new string(s.OrderBy(s1 => s1).ToArray()), s => s).Select(g => g.ToList()).ToList<IList<string>>();
        }

        public IList<IList<string>> GroupAnagrams2(string[] strs)
        {
            var dic = new Dictionary<string, IList<string>>();
            foreach (var s in strs.OrderBy(s => s))
            {
                var key = new string(s.OrderBy(s1 => s1).ToArray());
                if (!dic.ContainsKey(key))
                {
                    dic[key] = new List<string>();
                }
                dic[key].Add(s);
            }
            return dic.Values.ToList();
        }
    }
}
