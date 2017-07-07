/*
22	Generate Parentheses
easy, recursive
Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.

For example, given n = 3, a solution set is:

"((()))", "(()())", "(())()", "()(())", "()()()"
*/
using System;
using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public void Test_GenerateParenthesis()
        {
            foreach (var s in GenerateParenthesis(3)) {
                Console.WriteLine(s);
            }
        }
        public IList<string> GenerateParenthesis(int n)
        {
            var ret = new List<string>();
            GenerateParenthesis(ret, 0, n, "");
            return ret;
        }

        private void GenerateParenthesis(List<string> ret, int c, int n, string current)
        {
            if (n == 0 && c == 0)
            {
                ret.Add(current);
                return;
            }

            if (c == 0)
            {
                GenerateParenthesis(ret, c + 1, n - 1, current + "(");
            }
            else
            {
                if (n > 0)
                {
                    GenerateParenthesis(ret, c + 1, n - 1, current + "(");
                }

                GenerateParenthesis(ret, c - 1, n, current + ")");
            }
        }
    }
}
