/*
483. Smallest Good Base
For an integer n, we call k>=2 a good base of n, if all digits of n base k are 1.

Now given a string representing n, you should return the smallest good base of n in string format.

Example 1:
Input: "13"
Output: "3"
Explanation: 13 base 3 is 111.
Example 2:
Input: "4681"
Output: "8"
Explanation: 4681 base 8 is 11111.
Example 3:
Input: "1000000000000000000"
Output: "999999999999999999"
Explanation: 1000000000000000000 base 999999999999999999 is 11.
Note:
The range of n is [3, 10^18].
The string representing n is always valid and will not have leading zeros.
*/
using System;

namespace Demo
{
    public partial class Solution
    {
        // n = 1 + k + k^2 + k^3 + ... + k^(m-1)
        // nk = k + K + k^2 + ... + K^(m)
        // n(1-k) = 1 - K^m
        // k^m = 1-n+nK
        // m = Log(1-n+nk)/LogK
        // min k = 2, so max m = Log(1+n)/LogK
        // n>k^(m-1)
        // k <  n^(1 / (m-1))
        public string SmallestGoodBase(string n)
        {
            long num = long.Parse(n);
            for (long m = (long)(Math.Log(num + 1) / Math.Log(2)); m >= 2; --m)
            {
                long left = 2, right = (long)Math.Pow(num, 1.0 / (m-1)) + 1;
                while (left <= right)
                {
                    long mid = left + (right - left)/2;
                    long sum = 0;
                    long km = 1;
                    for (long j = 0; j < m; ++j)
                    {
                        sum = sum +km;
                        km *= mid;
                    }
                    if (sum == num)
                    {
                        return mid.ToString();
                    }
                    if (sum < num)
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
            }
            return (num - 1).ToString();
        }
    }
}
