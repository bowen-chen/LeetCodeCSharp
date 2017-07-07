/*
58	Length of Last Word
easy
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
            int res = 0;
            for (int i = 0; i < s.Length; ++i)
            {
                if (s[i] != ' ')
                {
                    if (i != 0 && s[i - 1] == ' ') res = 1;
                    else ++res;
                }
            }
            return res;
        }

        public int LengthOfLastWord2(string s)
        {
            bool inword = false;
            int last = 0;
            int current = 0;
            foreach (char c in s)
            {
                if (inword)
                {
                    if (c == ' ')
                    {
                        last = current;
                        inword = false;
                        current = 0;
                    }
                    else
                    {
                        current++;
                    }
                }
                else
                {
                    if (c != ' ')
                    {
                        inword = true;
                        current++;
                    }
                }
            }
            if (inword)
            {
                last = current;
            }
            return last;
        }

        public int LengthOfLastWord3(string s)
        {
            bool inword = false;
            int current = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                char c = s[i];
                if (inword)
                {
                    if (c == ' ')
                    {
                        return current;
                    }

                    current++;
                }
                else
                {
                    if (c != ' ')
                    {
                        inword = true;
                        current++;
                    }
                }
            }
            return current;
        }
    }
}
