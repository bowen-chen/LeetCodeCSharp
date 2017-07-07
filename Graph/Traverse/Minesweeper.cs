/*
529. Minesweeper
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
            };
            int m = board.GetLength(0);
            int n = board.GetLength(1);
            var q = new Queue<int[]>();
            q.Enqueue(click);
            while (q.Count != 0)
            {
                var p = q.Dequeue();
                int row = p[0];
                int col = p[1];
                int cnt = 0;

                if (board[row, col] == 'M')
                {
                    board[row, col] = 'X';
                }
                else
                {
                    var emptyNeighbors = new List<int[]>();
                    for (int i = -1; i < 2; ++i)
                    {
                        for (int j = -1; j < 2; ++j)
                        {
                            int x = row + i, y = col + j;
                            if (x < 0 || x >= m || y < 0 || y >= n || (i==0&&j==0))
                            {
                                continue;
                            }
                            if (board[x, y] == 'M')
                            {
                                ++cnt;
                            }
                            else if (board[x, y] == 'E')
                            {
                                emptyNeighbors.Add(new[] {x, y});
                            }
                        }
                    }

                    if (cnt > 0)
                    {
                        board[row, col] = (char) (cnt + '0');
                    }
                    else
                    {
                        board[row, col] = 'B';
                        foreach (var a in emptyNeighbors)
                        {
                            board[a[0], a[1]] = 'V';
                            q.Enqueue(a);
                        }
                    }
                }
            }
            return board;

        }
    }
}
