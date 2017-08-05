/*
186	Reverse Words in a String II
Given an input string, reverse the string word by word. A word is defined as a sequence of non-space characters.

The input string does not contain leading or trailing spaces and the words are always separated by a single space.

For example,
Given s = "the sky is blue",
return "blue is sky the".

Could you do it in-place without allocating extra space?
*/

using System;

namespace Demo
{
    public partial class Solution
    {
        // same as I or two pass as below
        public string ReverseWords2(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return s;
            }

            // compact
            var b = s.ToCharArray();
            int last = 0;
            for (int i = 0; i < b.Length; i++)
            {
                if (b[i] != ' ' || (i != 0 && b[i - 1] != ' '))
                {
                    b[last++] = b[i];
                }
            }

            if (last > 0 && b[last - 1] == ' ')
            {
                last--;
            }

            Array.Resize(ref b, last);
            Reverse(b, 0, b.Length - 1);

            last = 0;
            for (int i = 0; i <= b.Length; i++)
            {
                if (i== b.Length || b[i] == ' ')
                {
                    Reverse(b, last, i - 1);
                    last = i + 1;
                }
            }

            return new string(b);
        }

        public void Reverse(char[] s, int l, int r)
        {
            while (l <= r)
            {
                char temp = s[l];
                s[l] = s[r];
                s[r] = temp;
                l++;
                r--;
            }
        }
    }
}
