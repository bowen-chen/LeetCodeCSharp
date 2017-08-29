/*
127	Word Ladder
easy, bfs, *
Word Ladder
Given two words (beginWord and endWord), and a dictionary's word list,
find the length of shortest transformation sequence from beginWord to endWord, such that:

Only one letter can be changed at a time
Each intermediate word must exist in the word list
For example,

Given:
beginWord = "hit"
endWord = "cog"
wordList = ["hot","dot","dog","lot","log","cog"]
As one shortest transformation is "hit" -> "hot" -> "dot" -> "dog" -> "cog",
return its length 5.

Note:
Return 0 if there is no such transformation sequence.
All words have the same length.
All words contain only lowercase alphabetic characters.
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            var wordDic = new HashSet<string>(wordList);
            wordList.Add(endWord);
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(beginWord);
            queue.Enqueue(null);
            int level = 1;
            while (queue.Count > 0)
            {
                string n = queue.Dequeue();
                if (n == null)
                {
                    level++;
                    if (queue.Count > 0)
                    {
                        queue.Enqueue(null);
                    }
                }
                else
                {
                    foreach (string s in FindChild(n, wordDic))
                    {
                        wordDic.Remove(s);
                        if (s == endWord)
                        {
                            return level+1;
                        }

                        queue.Enqueue(s);
                    }
                }
            }

            return 0;
        }

        private List<string> FindChild(string n, ISet<string> dict)
        {
            List<string> ret = new List<string>();
            char[] wordChar = n.ToCharArray();
            for (int i = 0; i < n.Length; i++)
            {
                char saved = wordChar[i];
                for (char c = 'a'; c <= 'z'; c++)
                {
                    wordChar[i] = c;
                    string str = new string(wordChar);
                    if (dict.Contains(str))
                    {
                        ret.Add(str);
                    }
                }

                wordChar[i] = saved;
            }

            return ret;
        }
    }
}
