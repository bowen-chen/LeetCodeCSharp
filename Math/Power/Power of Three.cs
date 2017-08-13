/*
326 Power of Three   
easy, math
Given an integer, write a function to determine if it is a power of three.

Follow up:
Could you do it without using any loop / recursion?
*/

using System;

namespace Demo
{
    public partial class Solution
    {
        // all prime number can be solved by this.
        private const int MaxPowOfThree = 1162261467;

        public bool IsPowerOfThree2(int n)
        {
            return n > 0 && MaxPowOfThree%n == 0;
        }

        /*
        logab = logcb / logca
        log3n = log10n / log103
        */
        public bool IsPowerOfThree3(int n)
        {
            return (n > 0 && (int)(Math.Log10(n) / Math.Log10(3)) - Math.Log10(n) / Math.Log10(3) == 0);
        }
    }
}
