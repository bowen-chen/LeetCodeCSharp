/*
616	Add Bold Tag in String
[LeetCode] Add Bold Tag in String
 

Given a string s and a list of strings dict, you need to add a closed pair of bold tag <b> and </b> to wrap the substrings in s that exist in dict. If two such substrings overlap, you need to wrap them together by only one pair of closed bold tag. Also, if two substrings wrapped by bold tags are consecutive, you need to combine them.

Example 1:

Input: 
s = "abcxyz123"
dict = ["abc","123"]
Output:
"<b>abc</b>xyz<b>123</b>"
 

Example 2:

Input: 
s = "aaabbcc"
dict = ["aaa","aab","bc"]
Output:
"<b>aaabbc</b>c"
 

Note:

The given dict won't contain duplicates, and its length won't exceed 100.
All the strings in input have length in range [1, 1000].
*/
using System.Text;

namespace Demo
{
    public partial class Solution
    {
        public string AddBoldTag(string s, string[] dict)
        {
            var bold = new bool[s.Length];
            foreach (string d in dict)
            {
                int index = s.IndexOf(d, 0);
                while (index != -1)
                {
                    for (int j = index; j < index + d.Length; j++)
                    {
                        bold[j] = true;
                    }

                    index = s.IndexOf(d, index + 1);
                }
            }

            var res = new StringBuilder();
            bool inbold = false;
            for (int i = 0; i < s.Length;i++)
            {
                if (bold[i]&& !inbold)
                {
                        res.Append("<b>");
                        inbold = true;
                }
                else if(!bold[i]&& inbold)
                {
                        res.Append("</b>");
                    inbold = false;
                }
                res.Append(s[i]);
            }

            if (inbold)
            {
                res.Append("</b>");
            }

            return res.ToString();
        }
    }
}
