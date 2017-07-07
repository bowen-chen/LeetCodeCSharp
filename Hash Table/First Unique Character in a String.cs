/*
387. First Unique Character in a String
easy
Given a string, find the first non-repeating character in it and return it's index. If it doesn't exist, return -1.

Examples:

s = "leetcode"
return 0.

s = "loveleetcode",
return 2.
*/

namespace Demo
{
    public partial class Solution
    {
        public int FirstUniqChar(string s)
        {
            var m = new int[26];
            foreach (char c in s)
            {
                m[c-'a']++;
            }

            for (int i = 0; i < s.Length; ++i)
            {
                if (m[s[i]-'a'] == 1)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
