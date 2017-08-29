/*
67	Add Binary
easy, math, *
Given two binary strings, return their sum (also a binary string).

For example,
a = "11"
b = "1"
Return "100".
*/

namespace Demo
{
    public partial class Solution
    {
        public string AddBinary(string a, string b)
        {
            string res = "";
            int carry = 0;
            int i = a.Length - 1;
            int j = b.Length - 1;
            while (i >= 0 || j >= 0 || carry == 1)
            {
                carry += i >= 0 ? a[i--] - '0' : 0;
                carry += j >= 0 ? b[j--] - '0' : 0;
                res = (char) (carry%2 + '0') + res;
                carry /= 2;
            }

            return res;
        }
    }
}
