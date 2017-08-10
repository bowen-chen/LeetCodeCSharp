/*
490	The Maze
There is a ball in a maze with empty spaces and walls. The ball can go through empty spaces by rolling up, down, left or right, but it won't stop rolling until hitting a wall. When the ball stops, it could choose the next direction.

Given the ball's start position, the destination and the maze, determine whether the ball could stop at the destination.

The maze is represented by a binary 2D array. 1 means the wall and 0 means the empty space. You may assume that the borders of the maze are all walls. The start and destination coordinates are represented by row and column indexes.

Example 1

Input 1: a maze represented by a 2D array

0 0 1 0 0
0 0 0 0 0
0 0 0 1 0
1 1 0 1 1
0 0 0 0 0

Input 2: start coordinate (rowStart, colStart) = (0, 4)
Input 3: destination coordinate (rowDest, colDest) = (4, 4)

Output: true
Explanation: One possible way is : left -> down -> left -> down -> right -> down -> right.

 

Example 2

Input 1: a maze represented by a 2D array

0 0 1 0 0
0 0 0 0 0
0 0 0 1 0
1 1 0 1 1
0 0 0 0 0

Input 2: start coordinate (rowStart, colStart) = (0, 4)
Input 3: destination coordinate (rowDest, colDest) = (3, 2)

Output: false
Explanation: There is no way for the ball to stop at the destination.

 

Note:

There is only one ball and one destination in the maze.
Both the ball and the destination exist on an empty space, and they will not be at the same position initially.
The given maze does not contain border (like the red rectangle in the example pictures), but you could assume the border of the maze are all walls.
The maze contains at least 2 empty spaces, and both the width and height of the maze won't exceed 100.
*/
using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public bool HasPath(int[,] maze, int[] start, int[] destination)
        {
            int m = maze.GetLength(0);
            int n = maze.GetLength(1);
            if (m == 0 || n == 0)
            {
                return true;
            }

            if (start[0] == destination[0] && start[1] == destination[1])
            {
                return true;
            }

            var visited = new bool[m, n];
            var dirs = new[] {new[] {0, -1}, new[] {-1, 0}, new[] {0, 1}, new[] {1, 0}};
            var q = new Queue<int[]>();
            visited[start[0], start[1]] = true;
            q.Enqueue(start);
            while (q.Count != 0)
            {
                var t = q.Dequeue();
                foreach (var dir in dirs)
                {
                    int x = t[0];
                    int y = t[1];
                    while (x >= 0 && x < m && y >= 0 && y < n && maze[x, y] == 0)
                    {
                        x += dir[0];
                        y += dir[1];
                    }

                    x -= dir[0];
                    y -= dir[1];

                    if (!visited[x, y])
                    {
                        if (x == destination[0] && y == destination[1])
                        {
                            return true;
                        }

                        visited[x, y] = true;
                        q.Enqueue(new[] {x, y});
                    }
                }
            }

            return false;
        }
    }
}
