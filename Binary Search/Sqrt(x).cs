/*
69. Sqrt(x)
medium, low/high, *
Implement int sqrt(int x).

Compute and return the square root of x.
*/
using System;

namespace Demo
{
    public partial class Solution
    {
        public void Test_MySqrt()
        {
            Console.WriteLine(MySqrt(0));
            Console.WriteLine(MySqrt(1));
            Console.WriteLine(MySqrt(5));
            Console.WriteLine(MySqrt(100));
            Console.WriteLine(MySqrt(2147483647));
        }

        public int MySqrt(int x)
        {
            if (x == 0)
            {
                return 0;
            }

            // find first low doesn't meet x > low * low
            int low = 1;
            int high = x;
            while (low <= high)
            {
                int mid = low + (high - low)/2;
                if (x/mid > mid)
                {
                    low = mid + 1;
                }
                else if (x/mid < mid)
                {
                    high = mid - 1;
                }
                else
                {
                    return mid;
                }
            }

            // low is the first mid that x < mid*mid
            return low - 1;
        }
    }
}
