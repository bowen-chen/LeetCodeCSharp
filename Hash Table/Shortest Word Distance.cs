/*
243	Shortest Word Distance
Given a list of words and two words word1 and word2, return the shortest distance between these two words in the list.

For example,
Assume that words = ["practice", "makes", "perfect", "coding", "makes"].

Given word1 = "coding", word2 = "practice", return 3.
Given word1 = "makes", word2 = "coding", return 1.

Note:
You may assume that word1 does not equal to word2, and word1 and word2 are both in the list.
*/
using System;

namespace Demo
{
    public partial class Solution
    {
        public int ShortestDistance(string[] words, string word1, string word2)
        {
            int p1 = -1, p2 = -1, min = int.MaxValue;

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == word1)
                {
                    p1 = i;
                    if (p1 != -1 && p2 != -1)
                    {
                        min = Math.Min(min, Math.Abs(p1 - p2));
                    }
                }
                else if (words[i] == word2)
                {
                    p2 = i;
                    if (p1 != -1 && p2 != -1)
                    {
                        min = Math.Min(min, Math.Abs(p1 - p2));
                    }
                }
            }

            return min;
        }
    }
}
