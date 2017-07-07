/*
344. Reverse String
string, easy
Write a function that takes a string as input and returns the string reversed.

Example:
Given s = "hello", return "olleh".
*/

namespace Demo
{
    public partial class Solution
    {
        public string ReverseString(string s)
        {
            char[] ch = s.ToCharArray();
            for (int i = 0; i < s.Length / 2; i++)
            {
                var temp = ch[s.Length - 1 - i];
                ch[s.Length - 1 - i] = ch[i];
                ch[i] = temp;
            }
            return new string(ch);
        }
    }
}
