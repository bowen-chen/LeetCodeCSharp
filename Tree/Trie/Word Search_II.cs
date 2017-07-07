/*
212	Word Search II
Easy, DFS
Given a 2D board and a list of words from the dictionary, find all words in the board.

Each word must be constructed from letters of sequentially adjacent cell, where "adjacent" cells are those horizontally or vertically neighboring. The same letter cell may not be used more than once in a word.

For example,
Given words = ["oath","pea","eat","rain"] and board =

[
  ['o','a','a','n'],
  ['e','t','a','e'],
  ['i','h','k','r'],
  ['i','f','l','v']
]
Return ["eat","oath"].
*/

using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    public partial class Solution
    {
        public IList<string> FindWords(char[,] board, string[] words)
        {
            TrieNode trie = new TrieNode();
            foreach (string word in words)
            {
                trie.Insert(word);
            }

            int m = board.GetLength(0);
            int n = board.GetLength(1);
            var visited = new bool[m, n];
            var ret = new HashSet<string>();
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    FindWords(ret, board, m, n, visited, "", i, j, trie);
                }
            }

            return ret.ToList();
        }

        private void FindWords(HashSet<string> ret, char[,] board, int m, int n, bool[,] visited, string str, int x, int y, TrieNode root)
        {
            if (x < 0 || x >= m || y < 0 || y >= n || visited[x, y])
            {
                return;
            }

            var node = root[board[x, y]];
            if (node == null)
            {
                return;
            }
            str += board[x, y];

            if (node.IsWord && !ret.Contains(str))
            {
                ret.Add(str);
            }

            visited[x, y] = true;
            FindWords(ret, board, m, n, visited, str, x - 1, y, node);
            FindWords(ret, board, m, n, visited, str, x + 1, y, node);
            FindWords(ret, board, m, n, visited, str, x, y - 1, node);
            FindWords(ret, board, m, n, visited, str, x, y + 1, node);
            visited[x, y] = false;
        }
    }
}
