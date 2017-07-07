/*
434. Number of Segments in a String
Count the number of segments in a string, where a segment is defined to be a contiguous sequence of non-space characters.

Please note that the string does not contain any non-printable characters.

Example:

Input: "Hello, my name is John"
Output: 5
*/

namespace Demo
{
    public partial class Solution
    {
        public int CountSegments2(string s)
        {
            int res = 0;
            for (int i = 0; i < s.Length; ++i)
            {
                if (s[i] != ' ' && (i == 0 || s[i - 1] == ' '))
                {
                    ++res;
                }
            }
            return res;
        }

        public int CountSegments(string s)
        {
            bool inword = false;
            int res = 0;
            foreach (var c in s)
            {
                if (inword && char.IsWhiteSpace(c))
                {
                    inword = false;
                }
                else if(!inword && !char.IsWhiteSpace(c))
                {
                    inword = true;
                    res++;
                }
            }
            return res;
        }
    }
}
