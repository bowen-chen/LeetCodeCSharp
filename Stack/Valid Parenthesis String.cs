/*
678. Valid Parenthesis String
Given a string containing only three types of characters: '(', ')' and '*', write a function to check whether this string is valid. We define the validity of a string by these rules:

Any left parenthesis '(' must have a corresponding right parenthesis ')'.
Any right parenthesis ')' must have a corresponding left parenthesis '('.
Left parenthesis '(' must go before the corresponding right parenthesis ')'.
'*' could be treated as a single right parenthesis ')' or a single left parenthesis '(' or an empty string.
An empty string is also valid.
Example 1:
Input: "()"
Output: True
Example 2:
Input: "(*)"
Output: True
Example 3:
Input: "(*))"
Output: True
Note:
The string size will be in the range [1, 100].
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public bool CheckValidString(string s)
        {
            var left = new Stack<int>();
            var star = new Stack<int>();
            for (int i = 0; i < s.Length; ++i)
            {
                if (s[i] == '*')
                {
                    star.Push(i);
                }
                else if (s[i] == '(')
                {
                    left.Push(i);
                }
                else
                {
                    if (left.Count == 0 && star.Count == 0)
                    {
                        return false;
                    }
                    if (left.Count > 0)
                    {
                        left.Pop();
                    }
                    else
                    {
                        star.Pop();
                    }
                }
            }
            while (left.Count != 0 && star.Count != 0)
            {
                if (left.Peek() > star.Peek())
                {
                    return false;
                }
                left.Pop();
                star.Pop();
            }
            return left.Count == 0;
        }

        public bool checkValidString(string s)
        {
            int low = 0; /*min count of (*/
            int high = 0; /*max count of (*/
            foreach (char c in s)
            {
                if (c == '(')
                {
                    ++low;
                    ++high;
                }
                else if (c == ')')
                {
                    if (low > 0)
                    {
                        --low;
                    }

                    --high;
                }
                else
                {
                    if (low > 0)
                    {
                        --low;
                    }

                    ++high;
                }

                if (high < 0)
                {
                    return false;
                }
            }

            return low == 0;
        }
    }
}
