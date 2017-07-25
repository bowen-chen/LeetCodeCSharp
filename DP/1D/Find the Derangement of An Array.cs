/*
634	Find the Derangement of An Array
n combinatorial mathematics, a derangement is a permutation of the elements of a set, such that no element appears in its original position.

There's originally an array consisting of n integers from 1 to n in ascending order, you need to find the number of derangement it can generate.

Also, since the answer may be very large, you should return the output mod 109 + 7.

Example 1:

Input: 3
Output: 2
Explanation: The original array is [1,2,3]. The two derangements are [2,3,1] and [3,1,2].
 

Note:
n is in the range of [1, 106].
*/

namespace Demo
{
    public partial class Solution
    {
        // init dp[0] = 0;
        // dp[1] = 0;
        // dp[k]
        // we put k at index i, where i != k
        // a. put the number i at k, dp[k-2]
        // b. put the numbe i not at k, treat k as i; dp[k-1] 
        // dp[k] = (dp[k-1]+dp[k-2])*(k-1)
        public int FindDerangement(int n)
        {
            if (n == 0)
            {
                return 0;
            }

            var dp = new int[n + 1];
            dp[1] = 0;
            dp[2] = 1;
            for (int i = 3; i <= n; ++i)
            {
                dp[i] = (dp[i - 1] + dp[i - 2]) * (i - 1) % 1000000007;
            }

            return dp[n];
        }

        public int FindDerangement2(int n)
        {
            if (n <= 1)
            {
                return 0;
            }

            int dp_1 = 0;
            int dp = 1;
            for (int i = 3; i <= n; ++i)
            {
                var dp2= (dp + dp_1) * (i - 1) % 1000000007;
                dp_1 = dp;
                dp = dp2;
            }

            return dp;
        }
    };
}
