/*
286	Walls and Gates
easy
Problem Description:

You are given a m x n 2D grid initialized with these three possible values.

-1 - A wall or an obstacle.
0 - A gate.
INF - Infinity means an empty room. We use the value 231 - 1 = 2147483647 to represent INF as you may assume that the distance to a gate is less than2147483647.
Fill each empty room with the distance to its nearest gate. If it is impossible to reach a gate, it should be filled with INF.

For example, given the 2D grid:

INF  -1  0  INF
INF INF INF  -1
INF  -1 INF  -1
  0  -1 INF INF
 After running your function, the 2D grid should be:

  3  -1   0   1
  2   2   1  -1
  1  -1   2  -1
  0  -1   3   4
*/
using System;
using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public void WallsAndGates(int[,] rooms)
        {
            int m = rooms.GetLength(0);
            int n = rooms.GetLength(1);
            var q = new Queue<Tuple<int, int>>();
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (rooms[i, j] == 0)
                    {
                        q.Enqueue(Tuple.Create(i, j));
                        q.Enqueue(null);
                    }
                }
            }
            int d = 1;
            var dirs = new[] { new[] { 0, 1 }, new[] { 0, -1 }, new[] { 1, 0 }, new[] { -1, 0 } };
            while (q.Count != 0)
            {
                var p = q.Dequeue();
                if (p == null)
                {
                    if (q.Count != 0)
                    {
                        q.Enqueue(null);
                        d++;
                    }
                }
                else
                {
                    int i = p.Item1;
                    int j = p.Item2;

                    foreach (var dir in dirs) {
                        int x = i + dir[0];
                        int y = j + dir[1];

                        // INF is int.Max
                        if (x >= 0 && x < m && y >= 0 && y < n && rooms[x, y] == int.MaxValue)
                        {
                            q.Enqueue(Tuple.Create(x, y));
                            rooms[x, y] = d;
                        }
                    }
                }
            }
        }
    }
}
