/*
415. Add Strings
Given two non-negative integers num1 and num2 represented as string, return the sum of num1 and num2.

Note:

The length of both num1 and num2 is < 5100.
Both num1 and num2 contains only digits 0-9.
Both num1 and num2 does not contain any leading zero.
You must not use any built-in BigInteger library or convert the inputs to integer directly.
*/

namespace Demo
{
    public partial class Solution
    {
        public string AddStrings(string num1, string num2)
        {
            string res = "";
            int carry = 0;
            int i = num1.Length - 1;
            int j = num2.Length - 1;
            while (i >= 0 || j >= 0 || carry == 1)
            {
                carry += i >= 0 ? num1[i--] - '0' : 0;
                carry += j >= 0 ? num2[j--] - '0' : 0;
                res = (char) (carry%10 + '0') + res;
                carry /= 10;
            }

            return res;
        }
    }
}
