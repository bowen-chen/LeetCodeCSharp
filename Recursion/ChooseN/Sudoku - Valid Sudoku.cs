/*
36	Valid Sudoku
Easy, hash
Determine if a Sudoku is valid, according to: Sudoku Puzzles - The Rules.

The Sudoku board could be partially filled, where empty cells are filled with the character '.'.


A partially filled sudoku which is valid.

Note:
A valid Sudoku board (partially filled) is not necessarily solvable. Only the filled cells need to be validated.
*/

namespace Demo
{
    public partial class Solution
    {
        public bool IsValidSudoku(char[,] board)
        {
            int[] row = new int[9];
            int[] col = new int[9];
            int[] cell = new int[9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i, j] != '.')
                    {
                        int num = 1 << (board[i, j] - '0' - 1);
                        int k = i/3*3 + j/3;
                        if ((row[i] & num) != 0 || (col[j] & num) != 0 || (cell[k] & num) != 0)
                        {
                            return false;
                        }

                        row[i] |= num;
                        col[j] |= num;
                        cell[k] |= num;
                    }
                }
            }

            return true;
        }
    }
}
