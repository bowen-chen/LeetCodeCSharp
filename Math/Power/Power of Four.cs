/*
342. Power of Four
easy math, *
Given an integer (signed 32 bits), write a function to check whether it is a power of 4.

Example:
Given num = 16, return true. Given num = 5, return false.

Follow up: Could you solve it without loops/recursion?
*/

namespace Demo
{
    public partial class Solution
    {
        public bool IsPowerOfFour(int num)
        {
            // 4^n = (3 * 4 ^(n-1)) + 4^(n-1) 
            return num > 0
                   && (num & (num - 1)) == 0 // power of 2
                   && (num - 1)%3 == 0;
        }

        public bool IsPowerOfFour2(int num)
        {
            // 55, 01010101
            return num > 0 && (num & (num - 1)) == 0 && (num & 0x55555555) == num;
        }
    }
}
