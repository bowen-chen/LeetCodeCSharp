/*
186	Reverse Words in a String II
Given an input string, reverse the string word by word. A word is defined as a sequence of non-space characters.

The input string does not contain leading or trailing spaces and the words are always separated by a single space.

For example,
Given s = "the sky is blue",
return "blue is sky the".

Could you do it in-place without allocating extra space?
*/

namespace Demo
{
    public partial class Solution
    {
        // same as I or two pass as below
        public void ReverseWords(char[] s)
        {
            if (s.Length == 0)
            {
                return;
            }
            reverse(s, 0, s.Length - 1);
            int last = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ')
                {
                    reverse(s, last, i - 1);
                    last = i + 1;
                }
            }
        }

        public void reverse(char[] s, int l, int r)
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
