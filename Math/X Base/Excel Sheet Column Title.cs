/*
168	Excel Sheet Column Title
easy
Given a positive integer, return its corresponding column title as appear in an Excel sheet.

For example:

    1 -> A
    2 -> B
    3 -> C
    ...
    26 -> Z
    27 -> AA
    28 -> AB 
*/

using System;
using System.Text;

namespace Demo
{
    public partial class Solution
    {
        public void Test_ConvertToTitle()
        {
            for (int i = 1; i < 100; i++)
            {
                Console.WriteLine(ConvertToTitle(i));
            }
        }

        public string ConvertToTitle(int n)
        {
            StringBuilder sb = new StringBuilder();
            while (n > 0)
            {
                //a*26*26+b*26+c
                n--;
                sb.Insert(0, (char)('A' + n%26));
                n = n/26;
            }

            return sb.ToString();
        }
    }
}
