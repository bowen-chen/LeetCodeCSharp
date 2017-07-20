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
    public partial class SolutionCalc2
    {
        public int Calculate(string s)
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
                    else if (sign == '+')
                    {
                        stack.Push(num);
                    }
                    else if (sign == '*')
                    {
                        stack.Push(stack.Pop()*num);
                    }
                    else if (sign == '/')
                    {
                        stack.Push(stack.Pop()/num);
                    }

                    sign = c;
                    num = 0;
                }
            }

            return stack.Sum();
        }

        private static readonly Dictionary<char, int> opsmap = new Dictionary<char, int>
        {
            { '+', 0},
            { '-', 1},
            { '*', 2},
            { '/', 3},
            { '#', 4}
        };

        // op1 number op2
        // if priority[op1, op2] = 1 then, op1 can be calculate
        // if priority[op1, op2] = -1 then, op1 cannot be calculated, stay in stack
        // if priority[op1, op2] = 0 then, op1 and op2 is a pair of noop, (2)
        // if priority[op1, op2] = 2 then, invalid input, )2(, (#, #)
        private static readonly int[,] priority = {
            //    +  -  *   /    #
            /*+*/{1, 1, -1, -1,  1},
            /*-*/{1, 1, -1, -1,  1},
            /***/{1, 1, 1, 1, 1},
            /*/*/{1, 1, 1, 1, 1},
            /*#*/{-1, -1, -1, -1, 0}
        };

        public int Calculate2(string s)
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
                                case '*':
                                    a *= b;
                                    break;
                                case '/':
                                    a /= b;
                                    break;
                            }

                            values.Push(a);
                            break;
                    }
                }
            }

            return values.Peek();
        }
    }
}
