/*
677. Map Sum Pairs
Implement a MapSum class with insert, and sum methods.

For the method insert, you'll be given a pair of (string, integer). The string represents the key and the integer represents the value. If the key already existed, then the original key-value pair will be overridden to the new one.

For the method sum, you'll be given a string representing the prefix, and you need to return the sum of all the pairs' value whose key starts with the prefix.

Example 1:
Input: insert("apple", 3), Output: Null
Input: sum("ap"), Output: 3
Input: insert("app", 2), Output: Null
Input: sum("ap"), Output: 5

*/

using System.ComponentModel.Design;

namespace Demo
{
    public class MapSum
    {
        private class TrieNode
        {
            private TrieNode[] children = new TrieNode[26];

            private int count { get; set; }

            public TrieNode()
            {
            }

            public void Insert(string word, int val)
            {
                var n = this;
                foreach (var c in word)
                {
                    if (n.children[c - 'a'] == null)
                    {
                        n.children[c - 'a'] = new TrieNode();
                    }

                    n = n.children[c - 'a'];
                }

                n.count = val;
            }

            public int Search(string word)
            {
                var n = this;
                foreach (var c in word)
                {
                    if (n.children[c - 'a'] == null)
                    {
                        return 0;
                    }

                    n = n.children[c - 'a'];
                }

                return DFS(n);
            }

            private int DFS(TrieNode node)
            {
                var res = node.count;
                foreach (var n in node.children)
                {
                    if (n != null)
                    {
                        res+=DFS(n);
                    }
                }

                return res;
            }
        }

        private TrieNode root = new TrieNode();

        /** Initialize your data structure here. */
        public MapSum()
        {

        }

        public void Insert(string key, int val)
        {
            root.Insert(key, val);
        }

        public int Sum(string prefix)
        {
            return root.Search(prefix);
        }
    }

    /**
     * Your MapSum object will be instantiated and called as such:
     * MapSum obj = new MapSum();
     * obj.Insert(key,val);
     * int param_2 = obj.Sum(prefix);
     */
}
