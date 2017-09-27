/*
500. Keyboard Row
*
Given a List of words, return the words that can be typed using letters of alphabet on only one row's of American keyboard like the image below.

Example 1:

Input: ["Hello", "Alaska", "Dad", "Peace"]
Output: ["Alaska", "Dad"]
 

Note:

You may use one character in the keyboard more than once.
You may assume the input string will only contain letters of alphabet.
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public string[] FindWords(string[] words)
        {
            var res = new List<string>();
            var row1 = new HashSet<char>{ 'q','w','e','r','t','y','u','i','o','p'};
            var row2 = new HashSet<char> { 'a','s','d','f','g','h','j','k','l'};
            var row3 = new HashSet<char> { 'z','x','c','v','b','n','m'};
            foreach (string word in words)
            {
                int one = 0, two = 0, three = 0;
                foreach (char c in word)
                {
                    char d = char.ToLower(c);
                    if (row1.Contains(d))
                    {
                        one = 1;
                    }
                    else if (row2.Contains(d))
                    {
                        two = 1;
                    }
                    else if (row3.Contains(d))
                    {
                        three = 1;
                    }

                    if (one + two + three > 1)
                    {
                        break;
                    }
                }

                if (one + two + three == 1)
                {
                    res.Add(word);
                }
            }

            return res.ToArray();
        }
    }
}
