/*
6	ZigZag Conversion
easy
The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this: (you may want to display this pattern in a fixed font for better legibility)

P   A   H   N
A P L S I I G
Y   I   R
And then read line by line: "PAHNAPLSIIGYIR"
Write the code that will take a string and make this conversion given a number of rows:

string convert(string text, int nRows);
convert("PAYPALISHIRING", 3) should return "PAHNAPLSIIGYIR".
*/
using System.Text;

namespace Demo
{
    public partial class Solution
    {
        public string Convert(string s, int numRows)
        {
            int len = s.Length;
            var sb = new StringBuilder[numRows];
            for (int j = 0; j < sb.Length; j++)
            {
                sb[j] = new StringBuilder();
            }

            int i = 0;
            while (i < len)
            {
                for (int idx = 0; idx < numRows && i < len; idx++) // vertically down [0->numRows-1]
                {
                    sb[idx].Append(s[i++]);
                }

                for (int idx = numRows - 2; idx >= 1 && i < len; idx--) // obliquely up, [numRows-2, 1]
                {
                    sb[idx].Append(s[i++]);
                }
            }

            for (int idx = 1; idx < sb.Length; idx++)
            {
                sb[0].Append(sb[idx]);
            }

            return sb[0].ToString();
        }
    }
}
