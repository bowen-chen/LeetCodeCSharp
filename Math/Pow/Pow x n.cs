/*
50	Pow(x, n)
easy, math, recursion
Implement pow(x, n).
*/

namespace Demo
{
    public partial class Solution
    {
        public double MyPow(double x, int n)
        {
            // x^n = (1/x)^-n, but -n could overflow
            if (n < 0)
            {
                return 1 / x * MyPow(1 / x, -(n + 1));
            }

            if (n == 0)
            {
                return 1;
            }

            if (n == 1)
            {
                return x;
            }

            return MyPow(x * x, n / 2) * MyPow(x, n % 2);
        }
    }
}
