/*
79. Word Search
Easy, DFS, *
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

namespace Demo
{
    public partial class Solution
    {
        public bool Exist(char[,] board, string word)
        {
            for (int y = 0; y < board.GetLength(0); y++)
            {
                for (int x = 0; x < board.GetLength(1); x++)
                {
                    if (Exist(board, y, x, word, 0))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool Exist(char[,] board, int y, int x, string word, int i)
        {
            if (y < 0 || x < 0 || y >= board.GetLength(0) || x >= board.GetLength(1) || board[y, x] != word[i])
            {
                return false;
            }

            if (i == word.Length)
            {
                return true;
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
    }
}
