/*
407	Trapping Rain Water II 
Given an m x n matrix of positive integers representing the height of each unit cell in a 2D elevation map, compute the volume of water it is able to trap after raining.

Note:
Both m and n are less than 110. The height of each unit cell is greater than 0 and is less than 20,000.

Example:

Given the following 3x6 height map:
[
  [1,4,3,1,3,2],
  [3,2,1,3,2,4],
  [2,3,3,2,3,1]
]

Return 4.
*/

using System;
using System.Collections.Generic;
using Demo.Common;

namespace Demo
{
    public partial class Solution
    {
        public int TrapRainWater(int[,] heightMap)
        {
            if (heightMap.GetLength(0) == 0)
            {
                return 0;
            }

            int m = heightMap.GetLength(0);
            int n = heightMap.GetLength(1);
            int res = 0;
            int waterLevel = int.MinValue;
            var q = new PriorityQueue<Tuple<int, int>>(
                16, Comparer<Tuple<int, int>>.Create((p1, p2) => p2.Item1 - p1.Item1));
            var visited = new HashSet<int>();

            var dirs = new[] {new[] {0, -1}, new[] {-1, 0}, new[] {0, 1}, new[] {1, 0}};
            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (i == 0 || i == m - 1 || j == 0 || j == n - 1)
                    {
                        q.Push(Tuple.Create(heightMap[i, j], i*n + j));
                        visited.Add(i*n + j);
                    }
                }
            }

            while (q.Count != 0)
            {
                var t = q.Pop();
                int h = t.Item1;
                int r = t.Item2/n;
                int c = t.Item2%n;
                waterLevel = Math.Max(waterLevel, h);
                foreach (var dir in dirs)
                {
                    int x = r + dir[0], y = c + dir[1];
                    if (x < 0 || x >= m || y < 0 || y >= n || visited.Contains(x*n + y))
                    {
                        continue;
                    }
                    visited.Add(x*n + y);
                    if (heightMap[x, y] < waterLevel)
                    {
                        res += waterLevel - heightMap[x, y];
                    }

                    q.Push(Tuple.Create(heightMap[x, y], x*n + y));
                }
            }
            return res;
        }
    }
}
