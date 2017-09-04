/*
289	Game of Life
easy, bit, *
According to the Wikipedia's article: "The Game of Life, also known simply as Life, is a cellular automaton devised by the British mathematician John Horton Conway in 1970."

Given a board with m by n cells, each cell has an initial state live (1) or dead (0). Each cell interacts with its eight neighbors (horizontal, vertical, diagonal) using the following four rules (taken from the above Wikipedia article):

Any live cell with fewer than two live neighbors dies, as if caused by under-population.
Any live cell with two or three live neighbors lives on to the next generation. 3, 4
Any live cell with more than three live neighbors dies, as if by over-population..
Any dead cell with exactly three live neighbors becomes a live cell, as if by reproduction. 3
Write a function to compute the next state (after one update) of the board given its current state.

Follow up: 
Could you solve it in-place? Remember that the board needs to be updated at the same time: You cannot update some cells first and then use their updated values to update other cells.
In this question, we represent the board using a 2D array. In principle, the board is infinite, which would cause problems when the active area encroaches the border of the array. How would you address these problems?
*/

using System;

namespace Demo
{
    public partial class Solution
    {
        public void Test_GameOfLife()
        {
            GameOfLife(new[,] {{1, 1}, {1, 1}});
            GameOfLife(new[,] {{1}});
        }

        public void GameOfLife(int[,] board)
        {
            int m = board.GetLength(0);
            int n = board.GetLength(1);
            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    int count = 0;
                    for (int i2 = Math.Max(i - 1, 0); i2 <= Math.Min(i + 1, m - 1); ++i2)
                    {
                        for (int j2 = Math.Max(j - 1, 0); j2 <= Math.Min(j + 1, n - 1); ++j2)
                        {
                            count += board[i2, j2] & 1;
                        }
                    }

                    // count =3 cover live or dead, count =4 and live
                    if (count == 3 || count - board[i, j] == 3)
                    {
                        board[i, j] |= 2;
                    }
                }
            }

            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    board[i, j] >>= 1;
                }
            }
        }
    }
}
