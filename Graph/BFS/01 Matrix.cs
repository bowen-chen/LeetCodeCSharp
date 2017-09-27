/*
542. 01 Matrix
*
Given a matrix consists of 0 and 1, find the distance of the nearest 0 for each cell.

The distance between two adjacent cells is 1.
Example 1: 
Input:

0 0 0
0 1 0
0 0 0
Output:
0 0 0
0 1 0
0 0 0
Example 2: 
Input:

0 0 0
0 1 0
1 1 1
Output:
0 0 0
0 1 0
1 2 1
Note:
The number of elements of the given matrix will not exceed 10,000.
There are at least one 0 in the given matrix.
The cells are adjacent in only four directions: up, down, left and right.
*/

using System;
using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public int[,] UpdateMatrix(int[,] matrix)
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);

            var dirs = new[] {new[] {0, -1}, new[] {-1, 0}, new[] {0, 1}, new[] {1, 0}};
            var q = new Queue<int[]>();
            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (matrix[i, j] == 0)
                    {
                        q.Enqueue(new[] {i, j});
                    }
                    else
                    {
                        matrix[i, j] = int.MaxValue;
                    }
                }
            }

            int level = 0;
            while (q.Count != 0)
            {
                level++;
                int count = q.Count;
                for (int i = 0; i < count; i++)
                {

                    var t = q.Dequeue();
                    foreach (var dir in dirs)
                    {
                        int x = t[0] + dir[0];
                        int y = t[1] + dir[1];
                        if (x < 0 || x >= m || y < 0 || y >= n)
                        {
                            continue;
                        }
                        if (matrix[x, y] == int.MaxValue)
                        {
                            matrix[x, y] = level;
                            q.Enqueue(new[] { x, y });
                        }
                    }
                }
            }
            return matrix;
        }

            return matrix;
        }
    }
}
