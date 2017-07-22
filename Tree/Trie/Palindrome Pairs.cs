/*
336	Palindrome Pairs 
medium
Given a list of unique words. Find all pairs of distinct indices (i, j) in the given list, so that the concatenation of the two words, i.e. words[i] + words[j] is a palindrome.

Example 1:
Given words = ["bat", "tab", "cat"]
Return [[0, 1], [1, 0]]
The palindromes are ["battab", "tabbat"]
Example 2:
Given words = ["abcd", "dcba", "lls", "s", "sssll"]
Return [[0, 1], [1, 0], [3, 2], [2, 4]]
The palindromes are ["dcbaabcd", "abcddcba", "slls", "llssssll"]
*/

using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    public partial class Solution
    {
        public class TrieNode3
        {
            private readonly Dictionary<char, TrieNode3> children = new Dictionary<char, TrieNode3>();

            public TrieNode3() 
            {
                IsRemaingPalindrome = new List<int>();
            }

            public bool IsWord { get; set; }

            public TrieNode3 this[char c]
            {
                get { return children.ContainsKey(c) ? children[c] : null; }
                set { children[c] = value; }
            }

            public List<int> IsRemaingPalindrome { get; set; }

            public int Index { get; set; }

            public void Insert(string word, int index)
            {
                var n = this;
                for (int i = 0; i < word.Length; i++)
                {
                    if (IsPalindrome(word, i, word.Length - 1))
                    {
                        n.IsRemaingPalindrome.Add(index);
                    }

                    char c = word[i];
                    if (n[c] == null)
                    {
                        n[c] = new TrieNode3();
                    }

                    n = n[c];
                }

                n.IsWord = true;
                n.Index = index;
                n.IsRemaingPalindrome.Add(index);
            }

            public IEnumerable<int> Search(string word)
            {
                var n = this;
                for (int j = 0; j < word.Length; j++)
                {
                    if (n.IsWord && IsPalindrome(word, j, word.Length - 1))
                    {
                        yield return n.Index;
                    }

                    n = n[word[j]];
                    if (n == null)
                    {
                        yield break;
                    }
                }
                
                // match the whole word
                foreach (int j in n.IsRemaingPalindrome)
                {
                    yield return j;
                }
            }
        }

        public void Test_PalindromePairs()
        {
            PalindromePairs(new[] { "a", "" });
            //PalindromePairs(new[] {"s"});
            //PalindromePairs(new[] {"abcd", "dcba", "lls", "s", "sssll"});
        }

        public IList<IList<int>> PalindromePairs(string[] words)
        {   
            List<IList<int>> res = new List<IList<int>>();
            TrieNode3 root = new TrieNode3();

            for (int i = 0; i < words.Length; i++)
            {
                root.Insert(new string(words[i].Reverse().ToArray()), i);
            }

            for (int i = 0; i < words.Length; i++)
            {
                foreach(int j in root.Search(words[i]))
                {
                    if (i != j)
                    {
                        res.Add(new List<int> {i, j});
                    }
                }
            }

            return res;
        }
    }
}
