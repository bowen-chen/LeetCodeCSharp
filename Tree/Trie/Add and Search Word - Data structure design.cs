/*
211	Add and Search Word - Data structure design
easy, tri
Design a data structure that supports the following two operations:

void addWord(word)
bool search(word)
search(word) can search a literal word or a regular expression string containing only letters a-z or .. A . means it can represent any one letter.

For example:

addWord("bad")
addWord("dad")
addWord("mad")
search("pad") -> false
search("bad") -> true
search(".ad") -> true
search("b..") -> true
Note:
You may assume that all words are consist of lowercase letters a-z.

click to show hint.

You should be familiar with how a Trie works. If not, please work on this problem: Implement Trie (Prefix Tree) first.
*/

using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    // Your WordDictionary object will be instantiated and called as such:
    // WordDictionary wordDictionary = new WordDictionary();
    // wordDictionary.AddWord("word");
    // wordDictionary.Search("pattern");
    public partial class Solution
    {
        public void Test_WordDictionary()
        {
            var wd = new WordDictionary();
            wd.AddWord("a");
            wd.Search2(".");

            wd.AddWord("a");
            wd.AddWord("a");
            wd.Search(".");
            wd.Search("a");
            wd.Search("aa");
            wd.Search("a");
            wd.Search(".a");
            wd.Search("a.");
        }
    }

    public class WordDictionary
    {
        private class TrieNode : IEnumerable<TrieNode>
        {
            private readonly TrieNode[] children = new TrieNode[26];

            public bool IsWord { get; set; }

            public TrieNode this[char c]
            {
                get { return children[c - 'a']; }
                set { children[c - 'a'] = value; }
            }

            public IEnumerator<TrieNode> GetEnumerator()
            {
                return children.Where(e => e != null).GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        private readonly TrieNode root;

        public WordDictionary()
        {
            root = new TrieNode();
        }

        // Inserts a word into the trie.
        public void AddWord(string word)
        {
            TrieNode n = root;
            foreach (char c in word)
            {
                if (n[c] == null)
                {
                    n[c] = new TrieNode();
                }

                n = n[c];
            }
            n.IsWord = true;
        }

        public bool Search2(string word)
        {
            return Search2(root, word, 0);
        }

        private bool Search2(TrieNode node, string word, int index)
        {
            char c = word[index];
            if (c != '.')
            {
                var n = node[c];
                if (n == null)
                {
                    return false;
                }
                if (word.Length - 1 == index)
                {
                    return n.IsWord;
                }
                return Search2(n, word, index + 1);
            }
            else
            {
                foreach (TrieNode n in node)
                {
                    if (word.Length - 1 == index)
                    {
                        if (n.IsWord)
                        {
                            return true;
                        }
                    }
                    else if (Search2(n, word, index + 1))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        // Returns if the word is in the trie.
        public bool Search(string word)
        {
            var q = new Queue<TrieNode>();
            q.Enqueue(root);
            q.Enqueue(null);
            int i = 0;
            while (q.Count > 0)
            {
                var node = q.Dequeue();
                if (node == null)
                {
                    if (q.Count > 0)
                    {
                        q.Enqueue(null);
                        i++;
                    }
                }
                else
                {
                    if (word[i] == '.')
                    {
                        foreach (TrieNode n in node)
                        {
                            if (i == word.Length - 1)
                            {
                                return n.IsWord;
                            }

                            q.Enqueue(n);
                        }
                    }
                    else
                    {
                        var n = node[word[i]];
                        if (n == null)
                        {
                            continue;
                        }

                        if (i == word.Length - 1)
                        {
                            return n.IsWord;
                        }

                        q.Enqueue(n);
                    }
                }
            }

            return i == word.Length - 1;
        }
    }
}
