/*
567. Permutation in String
*
Given two strings s1 and s2, write a function to return true if s2 contains the permutation of s1. In other words, one of the first string's permutations is the substring of the second string.

Example 1:
Input:s1 = "ab" s2 = "eidbaooo"
Output:True
Explanation: s2 contains one permutation of s1 ("ba").
Example 2:
Input:s1= "ab" s2 = "eidboaoo"
Output: False
Note:
The input strings only contain lower case letters.
The length of both given strings is in range [1, 10,000].

*/

namespace Demo
{
    public partial class Solution
    {
        public bool CheckInclusion(string p, string s)
        {
            if (string.IsNullOrEmpty(p) || string.IsNullOrEmpty(s))
            {
                return false;
            }

            int[] m = new int[26];
            foreach (char c in p)
            {
                m[c - 'a']++;
            }

            // count is sum of all the positive hash value
            int count = p.Length;
            int len = p.Length;
            for (int i = 0; i < s.Length; i++)
            {
                if (m[s[i] - 'a']-- >= 1)
                {
                    count--;
                }

                if (count == 0)
                {
                    return true;
                }

                int left = i - len + 1;
                if (left >= 0)
                {
                    if (m[s[left] - 'a']++ >= 0)
                    {
                        count++;
                    }
                }
            }

            return false;
        }
    }
}
