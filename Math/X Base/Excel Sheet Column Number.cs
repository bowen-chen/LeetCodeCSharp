/*
171	Excel Sheet Column Number
easy
Related to question Excel Sheet Column Title

Given a column title as appear in an Excel sheet, return its corresponding column number.

For example:

    A -> 1
    B -> 2
    C -> 3
    ...
    Z -> 26
    AA -> 27
    AB -> 28 
*/

namespace Demo
{
    public partial class Solution
    {
        public int TitleToNumber(string s)
        {
            // 26 based, start with 1
            // A0=Z
            int result = 0;
            foreach (char c in s)
            {
                result = result*26 + (c - 'A' + 1);
            }

            return result;
        }
    }
}
