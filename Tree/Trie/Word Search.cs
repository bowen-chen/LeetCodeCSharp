/*
Easy, DFS
Given a 2D board and a word, find if the word exists in the grid.

The word can be constructed from letters of sequentially adjacent cell, where "adjacent" cells are those horizontally or vertically neighboring. The same letter cell may not be used more than once.

For example,
Given board =

[
  ['A','B','C','E'],
  ['S','F','C','S'],
  ['A','D','E','E']
]
word = "ABCCED", -> returns true,
word = "SEE", -> returns true,
word = "ABCB", -> returns false.
*/
using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public bool Exist(char[,] board, string word)
        {
            for (int y = 0; y <= board.GetUpperBound(0); y++)
            {
                for (int x = 0; x <= board.GetUpperBound(1); x++)
                {
                    if (Exist(board, y, x, word, 0)) return true;
                }
            }
            return false;
        }

        private bool Exist(char[,] board, int y, int x, string word, int i)
        {
            if (i == word.Length)
            {
                return true;
            }
            if (y < 0 || x < 0 || y >= board.GetLength(0) || x >= board.GetLength(1))
            {
                return false;
            }

            // if it is visited, then it won't match
            if (board[y, x] != word[i])
            {
                return false;
            }

            // mark it as visited
            board[y, x] = (char) (board[y, x] ^ 256);
            bool exist = Exist(board, y, x + 1, word, i + 1)
                         || Exist(board, y, x - 1, word, i + 1)
                         || Exist(board, y + 1, x, word, i + 1)
                         || Exist(board, y - 1, x, word, i + 1);
            board[y, x] = (char) (board[y, x] ^ 256);
            return exist;
        }

        public bool Exist2(char[,] board, string word)
        {
            for (int y = 0; y <= board.GetUpperBound(0); y++)
            {
                for (int x = 0; x <= board.GetUpperBound(1); x++)
                {
                    var visited = new HashSet<long>();
                    if (Exist2(board, y, x, word, 0, visited)) return true;
                }
            }
            return false;
        }

        private bool Exist2(char[,] board, int y, int x, string word, int i, HashSet<long> v)
        {
            if (i == word.Length)
            {
                return true;
            }
            if (y < 0 || x < 0 || y > board.GetUpperBound(0) || x > board.GetUpperBound(1) ||
                v.Contains(((long) y) << 32 + x))
            {
                return false;
            }
            if (board[y, x] != word[i])
            {
                return false;
            }
            v.Add(((long) y) << 32 + x);
            bool exist = Exist2(board, y, x + 1, word, i + 1, v)
                         || Exist2(board, y, x - 1, word, i + 1, v)
                         || Exist2(board, y + 1, x, word, i + 1, v)
                         || Exist2(board, y - 1, x, word, i + 1, v);
            v.Remove(((long) y) << 32 + x);
            return exist;
        }
    }
}
