/*
556. Next Greater Element III
hard, *
Given a positive 32-bit integer n, you need to find the smallest 32-bit integer which has exactly the same digits existing in the integer n and is greater in value than n. If no such positive 32-bit integer exists, you need to return -1.

Example 1:
Input: 12
Output: 21
Example 2:
Input: 21
Output: -1
*/

using System;
using System.Linq;

namespace Demo
{
    public partial class Solution
    {
        public int NextGreaterElement(int n)
        {
            var str = n.ToString().ToArray();
            int len = str.Length;

            //124321 ->131224

            // 1. from right to left, find the first nums[i] < nums[i+1], we need switch nums[i]
            //  str[i+1] to end is ordered as decending
            int i;
            for (i=len-2; i >= 0; --i)
            {
                if (str[i] < str[i + 1])
                {
                    break;
                }
            }

            if (i == -1)
            {
                return -1;
            }

            // 2. from right to left, find the first nums[j] > nums[i], swap nums[j] nums[i]
            for (int j = len - 1; j > i; --j)
            {
                if (str[j] > str[i])
                {
                    char t = str[j];
                    str[j] = str[i];
                    str[i] = t;
                    break;
                }
            }

            // 3. reverse i+1 to end
            Array.Reverse(str, i + 1, str.Length - i);
            long res = long.Parse(new string(str));
            return res > int.MaxValue ? -1 : (int)res;
        }
    }
}
