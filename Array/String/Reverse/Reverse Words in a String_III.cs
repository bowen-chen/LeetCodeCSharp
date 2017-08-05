/*
557. Reverse Words in a String III
Given a string, you need to reverse the order of characters in each word within a sentence while still preserving whitespace and initial word order.

Example 1:
Input: "Let's take LeetCode contest"
Output: "s'teL ekat edoCteeL tsetnoc"
Note: In the string, each word is separated by single space and there will not be any extra space in the string.
*/

namespace Demo
{
    public partial class Solution
    {
        public string ReverseWords3(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return s;
            }

            var c = s.ToCharArray();
            int last = 0;
            for (int i = 0; i <= c.Length; i++)
            {
                if (i == c.Length || c[i] == ' ')
                {
                    Reverse3(c, last, i - 1);
                    last = i + 1;
                }
            }

            return new string(c);
        }

        private void Reverse3(char[] s, int l, int r)
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
