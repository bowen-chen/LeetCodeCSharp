/*
125	Valid Palindrome
easy
Given a string, determine if it is a palindrome, considering only alphanumeric characters and ignoring cases.

For example,
"A man, a plan, a canal: Panama" is a palindrome.
"race a car" is not a palindrome.

Note:
Have you consider that the string might be empty? This is a good question to ask during an interview.

For the purpose of this problem, we define empty string as valid palindrome.
*/
namespace Demo
{
    public partial class Solution
    {
        public bool IsPalindromeString(string s)
        {
            int i = 0;
            int j = s.Length - 1;
            s = s.ToLower();
            while (i < j)
            {
                while (i < j && !char.IsLetterOrDigit(s[i]))
                {
                    i++;
                }
                while (i < j && !char.IsLetterOrDigit(s[j]))
                {
                    j--;
                }
                if (i < j && s[i] != s[j])
                {
                    return false;
                }
                i++;
                j--;
            }
            return true;
        }
    }
}
