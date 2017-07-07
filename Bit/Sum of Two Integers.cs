/*
371. Sum of Two Integers
Calculate the sum of two integers a and b, but you are not allowed to use the operator + and -.

Example:
Given a = 1 and b = 2, return 3.
*/

namespace Demo
{
    public partial class Solution
    {
        public int GetSum(int a, int b)
        {
            if (b == 0) return a;
            int sum = a ^ b;
            int carry = (a & b) << 1;
            return GetSum(sum, carry);
        }
    }
}
