/*
208. Implement Trie (Prefix Tree)
easy, *
Implement a trie with insert, search, and startsWith methods.

Note:
You may assume that all inputs are consist of lowercase letters a-z.
*/

using System.Collections.Generic;

namespace Demo
{
    public class Trie
    {

        Dictionary<char, Trie> children = new Dictionary<char, Trie>();
        bool isWord = false;

        /** Initialize your data structure here. */
        public Trie()
        {

        }

        /** Inserts a word into the trie. */
        public void Insert(string word)
        {
            var n = this;
            foreach (var c in word)
            {
                if (!n.children.ContainsKey(c))
                {
                    n.children[c] = new Trie();
                }
                n = n.children[c];
            }
            n.isWord = true;
        }

        /** Returns if the word is in the trie. */
        public bool Search(string word)
        {
            var n = this;
            foreach (var c in word)
            {
                if (!n.children.ContainsKey(c))
                {
                    return false;
                }
                n = n.children[c];
            }
            return n.isWord;
        }

        /** Returns if there is any word in the trie that starts with the given prefix. */
        public bool StartsWith(string prefix)
        {
            var n = this;
            foreach (var c in prefix)
            {
                if (!n.children.ContainsKey(c))
                {
                    return false;
                }
                n = children[c];
            }

            return true;
        }
    }
}
