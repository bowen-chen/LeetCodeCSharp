/*
345. Reverse Vowels of a String

Write a function that takes a string as input and reverse only the vowels of a string.

Example 1:
Given s = "hello", return "holle".

Example 2:
Given s = "leetcode", return "leotcede".

Note:
The vowels does not include the letter "y".
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public string ReverseVowels(string s)
        {
            var h = new HashSet<char> { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            int low = 0;
            int high = s.Length - 1;
            char[] ch = s.ToCharArray();
            while (low < high)
            {
                while (!h.Contains(ch[low]) && low < high) low++;
                while (!h.Contains(ch[high]) && low < high) high--;
                if (low < high)
                {
                    var temp = ch[low];
                    ch[low] = ch[high];
                    ch[high] = temp;
                    high--;
                    low++;
                }
            }
            return new string(ch);
        }
    }
}
