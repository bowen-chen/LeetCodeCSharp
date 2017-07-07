/*
126	Word Ladder II
medium, bfs
Word Ladder II

Given two words (beginWord and endWordWord), and a dictionary's word list, find all shortest transformation sequence(s) from beginWord to endWordWord, such that:

Only one letter can be changed at a time
Each intermediate word must exist in the word list
For example,

Given:
beginWord = "hit"
endWordWord = "cog"
wordList = ["hot","dot","dog","lot","log"]
Return
  [
    ["hit","hot","dot","dog","cog"],
    ["hit","hot","lot","log","cog"]
  ]
Note:
All words have the same length.
All words contain only lowercase alphabetic characters.
*/

using System.Collections.Generic;

namespace Demo
{
     public partial class Solution
    {
        public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
        {
            var wordDic = new HashSet<string>(wordList);
            var ret = new List<IList<string>>();
            var queue = new Queue<IList<string>> ();
            queue.Enqueue(new List<string> { beginWord });
            var wordinlevel = new HashSet<string> { beginWord };
            queue.Enqueue(null);
            while (queue.Count > 0)
            {
                var path = queue.Dequeue();
                if (path == null)
                {
                    if (ret.Count >0)
                    {
                        break;
                    }

                    if (queue.Count > 0)
                    {
                        queue.Enqueue(null);
                        foreach (var word in wordinlevel)
                        {
                            wordDic.Remove(word);
                        }
                        wordinlevel.Clear();
                    }
                }
                else
                {
                    string word = path[path.Count - 1];
                    foreach (string child in FindChild(word, wordDic))
                    {
                        wordinlevel.Add(child);
                        var newpath = new List<string>(path);
                        newpath.Add(child);
                        if (child.Equals(endWord))
                        {
                            ret.Add(newpath);
                            break;
                        }
                        else
                        {
                            queue.Enqueue(newpath);
                        }
                    }
                }
            }
            return ret;
        }
    };
}
