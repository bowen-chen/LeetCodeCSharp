/*
394. Decode String
*
Given an encoded string, return it's decoded string.

The encoding rule is: k[encoded_string], where the encoded_string inside the square brackets is being repeated exactly k times. Note that k is guaranteed to be a positive integer.

You may assume that the input string is always valid; No extra white spaces, square brackets are well-formed, etc.

Furthermore, you may assume that the original data does not contain any digits and that digits are only for those repeat numbers, k. For example, there won't be input like 3a or 2[4].

Examples:

s = "3[a]2[bc]", return "aaabcbc".
s = "3[a2[c]]", return "accaccacc".
s = "2[abc]3[cd]ef", return "abcabccdcdcdef".
*/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Demo
{
    public partial class Solution
    {
        public string DecodeString2(string s)
        {
            string res = "";
            var stack = new Stack<Tuple<string, int>>();
            int idx = 0;
            while (idx < s.Length)
            {
                if (char.IsDigit(s[idx]))
                {
                    int count = 0;
                    while (char.IsDigit(s[idx]))
                    {
                        count = 10 * count + (s[idx] - '0');
                        idx++;
                    }

                    Debug.Assert(s[idx] == '[');
                    stack.Push(Tuple.Create(res, count));
                    res = "";
                    idx++;
                }
                else if (s[idx] == ']')
                {
                    Debug.Assert(stack.Count > 0);
                    var temp = stack.Pop();
                    res = temp.Item1 + string.Concat(Enumerable.Repeat(res, temp.Item2));
                    idx++;
                }
                else
                {
                    Debug.Assert(s[idx] != '[');
                    res += s[idx++];
                }
            }


            Debug.Assert(stack.Count == 0);
            return res;
        }
    }
}
