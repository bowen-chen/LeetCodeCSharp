/*
679. 24 Game
You have 4 cards each containing a number from 1 to 9. You need to judge whether they could operated through *, /, +, -, (, ) to get the value of 24.

Example 1:
Input: [4, 1, 8, 7]
Output: True
Explanation: (8-4) * (7-1) = 24
Example 2:
Input: [1, 2, 1, 2]
Output: False
Note:
The division operator / represents real division, not integer division. For example, 4 / (1 - 2/3) = 12.
Every operation done is between two numbers. In particular, we cannot use - as a unary operator. For example, with [1, 1, 1, 1] as input, the expression -1 - 1 - 1 - 1 is not allowed.
You cannot concatenate numbers together. For example, if the input is [1, 2, 1, 2], we cannot write this as 12 + 12.
*/

using System;
using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        private const double eps = 0.001;

        public bool JudgePoint24(int[] nums)
        {
            return JudgePoint24(new double[] {nums[0], nums[1], nums[2], nums[3]});
        }

        private bool JudgePoint24(double[] a)
        {
            if (a.Length == 1)
            {
                return Math.Abs(a[0] -24) < eps;
            }

            for (int i = 0; i < a.Length; i++)
            {
                for (int j = i + 1; j < a.Length; j++)
                {
                    double[] b = new double[a.Length - 1];
                    for (int k = 0, l = 0; k < a.Length; k++)
                    {
                        if (k != i && k != j)
                        {
                            b[l++] = a[k];
                        }
                    }

                    foreach (double k in compute(a[i], a[j]))
                    {
                        b[a.Length - 2] = k;
                        if (JudgePoint24(b))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private IEnumerable<double> compute(double a, double b)
        {
            yield return a + b;
            yield return a - b;
            yield return b - a;
            yield return a * b;
            if (Math.Abs(b) >= eps)
            {
                yield return a / b;
            }
            if (Math.Abs(a) >= eps)
            {
                yield return b / a;
            }
        }
    }
}
