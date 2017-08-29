/*
58	Length of Last Word
easy, *
Given a string s consists of upper/lower-case alphabets and empty space characters ' ', return the length of last word in the string.

If the last word does not exist, return 0.

Note: A word is defined as a character sequence consists of non-space characters only.

For example, 
 Given s = "Hello World",
 return 5.
*/

namespace Demo
{
    public partial class Solution
    {
        public int LengthOfLastWord(string s)
        {
            int last = 0;
            int res = 0;
            for (int i = 0; i <= s.Length; ++i)
            {
                if (i == s.Length || s[i] == ' ')
                {
                    if (i - last> 0)
                    {
                        res = i - last;
                    }

                    last = i+1;
                }
            }

            return res;
        }
    }
}
