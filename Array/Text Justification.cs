/*
68	Text Justification
hard 
Given an array of words and a length L, format the text such that each line has exactly L characters and is fully (left and right) justified.

You should pack your words in a greedy approach; that is, pack as many words as you can in each line. Pad extra spaces ' ' when necessary so that each line has exactly L characters.

Extra spaces between words should be distributed as evenly as possible. If the number of spaces on a line do not divide evenly between words, the empty slots on the left will be assigned more spaces than the slots on the right.

For the last line of text, it should be left justified and no extra space is inserted between words.

For example,
words: ["This", "is", "an", "example", "of", "text", "justification."]
L: 16.

Return the formatted lines as:
[
   "This    is    an",
   "example  of text",
   "justification.  "
]
Note: Each word is guaranteed not to exceed L in length.

click to show corner cases.

Corner Cases:
A line other than the last line might contain only one word. What should you do in this case?
In this case, that line should be left-justified.
*/
using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public IList<string> FullJustify(string[] words, int maxWidth)
        {
            var res = new List<string>();
            int k = 0; // number of words in current line
            int l = 0; // lengh of current line
            for (int i = 0; i < words.Length; i += k)
            {
                for (k = 0, l = 0;
                    i + k < words.Length && l + words[i + k].Length <= maxWidth - k
                    /*each word need at least one space*/;
                    k++)
                {
                    l += words[i + k].Length;
                }

                string tmp = words[i];
                for (int j = 0; j < k - 1; j++)
                {
                    if (i + k >= words.Length)
                    {
                        tmp += " ";
                    }
                    else
                    {
                        tmp += new string(' ', (maxWidth - l)/(k - 1) + ((j < (maxWidth - l)%(k - 1)) ? 1 : 0));
                    }
                    tmp += words[i + j + 1];
                }

                tmp += new string(' ', maxWidth - tmp.Length);
                res.Add(tmp);
            }
            return res;
        }
    }
}
