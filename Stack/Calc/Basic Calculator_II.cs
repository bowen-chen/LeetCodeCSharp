/*
227	Basic Calculator II
medium
Basic Calculator II

Implement a basic calculator to evaluate a simple expression string.

The expression string contains only non-negative integers, +, -, *, / operators and empty spaces . The integer division should truncate toward zero.

You may assume that the given expression is always valid.

Some examples:
"3+2*2" = 7
" 3/2 " = 1
" 3+5 / 2 " = 5
Note: Do not use the eval built-in library function.
*/

using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    public partial class Solution
    {
        public int Calculate2(string s)
        {
            int len;
            if (s == null || (len = s.Length) == 0) return 0;
            Stack<int> stack = new Stack<int>();
            int num = 0;
            char sign = '+';
            for (int i = 0; i < len; i++)
            {
                var c = s[i];
                if (char.IsDigit(c))
                {
                    num = num*10 + c - '0';
                }
                if ((!char.IsDigit(c) && ' ' != c) || i == len - 1)
                {
                    if (sign == '-')
                    {
                        stack.Push(-num);
                    }
                    if (sign == '+')
                    {
                        stack.Push(num);
                    }
                    if (sign == '*')
                    {
                        stack.Push(stack.Pop()*num);
                    }
                    if (sign == '/')
                    {
                        stack.Push(stack.Pop()/num);
                    }
                    sign = c;
                    num = 0;
                }
            }

            return stack.Sum();
        }
    }
}
