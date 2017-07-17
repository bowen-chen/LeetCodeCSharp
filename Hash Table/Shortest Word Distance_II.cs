/*
244	Shortest Word Distance II
easy
This is a follow up of Shortest Word Distance. The only difference is now you are given the list of words and your method will be called repeatedly many times with different parameters. How would you optimize it?

Design a class which receives a list of words in the constructor, and implements a method that takes two words word1 and word2 and return the shortest distance between these two words in the list.

For example,
Assume that words = ["practice", "makes", "perfect", "coding", "makes"].

Given word1 = "coding”, word2 = "practice”, return 3.
Given word1 = "makes", word2 = "coding", return 1.

Note:
You may assume that word1 does not equal to word2, and word1 and word2 are both in the list.
*/

using System;
using System.Collections.Generic;

namespace Demo
{
    public class WordDistance
    {
        private readonly Dictionary<string, List<int>> map = new Dictionary<string, List<int>>();

        public WordDistance(string[] words)
        {
            for (int i = 0; i < words.Length; i++)
            {
                if(map.ContainsKey(words[i]))
                {
                    map[words[i]] = new List<int>();
                }

                map[words[i]].Add(i);
            }
        }

        public int Shortest(string word1, string word2)
        {
            List<int> indexes1 = map[word1];
            List<int> indexes2 = map[word2];
            int i = 0, j = 0, dist =int.MaxValue;
            while (i < indexes1.Count && j < indexes2.Count)
            {
                dist = Math.Min(dist, Math.Abs(indexes1[i] - indexes2[j]));
                if (indexes1[i] < indexes2[j])
                {
                    i++;
                }
                else
                {
                    j++;
                }
            }

            return dist;
        }
 }
}
