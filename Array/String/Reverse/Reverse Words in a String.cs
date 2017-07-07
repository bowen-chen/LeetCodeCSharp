/*
151	Reverse Words in a String
easy
Given an input string, reverse the string word by word.

For example,
Given s = "the sky is blue",
return "blue is sky the".

Clarification:
What constitutes a word?
A sequence of non-space characters constitutes a word.
Could the input string contain leading or trailing spaces?
Yes. However, your reversed string should not contain leading or trailing spaces.
How about multiple spaces between two words?
Reduce them to a single space in the reversed string.
*/

using System.Text;

namespace Demo
{
    public partial class Solution
    {
        public string ReverseWords(string s)
        {
            if (s == null)
            {
                return null;
            }
            StringBuilder input = new StringBuilder(s.Trim());
            int start = 0;
            bool inword = true;
            ReverseString(input, 0, input.Length - 1);
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (c != ' ')
                {
                    if (!inword)
                    {
                        start = i;
                        inword = true;
                    }
                }
                else
                {
                    if (inword)
                    {
                        ReverseString(input, start, i - 1);
                        inword = false;
                    }
                    else
                    {
                        input.Remove(i, 1);
                        i--;
                    }
                }
            }
            if (inword)
            {
                ReverseString(input, start, input.Length - 1);
            }
            return input.ToString();
        }

        public void ReverseString(StringBuilder str, int start, int end)
        {
            while (start < end)
            {
                char temp = str[start];
                str[start] = str[end];
                str[end] = temp;
                start++;
                end--;
            }
        }
    }
}
