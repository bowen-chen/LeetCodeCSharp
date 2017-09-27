/*
474. Ones and Zeroes
*
In the computer world, use restricted resource you have to generate maximum benefit is what we always want to pursue.

For now, suppose you are a dominator of m 0s and n 1s respectively. On the other hand, there is an array with strings consisting of only 0s and 1s.

Now your task is to find the maximum number of strings that you can form with given m 0s and n 1s. Each 0 and 1 can be used at most once.

Note:
The given numbers of 0s and 1s will both not exceed 100
The size of given string array won't exceed 600.
Example 1:
Input: Array = {"10", "0001", "111001", "1", "0"}, m = 5, n = 3
Output: 4

Explanation: This are totally 4 strings can be formed by the using of 5 0s and 3 1s, which are “10,”0001”,”1”,”0”
Example 2:
Input: Array = {"10", "0", "1"}, m = 1, n = 1
Output: 2

Explanation: You could form "10", but then you'd have nothing left. Better form "0" and "1".
*/

using System;

namespace Demo
{
    public partial class Solution
    {
        public int FindMaxForm(string[] strs, int m, int n)
        {
            // max word canbe form by m 0s, n 1s.
            var dp = new int[m + 1, n + 1];
            foreach (string str in strs)
            {
                int zeros = 0, ones = 0;
                foreach (char c in str)
                {
                    if (c == '0')
                    {
                        ++zeros;
                    }
                    else
                    {
                        ++ones;
                    }
                }

                // REVERSE ORDER MATTERS
                for (int i = m; i >= zeros; --i)
                {
                    for (int j = n; j >= ones; --j)
                    {
                        dp[i, j] = Math.Max(dp[i, j], dp[i - zeros, j - ones] + 1);
                    }
                }
            }

            return dp[m, n];
        }
    }
}
