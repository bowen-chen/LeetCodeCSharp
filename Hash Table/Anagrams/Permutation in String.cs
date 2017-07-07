/*
567. Permutation in String
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
        public bool CheckInclusion(string s1, string s2)
        {
            int n1 = s1.Length;
            int n2 = s2.Length;
            int cnt = n1;
            int left = 0;
            var m = new int[26];
            foreach (char c in s1)
            {
                m[c - 'a']++;
            }
            for (int right = 0; right < n2; ++right)
            {
                if (m[s2[right] - 'a']-- > 0)
                {
                    cnt--;
                }
                while (cnt == 0)
                {
                    if (right - left + 1 == n1)
                    {
                        return true;
                    }

                    if (++m[s2[left++] - 'a'] > 0)
                    {
                        ++cnt;
                    }
                }
            }
            return false;
        }
    }
}
