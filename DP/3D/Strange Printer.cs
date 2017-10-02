/*
664. Strange Printer
There is a strange printer with the following two special requirements:

The printer can only print a sequence of the same character each time.
At each turn, the printer can print new characters starting from and ending at any places, and will cover the original existing characters.
Given a string consists of lower English letters only, your job is to count the minimum number of turns the printer needed in order to print it.

Example 1:
Input: "aaabbb"
Output: 2
Explanation: Print "aaa" first and then print "bbb".
Example 2:
Input: "aba"
Output: 2
Explanation: Print "aaa" first and then print "b" from the second place of the string, which will cover the existing character 'a'.
Hint: Length of the given string will not exceed 100.
*/

using System;

namespace Demo
{
    public partial class Solution
    {
        public int StrangePrinter(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }

            int n = s.Length;
            var dp = new int[n, n];
            for (int step = 1; step <= n; step++)
            {
                for (int i = 0; i+step-1 < n; i++)
                {
                    int j = i + step - 1;
                    dp[i, j] = step;
                    for (int k = i + 1; k <= j; k++)
                    {
                        int temp = dp[i, k - 1] + dp[k, j];
                        if (s[k - 1] == s[j]) /*don't need print s[j]*/
                        {
                            temp--;
                        }

                        dp[i,j] = Math.Min(dp[i, j], temp);
                    }
                }
            }

            return dp[0, n - 1];
        }
    }
}
