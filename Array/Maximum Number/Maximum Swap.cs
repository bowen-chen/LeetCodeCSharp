/*
670. Maximum Swap
Given a non-negative integer, you could swap two digits at most once to get the maximum valued number. Return the maximum valued number you could get.

Example 1:
Input: 2736
Output: 7236
Explanation: Swap the number 2 and the number 7.
Example 2:
Input: 9973
Output: 9973
Explanation: No swap.
Note:
The given number is in the range [0, 108]
*/

using System;
using System.Linq;

namespace Demo
{
    public partial class Solution
    {
        public int MaximumSwap(int num)
        {
            var s = num.ToString().ToArray();
            var max = new int[s.Length];
            var m = s[s.Length - 1];
            for (int i = s.Length - 1; i >= 0; i--)
            {
                max[i] = Math.Max(s[i], m);
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (max[i] != s[i])
                {
                    for (int j = s.Length - 1; j > i; j--)
                    {
                        if (s[j] == max[i])
                        {
                            var t = s[i];
                            s[i] = s[j];
                            s[j] = t;
                            return int.Parse(new string(s));
                        }
                    }
                }
            }

            return num;
        }
    }
}
