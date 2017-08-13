/*
479. Largest Palindrome Product
Find the largest palindrome made from the product of two n-digit numbers.

Since the result could be very large, you should return the largest palindrome mod 1337.

Example:

Input: 2

Output: 987

Explanation: 99 x 91 = 9009, 9009 % 1337 = 987

Note:

The range of n is [1,8].
*/

using System;

namespace Demo
{
    public partial class Solution
    {
        public int LargestPalindrome(int n)
        {
            // if input is 1 then max is 9 
            if (n == 1)
            {
                return 9;
            }

            // if n = 3 then upperBound = 999 and lowerBound = 99
            long upperBound = (long) Math.Pow(10, n) - 1;
            long lowerBound = upperBound / 10;
            long maxNumber = upperBound * upperBound;

            // represents the first half of the maximum assumed palindrom.
            // e.g. if n = 3 then maxNumber = 999 x 999 = 998001 so firstHalf = 998
            int firstHalf = (int)(maxNumber / (long)Math.Pow(10, n));

            while (firstHalf > 0)
            {
                // creates maximum assumed palindrom
                // e.g. if n = 3 first time the maximum assumed palindrom will be 998 899
                long palindrom = createPalindrom(firstHalf);

                // here i and palindrom/i forms the two factor of assumed palindrom
                for (long i = upperBound; i*upperBound >= palindrom && i > lowerBound; i--)
                {
                    // if two factors found, where both of them are n-digits,
                    if (palindrom%i == 0)
                    {
                        Console.WriteLine("{0} x {1} = {2}", i, palindrom/i, palindrom);
                        return (int) (palindrom%1337);
                    }
                }

                firstHalf--;
            }

            return 0;
        }

        private long createPalindrom(long num)
        {
            var t = num.ToString().ToCharArray();
            Array.Reverse(t);
            string str = num + new string(t);
            return long.Parse(str);
        }
    }
}
