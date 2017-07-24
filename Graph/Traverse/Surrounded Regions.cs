/*
130	Surrounded Regions	
easy, graph
Surrounded Regions

Given a 2D board containing 'X' and 'O', capture all regions surrounded by 'X'.

A region is captured by flipping all 'O's into 'X's in that surrounded region.

For example,
X X X X
X O O X
X X O X
X O X X
After running your function, the board should be:

X X X X
X X X X
X X X X
X O X X
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public void Test_Solve()
        {
            char[,] a = new char[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    a[i, j] = 'X';
                }
            }
            a[1, 1] = 'O';
            a[1, 2] = 'O';
            a[2, 2] = 'O';
            a[3, 1] = 'O';

            a.Print();
            Solve(a);
            a.Print();

            char[,] b = new char[2000, 2000];
            for (int i = 0; i < 2000; i++)
            {
                for (int j = 0; j < 2000; j++)
                {
                    b[i, j] = 'O';
                }
            }

            Solve(b);

            char[,] c = new char[0, 0];
            Solve(c);
        }

        public void Solve(char[,] board)
        {
            int m = board.GetLength(0);
            if (m == 0)
            {
                return;
            }
            int n = board.GetLength(1);
            if (n == 0)
            {
                return;
            }

            var q = new Queue<int[]>();


            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if ((i == 0 || i == m - 1 || j == 0 || j == n - 1) && board[i, j] == 'O')
                    {
                        q.Enqueue(new[] { i, j });
                        board[i, j] = 'C';
                    }
                }
            }

            var dirs = new[] { new[] { 0, 1 }, new[] { 0, -1 }, new[] { 1, 0 }, new[] { -1, 0 } };
            while (q.Count != 0)
            {
                var p = q.Dequeue();
                int i = p[0];
                int j = p[1];
                foreach (var dir in dirs)
                {
                    int x = i + dir[0];
                    int y = j + dir[1];

                    // INF is int.Max
                    if (x >= 0 && x < m && y >= 0 && y < n && board[x, y] == 'O')
                    {
                        board[x, y] = 'C';
                        q.Enqueue(new[] { x, y });
                    }
                }
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (board[i, j] == 'O')
                    {
                        board[i, j] = 'X';
                    }
                    else if (board[i, j] == 'C')
                    {
                        board[i, j] = 'O';
                    }
                }
            }
        }
    }
}
