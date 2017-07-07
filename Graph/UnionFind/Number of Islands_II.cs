/*
medium, UnionFind, path compression
A 2d grid map of m rows and n columns is initially filled with water. We may perform an addLand operation which turns the water at position (row, col) into a land. Given a list of positions to operate, count the number of islands after each addLand operation. An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. You may assume all four edges of the grid are all surrounded by water.

Example:

Given m = 3, n = 3, positions = [[0,0], [0,1], [1,2], [2,1]].
Initially, the 2d grid grid is filled with water. (Assume 0 represents water and 1 represents land).

0 0 0
0 0 0
0 0 0
Operation #1: addLand(0, 0) turns the water at grid[0][0] into a land.

1 0 0
0 0 0   Number of islands = 1
0 0 0
Operation #2: addLand(0, 1) turns the water at grid[0][1] into a land.

1 1 0
0 0 0   Number of islands = 1
0 0 0
Operation #3: addLand(1, 2) turns the water at grid[1][2] into a land.

1 1 0
0 0 1   Number of islands = 2
0 0 0
Operation #4: addLand(2, 1) turns the water at grid[2][1] into a land.

1 1 0
0 0 1   Number of islands = 3
0 1 0
We return the result as an array: [1, 1, 2, 3]
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        private static readonly int[][] dirs = {new[] {0, 1}, new[] {0, -1}, new[] {-1, 0}, new[] {1, 0}};
        public List<int> NumIslands2(int m, int n, int[,] positions)
        {
            var uf = new UnionFind(m * n);
            var ret = new List<int>();
            var map = new int[m, n];
            for (int i = 0; i < positions.GetLength(0); i++)
            {
                int x = positions[i, 0], y = positions[i, 1];
                int key = x * n + y;
                map[x, y] = 1;
                foreach (int[] d in dirs)
                {
                    int x1 = x + d[0];
                    int y1 = y + d[1];
                    if (x1 >= 0 && x1 <= m - 1 && y1 >= 0 && y1 <= n - 1 && map[x1, y1] == 1)
                    {
                        int key2 = x1 * n + y1;
                        uf.Union(key, key2);
                    }
                }
                ret.Add(i + 1 - (m * n - uf.Count));
            }
            return ret;
        }
    }
}
