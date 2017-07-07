using System;
using System.Collections.Generic;

namespace Demo
{
    // Your Trie object will be instantiated and called as such:
    // Trie trie = new Trie();
    // trie.Insert("somestring");
    // trie.Search("key");
    public class TrieNode
    {
        private readonly Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();

        public Boolean IsWord { get; set; }

        public TrieNode this[char c]
        {
            get { return children.ContainsKey(c) ? children[c] : null; }
            set { children[c] = value; }
        }

        // Inserts a word into the trie.
        public void Insert(string word)
        {
            TrieNode n = this;
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

        // Returns if the word is in the trie.
        public bool Search(string word)
        {
            TrieNode n = this;
            foreach (char c in word)
            {
                if (n[c] == null)
                {
                    return false;
                }
                n = n[c];
            }

            return n.IsWord;
        }

        // Returns if there is any word in the trie
        // that starts with the given prefix.
        public bool StartsWith(string word)
        {
            TrieNode n = this;
            foreach (char c in word)
            {
                if (n[c] == null)
                {
                    return false;
                }
                n = n[c];
            }

            return true;
        }

        public IEnumerable<string> GetStartsWith(string word)
        {
            throw new NotImplementedException();
        }
    }
}
