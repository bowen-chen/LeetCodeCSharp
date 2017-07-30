/*
466 Count The Repetitions
Define S = [s,n] as the string S which consists of n connected strings s. For example, ["abc", 3] ="abcabcabc".

On the other hand, we define that string s1 can be obtained from string s2 if we can remove some characters from s2 such that it becomes s1. For example, “abc” can be obtained from “abdbec” based on our definition, but it can not be obtained from “acbbe”.

You are given two non-empty strings s1 and s2 (each at most 100 characters long) and two integers 0 ≤ n1 ≤ 106 and 1 ≤ n2 ≤ 106. Now consider the strings S1 and S2, where S1=[s1,n1] and S2=[s2,n2]. Find the maximum integer M such that [S2,M] can be obtained from S1.

Example:

Input:
s1="acb", n1=4
s2="ab", n2=2

Return:
2
*/

namespace Demo
{
    public partial class Solution
    {
        public int GetMaxRepetitions(string s1, int n1, string s2, int n2)
        {
            var repeatCount = new int[n1 + 1];
            var nextIndex = new int[n1+1];
            int j = 0, cnt = 0;
            for (int k = 1; k <= n1; ++k)
            {
                for (int i = 0; i < s1.Length; ++i)
                {
                    if (s1[i] == s2[j])
                    {
                        ++j;
                        if (j == s2.Length)
                        {
                            j = 0;
                            ++cnt;
                        }
                    }
                }

                // at the end of k segment, we matched cnt of s2 and j-1 chars, next we will match j
                repeatCount[k] = cnt;
                nextIndex[k] = j;

                for (int start = 0; start < k; ++start)
                {
                    // we found a pattern from (start to k]
                    if (nextIndex[start] == j)
                    {
                        // before pattern start
                        int prefixCount = repeatCount[start];

                        // pattern matches * pattern count
                        int patternLength = k - start;
                        int remainingLength = n1 - start;
                        int patternCount = (repeatCount[k] - repeatCount[start]) * remainingLength / patternLength;

                        // after pattern matches
                        int suffixCount = repeatCount[start + remainingLength % patternLength] - repeatCount[start];
                        return (prefixCount + patternCount + suffixCount) / n2;
                    }
                }
            }

            // no pattern found
            return repeatCount[n1] / n2;
        }
    }
}
