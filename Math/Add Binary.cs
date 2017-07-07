/*
67	Add Binary
easy, math
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
            string s = "";

            int c = 0, i = a.Length - 1, j = b.Length - 1;
            while (i >= 0 || j >= 0 || c == 1)
            {
                c += i >= 0 ? a[i--] - '0' : 0;
                c += j >= 0 ? b[j--] - '0' : 0;
                s = (char) (c%2 + '0') + s;
                c /= 2;
            }

            return s;
        }
    }
}
