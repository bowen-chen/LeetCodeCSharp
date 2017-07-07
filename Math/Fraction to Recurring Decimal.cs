/*
166	Fraction to Recurring Decimal
medium, math
Given two integers representing the numerator and denominator of a fraction, return the fraction in string format.

If the fractional part is repeating, enclose the repeating part in parentheses.

For example,

Given numerator = 1, denominator = 2, return "0.5".
Given numerator = 2, denominator = 1, return "2".
Given numerator = 2, denominator = 3, return "0.(6)".
*/
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    public partial class Solution
    {
        public string FractionToDecimal(int numerator, int denominator)
        {
            if (numerator == 0)
            {
                return "0";
            }
            StringBuilder res = new StringBuilder();

            // "+" or "-"
            res.Append(((numerator > 0) ^ (denominator > 0)) ? "-" : "");
            long num = Math.Abs((long)numerator);
            long den = Math.Abs((long)denominator);

            // integral part
            res.Append(num / den);
            num %= den;
            if (num == 0)
            {
                return res.ToString();
            }

            // fractional part
            res.Append(".");
            // <reminder, index in the ret>
            var map = new Dictionary<long, int>();
            map.Add(num, res.Length);
            while (num != 0)
            {
                num *= 10;
                res.Append(num / den);
                num %= den;
                int index;
                if (map.TryGetValue(num, out index))
                {
                    res.Insert(index, "(");
                    res.Append(")");
                    break;
                }

                map.Add(num, res.Length);
            }
            return res.ToString();
        }
    }
}
