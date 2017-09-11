/*
316	Remove Duplicate Letters
hard, *
Given a string which contains only lowercase letters, remove duplicate letters so that every letter appear once and only once. You must make sure your result is the smallest in lexicographical order among all possible results.

Example:
Given "bcabc"
Return "abc"

Given "cbacdcbc"
Return "acdb"
*/
using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public string RemoveDuplicateLetters(string s)
        {
            var m = new int[128];
            foreach (var a in s)
            {
                ++m[a];
            }

            var res = new List<char>();
            
            // the charactor is already in the ret
            var visited = new bool[128];
            foreach (var a in s)
            {
                --m[a];
                if (visited[a])
                {
                    continue;
                }

                while (res.Count > 0 && a < res[res.Count - 1] && m[res[res.Count - 1]] > 0)
                {
                    visited[res[res.Count - 1]] = false;
                    res.RemoveAt(res.Count - 1);
                }

                res.Add(a);
                visited[a] = true;
            }

            return new string(res.ToArray());
        }
    }
}
