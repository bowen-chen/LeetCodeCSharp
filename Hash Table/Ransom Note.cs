/*
383. Ransom Note
easy, *
Given an arbitrary ransom note string and another string containing letters from all the magazines, write a function that will return true if the ransom note can be constructed from the magazines ; otherwise, it will return false.

Each letter in the magazine string can only be used once in your ransom note.

Note:
You may assume that both strings contain only lowercase letters.

canConstruct("a", "b") -> false
canConstruct("aa", "ab") -> false
canConstruct("aa", "aab") -> true
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public bool CanConstruct(string ransomNote, string magazine)
        {
            var m = new Dictionary<char, int>();
            foreach (char c in magazine)
            {
                if (!m.ContainsKey(c))
                {
                    m[c] = 0;
                }

                ++m[c];
            }

            foreach (char c in ransomNote)
            {
                if (!m.ContainsKey(c) || --m[c] < 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
