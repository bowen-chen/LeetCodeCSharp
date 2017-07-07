/*
7	Reverse Integer
easy
Reverse digits of an integer.

Example1: x = 123, return 321
Example2: x = -123, return -321

click to show spoilers.

Have you thought about this?
Here are some good questions to ask before coding. Bonus points for you if you have already thought through this!

If the integer's last digit is 0, what should the output be? ie, cases such as 10, 100.

Did you notice that the reversed integer might overflow? Assume the input is a 32-bit integer, then the reverse of 1000000003 overflows. How should you handle such cases?

For the purpose of this problem, assume that your function returns 0 when the reversed integer overflows.
*/

using System;

namespace Demo
{
    public partial class Solution
    {
        public int Reverse(int x)
        {
            int res = 0;
            while (x != 0)
            {
                if (Math.Abs(res) > int.MaxValue/10)
                {
                    return 0;
                }
                res = res * 10 + x % 10;
                x /= 10;
            }
            return res;
        }

        public int Reverse2(int x)
        {
            bool negative = false;
            if (x < 0)
            {
                x = -x;
                negative = true;
            }
            long ret = 0;
            while (x > 0)
            {
                ret = ret * 10 + x % 10;
                x /= 10;
            }

            ret = negative ? -ret : ret;
            if (ret > int.MaxValue || ret < int.MinValue)
            {
                return 0;
            }

            return (int)ret;
        }
    }
}
