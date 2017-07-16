/*
172	Factorial Trailing Zeroes
easy, math
Given an integer n, return the number of trailing zeroes in n!.

Note: Your solution should be in logarithmic time complexity.
*/

namespace Demo
{
    public partial class Solution
    {
        public int TrailingZeroes(int n)
        {
            int result = 0;

            // 0 is 2*5
            for (long i = 5; n/i > 0; i *= 5)
            {
                result += (int) (n/i);
            }
            return result;
        }
    }
}
