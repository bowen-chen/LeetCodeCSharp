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
        public int CountSegments(string s)
        {
            int last = 0;
            int res = 0;
            for (int i = 0; i <= s.Length; ++i)
            {
                if (i == s.Length || s[i] == ' ')
                {
                    if (i - last > 0)
                    {
                        res++;
                    }

                    last = i + 1;
                }
            }

            return res;
        }
    }
}
