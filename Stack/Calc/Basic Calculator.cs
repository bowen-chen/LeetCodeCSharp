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
    public partial class SolutionCalc
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

        private static readonly Dictionary<char, int> opsmap = new Dictionary<char, int>
        {
            { '+', 0},
            { '-', 1},
            { '(', 2},
            { ')', 3},
            { '#', 4}
        };

        // op1 number op2
        // if priority[op1, op2] = 1 then, op1 can be calculate
        // if priority[op1, op2] = -1 then, op1 cannot be calculated, stay in stack
        // if priority[op1, op2] = 0 then, op1 and op2 is a pair of noop, (2)
        // if priority[op1, op2] = 2 then, invalid input, )2(, (#, #)
        private static readonly int[,] priority = {
            //    +  -  (   )  #
            /*+*/{1, 1, -1, 1, 1},
            /*-*/{1, 1, -1, 1, 1},
            /*(*/{-1, -1, -1, 0, 2},
            /*)*/{1, 1, 2, 1, 1},
            /*#*/{-1, -1, -1, 2, 0}
        };

        public int Calculate3(string s)
        {
            var ops = new Stack<char>();
            ops.Push('#');
            var values = new Stack<int>();
            int? num = null;
            int i = 0;
            while (i < s.Length || ops.Peek() != '#')
            {
                var c = i < s.Length ? s[i] : '#';
                if (c == ' ')
                {
                    i++;
                    continue;
                }

                if (char.IsDigit(c))
                {
                    num = (num ?? 0) * 10 + (c - '0');
                    i++;
                }
                else
                {
                    if (num != null)
                    {
                        values.Push(num.Value);
                        num = null;
                    }

                    switch (priority[opsmap[ops.Peek()], opsmap[c]])
                    {
                        case -1:
                            ops.Push(c);
                            i++;
                            break;
                        case 0:
                            ops.Pop();
                            i++;
                            break;
                        case 1:
                            int b = values.Pop();
                            int a = values.Pop();
                            char op = ops.Pop();
                            switch (op)
                            {
                                case '-':
                                    a -= b;
                                    break;
                                case '+':
                                    a += b;
                                    break;
                            }

                            values.Push(a);
                            break;
                    }
                }
            }

            // "123" int only
            if (num != null)
            {
                return num.Value;
            }

            return values.Peek();
        }
    }
}
