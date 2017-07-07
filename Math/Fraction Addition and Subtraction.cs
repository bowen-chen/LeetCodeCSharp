/*
592. Fraction Addition and Subtraction
Given a string representing an expression of fraction addition and subtraction, you need to return the calculation result in string format. The final result should be irreducible fraction. If your final result is an integer, say 2, you need to change it to the format of fraction that has denominator 1. So in this case, 2 should be converted to 2/1.

Example 1:
Input:"-1/2+1/2"
Output: "0/1"
Example 2:
Input:"-1/2+1/2+1/3"
Output: "1/3"
Example 3:
Input:"1/3-1/2"
Output: "-1/6"
Example 4:
Input:"5/3+1/3"
Output: "2/1"
Note:
The input string only contains '0' to '9', '/', '+' and '-'. So does the output.
Each fraction (input and output) has format ±numerator/denominator. If the first input fraction or the output is positive, then '+' will be omitted.
The input only contains valid irreducible fractions, where the numerator and denominator of each fraction will always be in the range [1,10]. If the denominator is 1, it means this fraction is actually an integer in a fraction format defined above.
The number of given fractions will be in the range [1,10].
The numerator and denominator of the final result are guaranteed to be valid and in the range of 32-bit int.
*/
using System;

namespace Demo
{
    public partial class Solution
    {
        public string FractionAddition(string expression)
        {
            // init A/B as 0
            int A = 0, B = 1;

            int C = 0;
            int D = 0;
            int sign = 1;
            bool beforeSlash = true;
            for (int i=0; i< expression.Length;i++)
            {
                char c = expression[i];
                if (char.IsDigit(c))
                {
                    if (beforeSlash)
                    {
                        C = C*10 + (c - '0');
                    }
                    else
                    {
                        D = D*10 + (c - '0');
                    }
                }
                else
                {
                    if (c == '-')
                    {
                        sign = -1;
                    }
                    else if (c == '/')
                    {
                        beforeSlash = false;
                    }
                }

                if(!beforeSlash && (i+1==expression.Length || !char.IsDigit(expression[i+1])))
                {

                    C = sign * C;
                    A = A * D + C * B;
                    B *= D;
                    int g = Math.Abs(Gcd(A, B));
                    A /= g;
                    B /= g;
                    
                    C = 0;
                    D = 0;
                    sign = 1;
                    beforeSlash = true;
                }
            }
            return A + "/" + B;
        }

        private int Gcd(int a, int b)
        {
            return (b == 0) ? a : gcd(b, a % b);
        }
    }
}
