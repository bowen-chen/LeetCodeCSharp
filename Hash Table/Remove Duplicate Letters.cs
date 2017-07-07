/*
316	Remove Duplicate Letters
hard
Given a string which contains only lowercase letters, remove duplicate letters so that every letter appear once and only once. You must make sure your result is the smallest in lexicographical order among all possible results.

Example:
Given "bcabc"
Return "abc"

Given "cbacdcbc"
Return "acdb"
*/
using System.Collections.Generic;
using System.Linq;

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

        public string RemoveDuplicateLetters3(string s) {
            if (s == null || s.Length <= 1)
            {
                return s;
            }

            var lastPos = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (!lastPos.ContainsKey(s[i]))
                {
                    lastPos[s[i]] = 0;
                }
                lastPos[s[i]] = i;
            }   

            string result = string.Empty;
            int begin = 0;
            int end =  lastPos.Values.Min();

            while (lastPos.Count != 0)
            {
                // init with max char
                char minChar = (char)('z' + 1);
                for (int k = begin; k <= end; k++)
                {
                    if (lastPos.ContainsKey(s[k]) && s[k] < minChar)
                    {
                        minChar = s[k];
                        begin = k + 1;
                    }
                }

                result += minChar;
                lastPos.Remove(minChar);

                if (s[end] == minChar && lastPos.Count != 0)
                {
                    end = lastPos.Values.Min();
                }
            }
            return result;
        }
    }
}
