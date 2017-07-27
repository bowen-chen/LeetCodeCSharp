/*
642. Design Search Autocomplete System
Problem:

Design a search autocomplete system for a search engine. Users may input a sentence (at least one word and end with a special character ‘#’). For each character they type except ‘#’, you need to return the top 3 historical hot sentences that have prefix the same as the part of sentence already typed. Here are the specific rules:

The hot degree for a sentence is defined as the number of times a user typed the exactly same sentence before. 
The returned top 3 hot sentences should be sorted by hot degree (The first is the hottest one). If several sentences have the same degree of hot, you need to use ASCII-code order (smaller one appears first). 
If less than 3 hot sentences exist, then just return as many as you can. 
When the input is a special character, it means the sentence ends, and in this case, you need to return an empty list. 
Your job is to implement the following functions:

The constructor function:

AutocompleteSystem(String[] sentences, int[] times): This is the constructor. The input is historical data. Sentences is a string array consists of previously typed sentences. Times is the corresponding times a sentence has been typed. Your system should record these historical data.

Now, the user wants to input a new sentence. The following function will provide the next character the user types:

List input(char c): The input c is the next character typed by the user. The character will only be lower-case letters (‘a’ to ‘z’), blank space (’ ‘) or a special character (‘#’). Also, the previously typed sentence should be recorded in your system. The output will be the top 3 historical hot sentences that have prefix the same as the part of sentence already typed.
Example:

Operation: AutocompleteSystem([“i love you”, “island”,”ironman”, “i love leetcode”], [5,3,2,2]) 
The system have already tracked down the following sentences and their corresponding times: 
“i love you” : 5 times 
“island” : 3 times 
“ironman” : 2 times 
“i love leetcode” : 2 times 
Now, the user begins another search:

Operation: input(‘i’) 
Output: [“i love you”, “island”,”i love leetcode”] 
Explanation: 
There are four sentences that have prefix “i”. Among them, “ironman” and “i love leetcode” have same hot degree. Since ’ ’ has ASCII code 32 and ‘r’ has ASCII code 114, “i love leetcode” should be in front of “ironman”. Also we only need to output top 3 hot sentences, so “ironman” will be ignored.

Operation: input(’ ‘) 
Output: [“i love you”,”i love leetcode”] 
Explanation: 
There are only two sentences that have prefix “i “.

Operation: input(‘a’) 
Output: [] 
Explanation: 
There are no sentences that have prefix “i a”.

Operation: input(‘#’) 
Output: [] 
Explanation: 
The user finished the input, the sentence “i a” should be saved as a historical sentence in system. And the following input will be counted as a new search.
Note:

The input sentence will always start with a letter and end with ‘#’, and only one blank space will exist between two words.
The number of complete sentences that to be searched won’t exceed 100. The length of each sentence including those in the historical data won’t exceed 100.
Please use double-quote instead of single-quote when you write test cases even for a character input.
Please remember to RESET your class variables declared in class AutocompleteSystem, as static/class variables are persisted across multiple test cases. Please see here for more details.
*/
using System;
using System.Collections.Generic;
using Demo.Common;

namespace Demo.Tree.Trie
{
    public class AutocompleteSystem
    {

        private class TrieNode
        {
            public TrieNode()
            {
                Children = new TrieNode[27];
            }

            public TrieNode[] Children { get; set; }

            public int Times { get; set; }

            public TrieNode Add(string str)
            {
                TrieNode cur = this;
                foreach (char c in str)
                {
                    cur = Add(c);
                }

                return cur;
            }

            public TrieNode Add(char c)
            {
                int pos = c == ' ' ? 26 : c - 'a';
                return Children[pos] ?? (Children[pos] = new TrieNode());
            }
        }

        private readonly TrieNode root = new TrieNode();
        private TrieNode currentNode;
        private string current = "";

        public AutocompleteSystem(string[] sentences, int[] times)
        {
            for (int i = 0; i < sentences.Length; ++i)
            {
                var node = root.Add(sentences[i]);
                node.Times = times[i];
            }

            currentNode = root;
        }

        public List<string> Top3()
        {
            var queue = new Queue<Tuple<TrieNode, string>>();
            queue.Enqueue(Tuple.Create(currentNode, current));
            var pq = new PriorityQueue<Tuple<string, int>>(4,
                Comparer<Tuple<string, int>>.Create((a, b)=>b.Item2 - a.Item2));
            while (queue.Count != 0)
            {
                var t = queue.Dequeue();
                if (t.Item1.Times > 0)
                {
                    pq.Push(Tuple.Create(t.Item2, t.Item1.Times));
                    if (pq.Count > 3)
                    {
                        pq.Pop();
                    }
                }

                for (int i = 0; i < 27; ++i)
                {
                    if (t.Item1.Children[i] != null)
                    {
                        queue.Enqueue(Tuple.Create(t.Item1.Children[i], current + (i == 26 ? ' ' : i + 'a')));
                    }
                }
            }

            var ret = new List<string>();
            while (pq.Count != 0)
            {
                ret.Insert(0, pq.Pop().Item1);
            }

            return ret;
        }

        public List<string> Input(char c)
        {
            if (c == '#')
            {
                currentNode.Times ++;
                currentNode = root;
                current = "";
                return new List<string>();
            }

            currentNode = currentNode.Add(c);
            current += c;
            return Top3();
        }
    }
}
