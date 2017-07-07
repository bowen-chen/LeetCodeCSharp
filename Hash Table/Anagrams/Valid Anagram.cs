/*
242	Valid Anagram
easy, hash
Valid Anagram

Given two strings s and t, write a function to determine if t is an anagram of s.

For example,
s = "anagram", t = "nagaram", return true.
s = "rat", t = "car", return false.

Note:
You may assume the string contains only lowercase alphabets.

Follow up:
What if the inputs contain unicode characters? How would you adapt your solution to such case?
*/
namespace Demo
{
    public partial class Solution
    {
        public bool IsAnagram(string s, string t)
        {
            if (s == null && t == null)
            {
                return true;
            }

            if (t == null || s == null)
            {
                return false;
            }

            if (t.Length != s.Length)
            {
                return false;
            }

            int[] h = new int[26];
            foreach (var a in s)
            {
                h[a - 'a']++;
            }

            foreach (var a in t)
            {
                if ((--h[a - 'a']) < 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
