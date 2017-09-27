/*
504 Base 7
*
Given an integer, return its base 7 string representation.

Example 1:
Input: 100
Output: "202"
Example 2:
Input: -7
Output: "-10"
Note: The input will be in range of [-1e7, 1e7].   
*/

namespace Demo
{
    public partial class Solution
    {
        public string ConvertToBase7(int num)
        {
            if (num == 0) return "0";
            string res = "";
            bool positive = num > 0;
            if (!positive)
            {
                num = -num;
            }

            while (num != 0)
            {
                res = (num % 7) + res;
                num /= 7;
            }
            return positive ? res : "-" + res;
        }
    }
}
