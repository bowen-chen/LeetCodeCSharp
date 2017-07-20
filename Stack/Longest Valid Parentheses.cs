/*
32	Longest Valid Parentheses
easy
Given a string containing just the characters '(' and ')', find the length of the longest valid (well-formed) parentheses substring.

For "(()", the longest valid parentheses substring is "()", which has length = 2.

Another example is ")()())", where the longest valid parentheses substring is "()()", which has length = 4.
*/
using System;
using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public void Test_LongestValidParentheses()
        {
            LongestValidParentheses("()");
        }

        public int LongestValidParentheses(string s)
        {
            int res = 0;
            int start = 0;
            var st = new Stack<int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    st.Push(i);
                }
                else
                {
                    if (st.Count == 0)
                    {
                        start = i + 1;
                    }
                    else
                    {
                        st.Pop();
                        res = st.Count ==0 ? Math.Max(res, i - start + 1) : Math.Max(res, i - st.Peek());
                    }
                }
            }

            return res;
        }
    }
}
