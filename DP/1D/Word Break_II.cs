/*
140	Word Break II
medium, dfs, *
Word Break II
Given a string s and a dictionary of words dict, add spaces in s to construct a sentence where each word is a valid dictionary word.

Return all such possible sentences.

For example, given
s = "catsanddog",
dict = ["cat", "cats", "and", "sand", "dog"].

A solution is ["cats and dog", "cat sand dog"].
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    public partial class Solution
    {
        // Graph bottom up
        public IList<string> WordBreak4(string s, IList<string> wordDict)
        {
            // ending with i, start index
            List<int>[] dp = new List<int>[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i; j >= 0; j--)
                {
                    if ((j <= 0 || dp[j - 1] != null) && wordDict.Contains(s.Substring(j, i - j + 1)))
                    {
                        if (dp[i] == null)
                        {
                            dp[i] = new List<int>();
                        }

                        dp[i].Add(j);
                    }
                }
            }

            // build up result strings
            // DFS
            List<string> ret = new List<string>();
            if (dp[s.Length - 1] == null)
            {
                return ret;
            }

            // <next word end index, current sentence 
            var sk = new Stack<Tuple<int, string>>();
            foreach (int startIndex in dp[s.Length - 1])
            {
                sk.Push(Tuple.Create(startIndex - 1, s.Substring(startIndex, s.Length - startIndex)));
            }

            while (sk.Count != 0)
            {
                var top = sk.Pop();
                if (top.Item1 == -1)
                {
                    ret.Add(top.Item2);
                    continue;
                }

                foreach (var startIndex in dp[top.Item1])
                {
                    sk.Push(Tuple.Create(startIndex - 1,
                        s.Substring(startIndex, top.Item1 - startIndex + 1) + " " + top.Item2));
                }
            }

            return ret;
        }

        // Tri solution
        public class TrieNode2
        {
            private readonly Dictionary<char, TrieNode2> _nodes = new Dictionary<char, TrieNode2>();

            public string Word { get; set; }

            public int Count {
                get { return _nodes.Count; }
            }

            public TrieNode2 this[char charactor]
            {
                get
                {
                    if (_nodes.ContainsKey(charactor))
                    {
                        return _nodes[charactor];
                    }

                    return null;
                }
                set { _nodes[charactor] = value; }
            }

            public void InsertWord(string s)
            {
                var cur = this;
                for (int i = 0; i < s.Length; i++)
                {
                    char c = s[i];
                    TrieNode2 cnode = cur[c];
                    if (cnode == null)
                    {
                        cnode = new TrieNode2();
                        cur[c] = cnode;
                    }

                    if (i == s.Length - 1)
                    {
                        cnode.Word = s;
                    }

                    cur = cnode;
                }
            }
        }

        public IList<string> WordBreak5(string s, ISet<string> wordDict)
        {
            var root = new TrieNode2();
            int maxLenWord = 0;
            bool endReachable = false;

            // 1. construct trie with dictionary words
            foreach (string word in wordDict)
            {
                if (word.Length > maxLenWord)
                {
                    maxLenWord = word.Length;
                }

                root.InsertWord(word);
            }

            // we store the words which start at various indices in this map
            // if multiple words can start at 1 index, they are stored in a linked
            // list at that location in the map
            var indexWordMap = new Dictionary<int, List<string>>();

            // 2. go thru string, consider suffixes of increasing length
            for (int j = s.Length - 1; j >= 0; j--)
            {
                int k = j;
                TrieNode2 n = root;
                while (n != null && n.Count != 0 && k < s.Length)
                {
                    // 3. traverse the trie using a prefix of this particular
                    // suffix and see if you can reach words which end in
                    // indices which have words starting from them
                    n = n[s[k]];
                    if (n != null && n.Word != null &&
                        (j + n.Word.Length == s.Length || indexWordMap[j + n.Word.Length] != null))
                    {
                        if (!indexWordMap.ContainsKey(j))
                        {
                            indexWordMap[j] = new List<string>();
                        }

                        indexWordMap[j].Add(n.Word);
                    }

                    if (n != null)
                    {
                        k++;
                        if (k >= s.Length)
                        {
                            endReachable = true;
                        }
                    }
                }
                if (!endReachable && j < s.Length - maxLenWord)
                {
                    // leetcode oj doesn't accept null, balls...
                    return new List<string>();
                }
            }

            // now we have a graph which can be traversed from start (0)
            // to the last node to get a sentence.
            // do a depth first traversal with no visited node check to
            // print out all sentences
            List<string> ll = new List<string>();
            List<string> sentences = new List<string>();
            GetSentences(s.Length, indexWordMap, 0, ll, sentences);
            return new List<string>(sentences);
        }

        private void GetSentences(int length, Dictionary<int, List<string>> words, int index, List<string> sentence, List<string> sentences)
        {

            if (index == length)
            {
                // go thru entire list and print words
                int i = 0;
                StringBuilder sb = new StringBuilder();
                foreach (string s in sentence)
                {
                    if (i != 0)
                        sb.Append(' ');
                    sb.Append(s);
                    i++;
                }
                sentences.Add(sb.ToString());
                // System.out.println();
            }
            else
            {
                var ws = words[index];
                foreach(var w in ws)
                {
                    // System.out.println("Word at position : " + index + " | " +
                    // w.word);
                    sentence.Add(w);
                    GetSentences(length, words, index + w.Length, sentence, sentences);
                    sentence.Remove(w);
                }
            }
        }

        private class Data
        {
            public int index;
            public string value;

            public Data(int i, string s)
            {
                index = i;
                value = s;
            }


        }

        public IList<string> WordBreak(string s, IList<string> wordDict)
        {
            Queue<Data> queue = new Queue<Data>();
            IList<string> response = new List<string>();

            Data obj = new Data(0, "");

            queue.Enqueue(obj);

            while (queue.Count > 0 && s.Length < 100)
            {
                Data data = queue.Dequeue();
                int start = data.index;

                for (int end = start + 1; end <= s.Length; end++)
                {
                    string toCheck = s.Substring(start, end - start);
                    if (wordDict.Contains(toCheck))
                    {
                        if (end == s.Length)
                        {
                            response.Add(data.value + toCheck);
                        }
                        else
                        {
                            obj = new Data(end, data.value + toCheck + " ");
                            queue.Enqueue(obj);
                        }
                    }
                }
            }

            return response;
        }
    }
}
