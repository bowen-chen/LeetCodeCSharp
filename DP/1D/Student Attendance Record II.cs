/*
552	Student Attendance Record II
*
Given a positive integer n, return the number of all possible attendance records with length n, which will be regarded as rewardable. The answer may be very large, return it after mod 109 + 7.

A student attendance record is a string that only contains the following three characters:

'A' : Absent.
'L' : Late.
'P' : Present.
A record is regarded as rewardable if it doesn't contain more than one 'A' (absent) or more than two continuous 'L' (late).

Example 1:
Input: n = 2
Output: 8 
Explanation:
There are 8 records with length 2 will be regarded as rewardable:
"PP" , "AP", "PA", "LP", "PL", "AL", "LA", "LL"
Only "AA" won't be regarded as rewardable owing to more than one absent times. 
*/

namespace Demo
{
    public partial class Solution
    {
        public int CheckRecord(int n)
        {
            int m = 1000000007;
            if (n == 0)
            {
                return 0;
            }

            if (n == 1)
            {
                return 3;
            }

            // dp[i]the number of all possible attendance (without 'A') records with length i
            // end with "P": dp[i - 1]
            // end with "PL": dp[i - 2]
            // end with "PLL": dp[i - 3]
            // end with "LLL": is not allowed
            var dp = new long[n + 1];
            dp[0] = 1;
            dp[1] = 2; // P, L
            dp[2] = 4; // PP, LL, PL, LP
            for (int i = 3; i <= n; i++)
            {
                dp[i] = dp[i - 1]%m + dp[i - 2]%m + dp[i - 3]%m;
            }

            var res = dp[n];

            // insert A into all possible location
            for (int i = 0; i <= n-1; i++)
            {
                res += dp[i]*(n - i - 1 > 0 ? dp[n - i - 1] : 1)%m;
                res %= m;
            }

            return (int)res;
        }
    }
}
