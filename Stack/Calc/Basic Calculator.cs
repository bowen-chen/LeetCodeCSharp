/*
224	Basic Calculator
medium, calculate
Basic Calculator

Implement a basic calculator to evaluate a simple expression string.

The expression string may contain open ( and closing parentheses ), the plus + or minus sign -, non-negative integers and empty spaces .

You may assume that the given expression is always valid.

Some examples:
"1 + 1" = 2
" 2-1 + 2 " = 3
"(1+(4+5+2)-3)+(6+8)" = 23
Note: Do not use the eval built-in library function.
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public int Calculate(string s)
        {
            Stack<int> stack = new Stack<int>();
            int result = 0;
            int number = 0;
            int sign = 1;
            foreach (var c in s)
            {
                if (char.IsDigit(c))
                {
                    number = 10 * number + (c - '0');
                }
                else if (c == '+')
                {
                    result += sign * number;
                    number = 0;
                    sign = 1;
                }
                else if (c == '-')
                {
                    result += sign * number;
                    number = 0;
                    sign = -1;
                }
                else if (c == '(')
                {
                    //we push the result first, then sign;
                    stack.Push(result);
                    stack.Push(sign);
                    //reset the sign and result for the value in the parenthesis
                    sign = 1;
                    result = 0;
                }
                else if (c == ')')
                {
                    result += sign * number;
                    number = 0;
                    result *= stack.Pop();    //stack.pop() is the sign before the parenthesis
                    result += stack.Pop();   //stack.pop() now is the result calculated before the parenthesis

                }
            }

            if (number != 0)
            {
                result += sign * number;
            }

            return result;
        }
    }
}
