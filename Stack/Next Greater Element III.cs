/*
556. Next Greater Element III
hard
Given a positive 32-bit integer n, you need to find the smallest 32-bit integer which has exactly the same digits existing in the integer n and is greater in value than n. If no such positive 32-bit integer exists, you need to return -1.

Example 1:
Input: 12
Output: 21
Example 2:
Input: 21
Output: -1
*/

using System.Linq;

namespace Demo
{
    public partial class Solution
    {
        public int NextGreaterElement(int n)
        {
            var str = n.ToString().ToArray();
            int len = str.Length;
            int i;
            for (i=len-1; i > 0; --i)
            {
                if (str[i] > str[i - 1])
                {
                    break;
                }
            }

            if (i == 0)
            {
                return -1;
            }

            // str[i-1] is the first number less than str[i] from right
            // and str[i] to str[len-1] is sorted decending
            for (int j = len - 1; j >= i; --j)
            {
                if (str[j] > str[i - 1])
                {
                    char t = str[j];
                    str[j] = str[i - 1];
                    str[i-1] = t;
                    break;
                }
            }

            System.Array.Sort(str, i, str.Length - i);
            long res = long.Parse(new string(str));
            return res > int.MaxValue ? -1 : (int)res;
        }
    }
}
