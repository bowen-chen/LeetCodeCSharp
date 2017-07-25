/*
633. Sum of Square Numbers
Given a non-negative integer c, your task is to decide whether there're two integers a and b such that a2 + b2 = c.

Example 1:
Input: 5
Output: True
Explanation: 1 * 1 + 2 * 2 = 5
Example 2:
Input: 3
Output: False
*/

using System;

namespace Demo
{
    public partial class Solution
    {
        public bool JudgeSquareSum(int c)
        {
            int a = 0, b = (int)Math.Sqrt(c);
            while (a <= b)
            {
                if (a*a + b*b == c)
                {
                    return true;
                }

                if (a*a + b*b < c)
                {
                    ++a;
                }
                else
                {
                    --b;
                }
            }

            return false;
        }
    }
}
