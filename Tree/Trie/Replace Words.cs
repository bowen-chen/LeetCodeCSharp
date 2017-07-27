/*
648. Replace Words
In English, we have a concept called root, which can be followed by some other words to form another longer word - let's call this word successor. For example, the root an, followed by other, which can form another word another.

Now, given a dictionary consisting of many roots and a sentence. You need to replace all the successor in the sentence with the root forming it. If a successor has many roots can form it, replace it with the root with the shortest length.

You need to output the sentence after the replacement.

Example 1:
Input: dict = ["cat", "bat", "rat"]
sentence = "the cattle was rattled by the battery"
Output: "the cat was rat by the bat"
Note:
The input will only have lower-case letters.
1 <= dict words number <= 1000
1 <= sentence words number <= 1000
1 <= root length <= 100
1 <= sentence words length <= 1000
*/

using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    public class ReplaceWords2
    {
        public string ReplaceWords(IList<string> dict, string sentence)
        {
            var root = new TrieNode();
            foreach (var w in dict)
            {
                root.Insert(w);
            }

            return string.Join(" ", sentence.Split(' ').Select(w => root.Search(w)));
        }

        private class TrieNode
        {
            private readonly TrieNode[] children = new TrieNode[26];
            private bool isWord = false;

            public void Insert(string word)
            {
                var cur = this;
                foreach (var c in word)
                {
                    if (cur.children[c - 'a'] == null)
                    {
                        cur.children[c-'a'] = new TrieNode();
                    }

                    cur = cur.children[c - 'a'];
                }

                cur.isWord = true;
            }

            public string Search(string word)
            {
                var cur = this;
                for (int i = 0; i < word.Length; i++)
                {
                    var c = word[i];
                    if (cur.children[c - 'a'] == null)
                    {
                        break;
                    }

                    cur = cur.children[c - 'a'];
                    if (cur.isWord)
                    {
                        return word.Substring(0, i + 1);
                    }
                }

                return word;
            }
        }
    }
}
