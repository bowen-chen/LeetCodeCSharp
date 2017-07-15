/*
214	Shortest Palindrome
revisit
Given a string S, you are allowed to convert it to a palindrome by adding characters in front of it. Find and return the shortest palindrome you can find by performing this transformation.

For example:

Given "aacecaaa", return "aaacecaaa".

Given "abcd", return "dcbabcd".
*/
using System.Linq;

namespace Demo
{
    public partial class Solution
    {
        public void Test_ShortestPalindrome()
        {
            ShortestPalindrome("ba");
        }

        public string ShortestPalindrome(string s)
        {
            if (s == "") { return s; }
            int maxi = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (IsPalindrome(s, 0, i))
                {
                    maxi = i;
                    break;
                }
            }

            if (maxi == s.Length - 1)
            {
                return s;
            }

            return new string(s.Substring(maxi + 1).Reverse().ToArray()) + s;
        }
    }
}
