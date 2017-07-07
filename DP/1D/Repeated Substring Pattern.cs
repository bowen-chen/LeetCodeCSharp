/*
459	Repeated Substring Pattern 
Given a non-empty string check if it can be constructed by taking a substring of it and appending multiple copies of the substring together. You may assume the given string consists of lowercase English letters only and its length will not exceed 10000.

Example 1:
Input: "abab"

Output: True

Explanation: It's the substring "ab" twice.
Example 2:
Input: "aba"

Output: False
Example 3:
Input: "abcabcabcabc"

Output: True

Explanation: It's the substring "abc" four times. (And the substring "abcabc" twice.)
*/

namespace Demo
{
    public partial class Solution
    {
        public bool RepeatedSubstringPattern(string s)
        {
            int n = s.Length;
            for (int i =1;i<= n / 2; i++)
            {
                if (n % i == 0)
                {
                    int j = 0;
                    foreach (var c in s)
                    {
                        if (c != s[j%i])
                        {
                            break;
                        }
                        j++;
                    }
                    if (j == s.Length) return true;
                }
            }
            return false;
        }

        public bool RepeatedSubstringPattern2(string s)
        {
            // end of pattern
            int i = 1;
            // end of beginning string
            int j = 0;
            int n = s.Length;
            var dp = new int[n];
            // comparing to the beginning, the larget common prefix length ending i
            dp[0] = 0; 
            while (i < n)
            {
                if (s[i] == s[j])
                {
                    dp[i] = j + 1;
                    i++;
                    j++;
                }
                else if (j == 0)
                {
                    // if the current char does match the first char, move to next char
                    ++i;
                }
                else
                { 
                    // jump to last common prefix
                    j = dp[j - 1];
                }
            }
            return dp[n - 1] != 0 && (dp[n - 1]%(n - dp[n - 1]) == 0);
        }
    }
}
