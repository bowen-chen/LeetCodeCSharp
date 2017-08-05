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
            for (int low = 0, high = s.Length - 1; low < high; low++, high--)
            {
                var temp = ch[low];
                ch[low] = ch[high];
                ch[high] = temp;
            }

            return new string(ch);
        }
    }
}
