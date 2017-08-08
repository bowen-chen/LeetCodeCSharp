/*
629. K Inverse Pairs Array
revisit
Given two integers n and k, find how many different arrays consist of numbers from 1 to n such that there are exactly k inverse pairs.

We define an inverse pair as following: For ith and jth element in the array, if i < j and a[i] > a[j] then it's an inverse pair; Otherwise, it's not.

Since the answer may be very large, the answer should be modulo 109 + 7.

Example 1:
Input: n = 3, k = 0
Output: 1
Explanation: 
Only the array [1,2,3] which consists of numbers from 1 to 3 has exactly 0 inverse pair.
Example 2:
Input: n = 3, k = 1
Output: 2
Explanation: 
The array [1,3,2] and [2,1,3] have exactly 1 inverse pair.
Note:
The integer n is in the range [1, 1000] and k is in the range [0, 1000].
*/

namespace Demo
{
    public partial class Solution
    {
        // dp[n,k] the k inverse pairs at with number n
        // dp[n, 0] = 1
        // xxxxN, give 0 inverse pairs, dp[n-1, k]
        // xxxNx, give 1 inverse pairs, dp[n-1, k-1]
        // xxNxx, give 2 inverse pairs, dp[n-1, k-2]
        // ...
        // Nxxxx, give n-1 inverse pairs, dp[n-1, k-(n-1)]
        // dp[n][k] = dp[n - 1][k] + dp[n - 1][k - 1] + ... + dp[n - 1][k - (n - 1)]
        public int KInversePairs(int n, int k)
        {
            int M = 1000000007;
            int[,] dp = new int[n + 1, k + 1];
            for (int i = 0; i <= n; ++i)
            {
                dp[i, 0] = 1;
                for (int m = 1; m <= k; ++m)
                {
                    // dp[n - 1][k - j]
                    for (int j = 0; j <= i - 1 && j <= m; ++j)
                    {
                        dp[i, m] = dp[i, m] + dp[i - 1, m - j];
                        dp[i, m] %= M;
                    }
                }
            }

            return dp[n, k];
        }

        // dp[n][k] = dp[n - 1][k] + dp[n - 1][k - 1] + ... + dp[n - 1][k - (n - 1)]
        // dp[n][k] = dp[n - 1][k] + dp[n - 1][k - 1] + ... + dp[n - 1][k - n + 1]
        // dp[n][k-1] = dp[n - 1][k-1] + dp[n - 1][k - 1 - 1] + ... + dp[n - 1][k - 1 - (n - 1)]
        // dp[n][k-1] = dp[n - 1][k-1] + dp[n - 1][k - 2] + ... + dp[n - 1][k - n]
        // dp[n][k] - dp[n][k-1] = dp[n - 1][k] - dp[n - 1][k - n]
        // dp[n][k] = dp[n][k-1] + dp[n - 1][k] - dp[n - 1][k - n] 
        public int KInversePairs2(int n, int k)
        {
            int M = 1000000007;
            int[,] dp = new int[n + 1, k + 1];
            dp[0, 0] = 1;
            for (int i = 1; i <= n; ++i)
            {
                dp[i, 0] = 1;
                for (int m = 1; m <= k; ++m)
                {
                    dp[i, m] = (dp[i, m - 1] + dp[i - 1, m]);
                    dp[i, m] %= M;
                    if (m >= i)
                    {
                        dp[i, m] -= dp[i - 1, m - i];
                        dp[i, m] += M;
                        dp[i, m] %= M;
                    }

                }
            }

            return dp[n, k];
        }

        public int KInversePairs3(int n, int k)
        {
            int M = 1000000007;
            int[] dp = new int[k + 1];
            dp[0] = 1;
            for (int i = 1; i <= n; ++i)
            {
                var dp2 = new int[k + 1];
                dp2[0] = 1;
                for (int m = 1; m <= k; ++m)
                {
                    dp2[m] = (dp2[m - 1] + dp[m]);
                    dp2[m] %= M;
                    if (m >= i)
                    {
                        dp2[m] -= dp[m - i];
                        dp2[m] += M;
                        dp2[m] %= M;
                    }
                }

                dp = dp2;
            }

            return dp[k];
        }
    }
}
