/*
647. Palindromic Substrings
*
Given a string, your task is to count how many palindromic substrings in this string.

The substrings with different start indexes or end indexes are counted as different substrings even they consist of same characters.

Example 1:
Input: "abc"
Output: 3
Explanation: Three palindromic strings: "a", "b", "c".
Example 2:
Input: "aaa"
Output: 6
Explanation: Six palindromic strings: "a", "a", "a", "aa", "aa", "aaa".
Note:
The input string length won't exceed 1000.

*/

namespace Demo
{
    public partial class Solution
    {
        public int CountSubstrings(string s)
        {
            int count = 0;
            int n = s.Length;
            bool[,] dp = new bool[n, n]; // i to j is Palindrome.

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (s[i] == s[j]
                        && (i - j < 2 /*1, 2 char*/
                            || dp[j + 1, i - 1]) /*only more than 3 char*/)
                    {
                        dp[j, i] = true;
                        count++;
                    }
                }
            }

            return count;
        }
    }
}
