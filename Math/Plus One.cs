/*
66	Plus One
easy, math, *
Given a non-negative number represented as an array of digits, plus one to the number.

The digits are stored such that the most significant digit is at the head of the list.
*/

namespace Demo
{
    public partial class Solution
    {
        public int[] PlusOne(int[] digits)
        {
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                digits[i] ++;
                if (digits[i] == 10)
                {
                    digits[i] = 0;
                }
                else
                {
                    return digits;
                }
            }

            var ret = new int[digits.Length + 1];
            ret[0] = 1;
            return ret;
        }
    }
}
