/*
43	Multiply Strings
easy, math, *
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
            var ret = new int[num1.Length + num2.Length];
            for (int i = num1.Length - 1; i >= 0; i--)
            {
                for (int j = num2.Length - 1; j >= 0; j--)
                {
                    ret[i + j + 1] += (num1[i] - '0')*(num2[j] - '0');
                }
            }


            for (int i = ret.Length - 1; i > 0; i--)
            {
                if (ret[i] >= 10)
                {
                    ret[i - 1] += ret[i]/10;
                    ret[i] %= 10;
                }
            }

            var sb = new StringBuilder();
            for (int i = 0; i < ret.Length; i++)
            {
                sb.Append(ret[i].ToString());
            }

            var s = sb.ToString().TrimStart('0');
            return string.IsNullOrEmpty(s) ? "0" : s;
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
