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
            int m = num1.Length;
            int n = num2.Length;
            int i = m - 1;
            int j = n - 1;
            int carry = 0;
            while (i >= 0 || j >= 0)
            {
                int a = i >= 0 ? num1[i--] - '0' : 0;
                int b = j >= 0 ? num2[j--] - '0' : 0;
                int sum = a + b + carry;
                res = res.Insert(0, ((char)(sum%10 + '0')).ToString());
                carry = sum/10;
            }

            return carry == 1 ? "1" + res : res;
        }
    }
}
