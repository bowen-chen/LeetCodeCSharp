/*
529. Minesweeper
*
Let's play the minesweeper game (Wikipedia, online game)!

You are given a 2D char matrix representing the game board. 'M' represents an unrevealed mine, 'E' represents an unrevealed empty square, 'B' represents a revealed blank square that has no adjacent (above, below, left, right, and all 4 diagonals) mines, digit ('1' to '8') represents how many mines are adjacent to this revealed square, and finally 'X' represents a revealed mine.

Now given the next click position (row and column indices) among all the unrevealed squares ('M' or 'E'), return the board after revealing this position according to the following rules:

If a mine ('M') is revealed, then the game is over - change it to 'X'.
If an empty square ('E') with no adjacent mines is revealed, then change it to revealed blank ('B') and all of its adjacent unrevealed squares should be revealed recursively.
If an empty square ('E') with at least one adjacent mine is revealed, then change it to a digit ('1' to '8') representing the number of adjacent mines.
Return the board when no more squares will be revealed.
Example 1:
Input: 

[['E', 'E', 'E', 'E', 'E'],
 ['E', 'E', 'M', 'E', 'E'],
 ['E', 'E', 'E', 'E', 'E'],
 ['E', 'E', 'E', 'E', 'E']]

Click : [3,0]

Output: 

[['B', '1', 'E', '1', 'B'],
 ['B', '1', 'M', '1', 'B'],
 ['B', '1', '1', '1', 'B'],
 ['B', 'B', 'B', 'B', 'B']]

Explanation:

Example 2:
Input: 

[['B', '1', 'E', '1', 'B'],
 ['B', '1', 'M', '1', 'B'],
 ['B', '1', '1', '1', 'B'],
 ['B', 'B', 'B', 'B', 'B']]

Click : [1,2]

Output: 

[['B', '1', 'E', '1', 'B'],
 ['B', '1', 'X', '1', 'B'],
 ['B', '1', '1', '1', 'B'],
 ['B', 'B', 'B', 'B', 'B']]

Explanation:

Note:
The range of the input matrix's height and width is [1,50].
The click position will only be an unrevealed square ('M' or 'E'), which also means the input board contains at least one clickable square.
The input board won't be a stage when game is over (some mines have been revealed).
For simplicity, not mentioned rules should be ignored in this problem. For example, you don't need to reveal all the unrevealed mines when the game is over, consider any cases that you will win the game or flag any squares.

*/
using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public char[,] UpdateBoard(char[,] board, int[] click)
        {

            if (board == null || board.GetLength(0) == 0 || board.GetLength(1) == 0)
            {
                return board;
            }

            if (board[click[0], click[1]] == 'M')
            {
                board[click[0], click[1]] = 'X';
            }
            else if (board[click[0], click[1]] == 'E')
            {
                int m = board.GetLength(0);
                int n = board.GetLength(1);
                var q = new Queue<int[]>();
                board[click[0], click[1]] = 'C';
                q.Enqueue(click);
                while (q.Count != 0)
                {
                    var p = q.Dequeue();
                    int a = p[0];
                    int b = p[1];
                    int c = 0;
                    for (int i = a - 1; i <= a + 1; i++)
                    {
                        for (int j = b - 1; j <= b + 1; j++)
                        {
                            if (i >= 0 && i < m && j >= 0 && j < n && board[i, j] == 'M')
                            {
                                c++;
                            }
                        }
                    }

                    if (c > 0)
                    {
                        board[a, b] = (char) ('0' + c);
                    }
                    else
                    {
                        board[a, b] = 'B';
                        for (int i = a - 1; i <= a + 1; i++)
                        {
                            for (int j = b - 1; j <= b + 1; j++)
                            {
                                if (i >= 0 && i < m && j >= 0 && j < n && board[i, j] == 'E')
                                {
                                    board[i, j] = 'C';
                                    q.Enqueue(new[] {i, j});
                                }
                            }
                        }
                    }
                }
            }

            return board;
        }
    }
}
