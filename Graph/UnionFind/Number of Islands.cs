/*
200 Number of Islands
easy, graph
Given a 2d grid map of '1's (land) and '0's (water), count the number of islands. An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. You may assume all four edges of the grid are all surrounded by water.

Example 1:

11110
11010
11000
00000
Answer: 1

Example 2:

11000
11000
00100
00011
Answer: 3
*/
using System;
using System.CodeDom;
using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public int NumIslands(char[,] grid)
        {
            int m = grid.GetLength(0);
            int n = grid.GetLength(1);
            var uf = new UnionFind(m * n);
            var dirs = new[] { new[] { 0, 1 }, new[] { 1, 0 } };
            int i = 0;
            for (int x = 0; x < m; x++)
            {
                for (int y = 0; y < n; y++)
                {
                    if(grid[x,y] == '1')
                    {
                        i++;
                        int key = x * n + y;
                        foreach (int[] d in dirs)
                        {
                            int x1 = x + d[0];
                            int y1 = y + d[1];
                            if (x1 >= 0 && x1 <= m - 1 && y1 >= 0 && y1 <= n - 1 && grid[x1, y1] == '1')
                            {
                                int key2 = x1 * n + y1;
                                uf.Union(key, key2);
                            }
                        }
                    }
                }
            }

            return uf.Count - (m * n - i);
        }

        public int NumIslands2(char[,] grid)
        {
            int ret = 0;
            int m = grid.GetLength(0);
            int n = grid.GetLength(1);
            var visited = new bool[m,n];
            var q = new Queue<int[]>();

            var dirs = new[] { new[] { 0, -1 }, new[] { -1, 0 }, new[] { 0, 1 }, new[] { 1, 0 } };
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i, j] == '1' && !visited[i, j])
                    {
                        ret++;
                        visited[i, j] = true;
                        q.Enqueue(new[] {i, j});
                        while (q.Count != 0)
                        {
                            var t = q.Dequeue();
                            foreach (var dir in dirs)
                            {
                                int x = t[0] + dir[0];
                                int y = t[1] + dir[1];
                                if (x >= 0 && x < m && y >= 0 && y < n && grid[x, y] == '1' && !visited[x, y])
                                {
                                    visited[x, y] = true;
                                    q.Enqueue(new[] {x, y});
                                }
                            }
                        }
                    }
                }
            }

            return ret;
        }
    }
}
