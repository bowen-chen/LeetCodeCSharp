/*
139	Word Break
dp, easy, *
Word Break

Given a string s and a dictionary of words dict, determine if s can be segmented into a space-separated sequence of one or more dictionary words.

For example, given
s = "leetcode",
dict = ["leet", "code"].

Return true because "leetcode" can be segmented as "leet code".
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public bool WordBreak(string s, ISet<string> wordDict)
        {
            bool[] dp = new bool[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i; j >= 0; j--)
                {
                    if ((j == 0 || dp[j - 1]) && wordDict.Contains(s.Substring(j, i - j + 1)))
                    {
                        dp[i] = true;
                        break;
                    }
                }
            }

            return dp[s.Length - 1];
        }
    }
}
