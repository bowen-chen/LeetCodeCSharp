using System;
using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public void Test_Calculate()
        {
            Console.WriteLine("{0}={1}", "1+2*2", Calculate3("1+2*2"));
            Console.WriteLine("{0}={1}", "1+2*2+3*(1+4)", Calculate3("1+2*2+3*(1+4)"));
        }

        private static readonly Dictionary<char, int> opsmap = new Dictionary<char, int>
        {
            { '+', 0},
            { '-', 1},
            { '*', 2},
            { '/', 3},
            { '(', 4},
            { ')', 5},
            { '#', 6}
        };

        // op1 number op2
        // if priority[op1, op2] = 1 then, op1 can be calculate
        // if priority[op1, op2] = -1 then, op1 cannot be calculated, stay in stack
        // if priority[op1, op2] = 0 then, op1 and op2 is a pair of noop, (2)
        // if priority[op1, op2] = 2 then, invalid input, )2(, (#, #)
        private static readonly int[,] priority = {
            //    +  -  *  /   (   )  #
            /*+*/{1, 1, -1, -1, -1, 1, 1},
            /*-*/{1, 1, -1, -1, -1, 1, 1},
            /***/{1, 1, 1, 1, -1, 1, 1},
            /*/*/{1, 1, 1, 1, -1, 1, 1},
            /*(*/{-1, -1, -1, -1, -1, 0, 2},
            /*)*/{1, 1, 1, 1, 2, 1, 1},
            /*#*/{-1, -1, -1, -1, -1, 2, 0}
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
                                case '*':
                                    a *= b;
                                    break;
                                case '/':
                                    a /= b;
                                    break;
                            }

                            values.Push(a);
                            // don't move i in this case, to continue process the ops in task with c

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
