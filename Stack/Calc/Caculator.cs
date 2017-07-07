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
        private static readonly int[,] priority = {
            //    + -  *   /   (   )  #
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
                if (char.IsDigit(c))
                {
                    num = num ?? 0*10 + c - '0';
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
                            int a = values.Pop();
                            int b = values.Pop();
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
