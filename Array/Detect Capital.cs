/*
520. Detect Capital
Given a word, you need to judge whether the usage of capitals in it is right or not.

We define the usage of capitals in a word to be right when one of the following cases holds:

All letters in this word are capitals, like "USA".
All letters in this word are not capitals, like "leetcode".
Only the first letter in this word is capital if it has more than one letter, like "Google".
Otherwise, we define that this word doesn't use capitals in a right way.
Example 1:
Input: "USA"
Output: True
Example 2:
Input: "FlaG"
Output: False
*/

namespace Demo
{
    public partial class Solution
    {
        public bool DetectCapitalUse(string word)
        {
            int cnt = 0;
            foreach (var c in word)
            {
                if (c <= 'Z')
                {
                    ++cnt;
                }
            }
            return cnt == 0 || cnt == word.Length || (cnt == 1 && word[0] <= 'Z');
        }
    }
}
