/*
499	The Maze III
There is a ball in a maze with empty spaces and walls. The ball can go through empty spaces by rolling up (u), down (d), left (l) or right (r), but it won't stop rolling until hitting a wall. When the ball stops, it could choose the next direction. There is also a hole in this maze. The ball will drop into the hole if it rolls on to the hole.

Given the ball position, the hole position and the maze, find out how the ball could drop into the hole by moving the shortest distance. The distance is defined by the number of empty spaces traveled by the ball from the start position (excluded) to the hole (included). Output the moving directions by using 'u', 'd', 'l' and 'r'. Since there could be several different shortest ways, you should output the lexicographically smallest way. If the ball cannot reach the hole, output "impossible".

The maze is represented by a binary 2D array. 1 means the wall and 0 means the empty space. You may assume that the borders of the maze are all walls. The ball and the hole coordinates are represented by row and column indexes.

Example 1

Input 1: a maze represented by a 2D array

0 0 0 0 0
1 1 0 0 1
0 0 0 0 0
0 1 0 0 1
0 1 0 0 0

Input 2: ball coordinate (rowBall, colBall) = (4, 3)
Input 3: hole coordinate (rowHole, colHole) = (0, 1)

Output: "lul"
Explanation: There are two shortest ways for the ball to drop into the hole.
The first way is left -> up -> left, represented by "lul".
The second way is up -> left, represented by 'ul'.
Both ways have shortest distance 6, but the first way is lexicographically smaller because 'l' < 'u'. So the output is "lul".


 

Example 2

Input 1: a maze represented by a 2D array

0 0 0 0 0
1 1 0 0 1
0 0 0 0 0
0 1 0 0 1
0 1 0 0 0

Input 2: ball coordinate (rowBall, colBall) = (4, 3)
Input 3: hole coordinate (rowHole, colHole) = (3, 0)
Output: "impossible"
Explanation: The ball cannot reach the hole.


 

Note:

There is only one ball and one hole in the maze.
Both the ball and hole exist on an empty space, and they will not be at the same position initially.
The given maze does not contain border (like the red rectangle in the example pictures), but you could assume the border of the maze are all walls.
The maze contains at least 2 empty spaces, and the width and the height of the maze won't exceed 30.
*/
using System;
using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public string FindShortestWay(int[,] maze, int[] start, int[] hole)
        {
            int m = maze.GetLength(0);
            int n = maze.GetLength(1);
            if (m == 0 || n == 0) return "";
            var dists = new Tuple<int, string>[m, n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    dists[i, j] =  Tuple.Create(int.MaxValue, "");
                }
            }
            var dirs = new[] { new[] { 0, -1 }, new[] { -1, 0 }, new[] { 0, 1 }, new[] { 1, 0 } };
            var ways = new[] {'l', 'u', 'r', 'd'};
            var q = new Queue<int[]>();
            q.Enqueue(start);
            dists[start[0], start[1]] = Tuple.Create(0, "");
            while (q.Count != 0)
            {
                var t = q.Dequeue();
                for(int i=0;i<dirs.Length;i++)
                {
                    var dir = dirs[i];
                    int x = t[0];
                    int y = t[1];
                    int dist = dists[t[0], t[1]].Item1;
                    string path = dists[t[0], t[1]].Item2;
                    while (x >= 0 && x < m && y >= 0 && y < n && maze[x, y] == 0 && !(x == hole[0] && y == hole[1]))
                    {
                        dist++;
                        x += dir[0];
                        y += dir[1];
                    }

                    if (!(x == hole[0] && y == hole[1]))
                    {
                        x -= dir[0];
                        y -= dir[1];
                        dist--;
                    }
                    path +=ways[i];

                    if (dist < dists[x, y].Item1 || path.CompareTo(dists[x, y].Item2) < 0)
                    {
                        dists[x, y] = Tuple.Create(dist, path);
                        if (!(x == hole[0] && y == hole[1]))
                        {
                            q.Enqueue(new[] {x, y});
                        }
                    }
                }
            }
            var res = dists[hole[0], hole[1]];
            return (res.Item1 == int.MaxValue) ? "impossible" : res.Item2;
        }
    }
}
