﻿/*
425	Word Squares
medium
Given a set of words (without duplicates), find all word squares you can build from them.

A sequence of words forms a valid word square if the kth row and column read the exact same string, where 0 ≤ k < max(numRows, numColumns).

For example, the word sequence ["ball","area","lead","lady"] forms a word square because each word reads the same both horizontally and vertically.

b a l l
a r e a
l e a d
l a d y
Note:

There are at least 1 and at most 1000 words.
All words will have the exact same length.
Word length is at least 1 and at most 5.
Each word contains only lowercase English alphabet a-z.
 

Example 1:

Input:
["area","lead","wall","lady","ball"]

Output:
[
  [ "wall",
    "area",
    "lead",
    "lady"
  ],
  [ "ball",
    "area",
    "lead",
    "lady"
  ]
]

Explanation:
The output consists of two word squares. The order of output does not matter (just the order of words in each word square matters).
 

Example 2:

Input:
["abat","baba","atan","atal"]

Output:
[
  [ "baba",
    "abat",
    "baba",
    "atan"
  ],
  [ "baba",
    "abat",
    "baba",
    "atal"
  ]
]

Explanation:
The output consists of two word squares. The order of output does not matter (just the order of words in each word square matters).
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        private TrieNode BuildTrie(string[] words)
        {
            TrieNode root = new TrieNode();
            foreach (var w in words)
            {
                root.Insert(w);
            }
            return root;
        }

        public IList<string[]> WordSquares(string[] words)
        {
            TrieNode root = BuildTrie(words);
            var res = new List<string[]>();
            var c = new string[words.Length];
            WordSquares(res, c, root, 0);
            return res;
        }

        private void WordSquares(IList<string[]> res, string[] c, TrieNode root, int level)
        {
            int n = c.Length;
            if (level >= n)
            {
                var t = new string[c.Length];
                c.CopyTo(t, 0);
                res.Add(t);
                return;
            }
            string prefix = "";
            for (int i = 0; i < level; ++i)
            {
                prefix += c[i][level];
            }

            foreach (var word in root.GetStartsWith(prefix))
            {
                c[level] = word;
                WordSquares(res, c, root, level + 1);
            }
        }
    }
}