/*
37	Sudoku Solver
medium
Write a program to solve a Sudoku puzzle by filling the empty cells.

Empty cells are indicated by the character '.'.

You may assume that there will be only one unique solution.


A sudoku puzzle...


...and its solution numbers marked in red.
*/

namespace Demo
{
    public partial class Solution
    {
        public void SolveSudoku(char[,] board)
        {
            int[,] mark = new int[3,9]; // row, col, cell

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i, j] != '.')
                    {
                        int num = 1 << (board[i, j] - '0' - 1);
                        int k = i / 3 * 3 + j / 3;
                        mark[0,i] |= num;
                        mark[1,j] |= num;
                        mark[2, k] |= num;
                    }
                }
            }

            SolveSudoku(board, mark);
        }

        public bool SolveSudoku(char[,] board, int[,] mark)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i, j] == '.')
                    {
                        for (char c = '1'; c <= '9'; c++)
                        {
                            //trial. Try 1 through 9 for each cell
                            if (TryPutSolveSudoku(board, mark, i,j,c))
                            {
                                board[i, j] = c; //Put c for this cell

                                if (SolveSudoku(board, mark))
                                {
                                    return true; //If it's the solution return true
                                }

                                UndoSudoku(board, mark, i, j);
                            }
                        }
                        return false;
                    }
                }
            }

            // All cell is filled.
            return true;
        }

        public bool TryPutSolveSudoku(char[,] board, int[,] mark, int i, int j, char c)
        {
            int num = 1 << (c - '0' - 1);
            int k = i / 3 * 3 + j / 3;
            if (((mark[0, i]| mark[1, j]| mark[2, k]) & num) != 0)
            {
                return false;
            }

            mark[0, i] |= num;
            mark[1, j] |= num;
            mark[2, k] |= num;

            board[i, j] = c;
            return true;
        }

        public bool UndoSudoku(char[,] board, int[,] mark, int i, int j)
        {
            char c = board[i, j];
            int num = ~(1 << (c - '0' - 1));
            int k = i / 3 * 3 + j / 3;

            mark[0, i] &= num;
            mark[1, j] &= num;
            mark[2, k] &= num;

            board[i, j] = '.';
            return true;
        }
    }
}
