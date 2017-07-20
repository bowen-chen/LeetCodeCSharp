/*
20. Valid Parentheses
easy, stack
Valid Parentheses

Given a string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

The brackets must close in the correct order, "()" and "()[]{}" are all valid but "(]" and "([)]" are not.
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public bool IsValid(string s)
        {
            Stack<char> stack = new Stack<char>();
            foreach (char c in s)
            {
                if (c == '(' || c == '[' || c == '{')
                {
                    stack.Push(c);
                }
                else if (c == ')')
                {
                    if (stack.Count == 0 || stack.Pop() != '(')
                    {
                        return false;
                    }
                }
                else if (c == ']')
                {
                    if (stack.Count == 0 || stack.Pop() != '[')
                    {
                        return false;
                    }
                }
                else if (c == '}')
                {
                    if (stack.Count == 0 || stack.Pop() != '{')
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return stack.Count == 0;
        }
    }
}
