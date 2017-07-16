/*
201	Bitwise AND of Numbers Range
easy, bit
Given a range [m, n] where 0 <= m <= n <= 2147483647, return the bitwise AND of all numbers in this range, inclusive.

For example, given the range [5, 7], you should return 4.
*/

namespace Demo
{
    public partial class Solution
    {
        public int RangeBitwiseAnd(int m, int n)
        {
            if (m == 0)
            {
                return 0;
            }

            // find common prefix
            int moveFactor = 1;
            while (m != n)
            {
                m >>= 1;
                n >>= 1;
                moveFactor++;
            }

            return m << moveFactor;
        }
    }
}
