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

        public int LongestValidParentheses2(string s)
        {
            int n = s.Length;
            int longest = 0;
            var st = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                if (s[i] == '(')
                {
                    st.Push(i);
                }
                else
                {
                    if (st.Count != 0 && s[st.Peek()] == '(')
                    {
                        st.Pop();
                    }
                    else
                    {
                        st.Push(i);
                    }
                }
            }

            if (st.Count == 0)
            {
                longest = n;
            }
            else
            {
                int a = n;
                while (st.Count != 0)
                {
                    int b = st.Peek();
                    st.Pop();
                    longest = Math.Max(longest, a - b - 1);
                    a = b;
                }
                longest = Math.Max(longest, a);
            }
            return longest;
        }
    }
}
