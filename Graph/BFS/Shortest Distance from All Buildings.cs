/*
317	Shortest Distance from All Buildings
Shortest Distance from All Buildings
You want to build a house on an empty land which reaches all buildings in the shortest amount of distance. You are given a 2D grid of values 0, 1 or 2, where:

Each 0 marks an empty land which you can pass by freely.
Each 1 marks a building which you cannot pass through.
Each 2 marks an obstacle which you cannot pass through.
The distance is calculated using Manhattan Distance, where distance(p1, p2) = |p2.x - p1.x| + |p2.y - p1.y|.

For example, given three buildings at (0,0), (0,4), (2,2), and an obstacle at (0,2):

    1 - 0 - 2 - 0 - 1
    |   |   |   |   |
    0 - 0 - 0 - 0 - 0
    |   |   |   |   |
    0 - 0 - 1 - 0 - 0
The point (1,2) is an ideal empty land to build a house, as the total travel distance of 3+3+1=7 is minimal. So return 7.

Note:
There will be at least one building. If it is not possible to build such house according to the above rules, return -1.

Hide Company Tags Google Zenefits
Hide Tags Breadth-first Search
Hide Similar Problems (M) Walls and Gates (H) Best Meeting Point
*/
using System;
using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public int ShortestDistance(int[,] grid)
        {
            if (grid == null) return 0;

            var dirs = new[] { new[] { 0, -1 }, new[] { -1, 0 }, new[] { 0, 1 }, new[] { 1, 0 } };

            int row = grid.GetLength(0), col = grid.GetLength(1);
            int[,] distance = new int[row, col];
            int[,] reach = new int[row, col];
            int buildingNum = 0;

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (grid[i, j] == 1)
                    {
                        buildingNum++;
                        var q = new Queue<int[]>();
                        q.Enqueue(new[] {i, j});
                        q.Enqueue(null);

                        bool[,] isVisited = new bool[row, col];
                        int level = 1;
                        while (q.Count != 0)
                        {
                            int[] curr = q.Dequeue();
                            if (curr == null)
                            {
                                if (q.Count != 0)
                                {
                                    q.Enqueue(null);
                                    level++;
                                }
                            }
                            else
                            {
                                foreach (var dir in dirs)
                                {
                                    int nextRow = curr[0] + dir[0];
                                    int nextCol = curr[1] + dir[1];
                                    if (nextRow >= 0 && nextRow < row && nextCol >= 0 && nextCol < col
                                        && grid[nextRow, nextCol] == 0 && !isVisited[nextRow, nextCol])
                                    {
                                        distance[nextRow, nextCol] += level;
                                        reach[nextRow, nextCol]++;
                                        isVisited[nextRow, nextCol] = true;
                                        q.Enqueue(new[] {nextRow, nextCol});
                                    }
                                }
                            }
                        }
                    }
                }
            }

            int shortest = int.MaxValue;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (grid[i, j] == 0 && reach[i, j] == buildingNum)
                    {
                        shortest = Math.Min(shortest, distance[i, j]);
                    }
                }
            }

            return shortest == int.MaxValue ? -1 : shortest;
        }
    }
}