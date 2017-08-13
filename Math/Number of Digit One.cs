/*
233	Number of Digit One
hard, math
Number of Digit One
Given an integer n, count the total number of digit 1 appearing in all non-negative integers less than or equal to n.

For example:
Given n = 13,
Return 6, because digit 1 occurred in the following numbers: 1, 10, 11, 12, 13.

Hint:

Beware of overflow.
*/

namespace Demo
{
    public partial class Solution
    {
        public void Test_CountDigitOne()
        {
            CountDigitOne(10);
        }

        public int CountDigitOne(int n)
        {
            long ones = 0;
            for (long m = 1; m <= n; m *= 10)
            {
                // mth digit
                long a = n/m%10;

                // digit afer mth;
                long b = n%m;

                // total number before mth
                long c = n/m/10;

                //CAB
                if (a == 0)
                {
                    // [0, C-1]1X
                    ones += c*(m);
                }
                else if (a > 1)
                {
                    // [0, C-1]1X
                    ones += c*(m);

                    // C1X
                    ones += m;
                }
                else if (a == 1)
                {
                    // [0, C-1]1X
                    ones += c*(m);

                    // C1[0, B]
                    ones += b + 1;
                }
            }

            return (int)ones;
        }
    }
}
