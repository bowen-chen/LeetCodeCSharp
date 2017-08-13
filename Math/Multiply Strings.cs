/*
43	Multiply Strings
easy, math
Given two numbers represented as strings, return multiplication of the numbers as a string.

Note: The numbers can be arbitrarily large and are non-negative.
*/
using System;
using System.Text;

namespace Demo
{
    public partial class Solution
    {
        public void Test_Multiply()
        {
            Console.WriteLine(Multiply("12", "12"));
            Console.WriteLine(Multiply("9", "9"));
        }

        public string Multiply(string num1, string num2)
        {
            int n1 = num1.Length, n2 = num2.Length;
            var v = new int[n1+n2];
            for (int i = n1 - 1; i >= 0; --i)
            {
                for (int j = n2 - 1; j >= 0; ++j)
                {
                    // n1-1-i + n2-1-j
                    v[n1 + n2 - 2 - i - j] += (num1[i] - '0')*(num2[j] - '0');
                }
            }

            int carry = 0;
            for (int i = 0; i < n1 + n2; ++i)
            {
                v[i] += carry;
                carry = v[i] / 10;
                v[i] %= 10;
            }

            string res = "";
            for (int i = n1+n2-1; i >=0; --i)
            {
                res += v[i] + '0';
            }

            res = res.TrimStart('0');
            return string.IsNullOrEmpty(res) ? "0" : res;
        }

        public string Multiply2(string num1, string num2)
        {
            int carry = 0;
            var sb = new StringBuilder();
            for (int i = num1.Length + num2.Length - 2; i >= 0; i--)
            {
                int current = carry;
                for (int j = num1.Length - 1; j >= 0; j--)
                {
                    int k = i - j;
                    if (k >= 0 && k <= num2.Length - 1)
                    {
                        current += int.Parse(num1.Substring(j, 1))*int.Parse(num2.Substring(k, 1));
                    }
                }
                carry = current/10;
                current %= 10;
                sb.Insert(0, current);
            }

            if (carry != 0)
            {
                sb.Insert(0, carry);
            }

            var ret = sb.ToString().TrimStart('0');
            return ret.Length == 0 ? "0" : ret;
        }
    }
}
