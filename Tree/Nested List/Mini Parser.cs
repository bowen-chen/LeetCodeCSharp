/*
385	Mini Parser
medium, *
Given a nested list of integers represented as a string, implement a parser to deserialize it.

Each element is either an integer, or a list -- whose elements may also be integers or other lists.

Note: You may assume that the string is well-formed:

String is non-empty.
String does not contain white spaces.
String contains only digits 0-9, [, - ,, ].
Example 1:

Given s = "324",

You should return a NestedInteger object which contains a single integer 324.
Example 2:

Given s = "[123,[456,[789]]]",

Return a NestedInteger object containing a nested list with 2 elements:

1. An integer containing value 123.
2. A nested list containing two elements:
    i.  An integer containing value 456.
    ii. A nested list with one element:
         a. An integer containing value 789.
*/

using System;
using System.Diagnostics;

namespace Demo
{
    /**
 * // This is the interface that allows for creating nested lists.
 * // You should not implement it, or speculate about its implementation
 * interface NestedInteger {
 *
 *     // Constructor initializes an empty nested list.
 *     public NestedInteger();
 *
 *     // Constructor initializes a single integer.
 *     public NestedInteger(int value);
 *
 *     // @return true if this NestedInteger holds a single integer, rather than a nested list.
 *     bool IsInteger();
 *
 *     // @return the single integer that this NestedInteger holds, if it holds a single integer
 *     // Return null if this NestedInteger holds a nested list
 *     int GetInteger();
 *
 *     // Set this NestedInteger to hold a single integer.
 *     public void SetInteger(int value);
 *
 *     // Set this NestedInteger to hold a nested list and adds a nested integer to it.
 *     public void Add(NestedInteger ni);
 *
 *     // @return the nested list that this NestedInteger holds, if it holds a nested list
 *     // Return null if this NestedInteger holds a single integer
 *     IList<NestedInteger> GetList();
 * }
 */
    public partial class Solution
    {
        public NestedInteger Deserialize3(string s)
        {
            int index = 0;
            NestedInteger ret;
            char c = s[index];
            if (c == '[')
            {
                ret = ParseList(s, ref index);
            }
            else if(('0' <= c && c <= '9') || c=='-')
            {
                // starts with 0-9, '-'
                ret = ParseNumber(s, ref index);
            }
            else
            {
                throw new FormatException();
            }

            if (index != s.Length)
            {

                throw new FormatException();
            }

            return ret;
        }

        private NestedInteger ParseList(string s, ref int index)
        {
            Debug.Assert(s[index] == '[');
            index++; // eat '['
            NestedInteger root = new NestedInteger();
            while (index < s.Length)
            {
                char c = s[index];
                if (c == '[')
                {
                    root.Add(ParseList(s, ref index));
                }
                else if (('0' <= c && c <= '9') || c == '-')
                {
                    root.Add(ParseNumber(s, ref index));
                }
                else if (c == ',')
                {
                    // skip
                    index++;
                }
                else if (c == ']')
                {
                    break;
                }
                else
                {
                    throw new Exception();
                }
            }

            Debug.Assert(s[index] == ']');
            index++; // eat ']'
            return root;
        }

        private NestedInteger ParseNumber(string s, ref int index)
        {
            int n = 0;
            int positive = 1;  // flag for positive number
            if (s[index] == '-')
            {
                positive = -1;
                index ++;
            }

            while (index < s.Length)
            {
                char c = s[index];
                if ('0' <= c && c <= '9')
                {
                    n = 10 * n + c - '0';
                    index++;
                }
                else
                {
                    break;
                }
            }

            return new NestedInteger(n * positive);
        }
    }
}
