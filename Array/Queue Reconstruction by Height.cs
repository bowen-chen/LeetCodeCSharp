/*
406	Queue Reconstruction by Height
*
Suppose you have a random list of people standing in a queue. Each person is described by a pair of integers (h, k), where h is the height of the person and k is the number of people in front of this person who have a height greater than or equal to h. Write an algorithm to reconstruct the queue.

Note:
The number of people is less than 1,100.

Example

Input:
[[7,0], [4,4], [7,1], [5,0], [6,1], [5,2]]

Output:
[[5,0], [7,0], [5,2], [6,1], [4,4], [7,1]]
*/

using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    public partial class Solution
    {
        public int[,] ReconstructQueue(int[,] people)
        {
            var ps = new List<int[]>();
            for (int i = 0; i < people.GetLength(0); i++)
            {
                ps.Add(new [] {people[i,0], people[i,1]});
            }

            var ps2 = new List<int[]>();
            foreach (var p in ps.OrderByDescending(p => p[0]).ThenBy(p => p[1]))
            {
                ps2.Insert(p[1], new[] {p[0], p[1]});
            }

            var res = new int[people.GetLength(0), 2];
            for (int i =0;i<ps2.Count;i++)
            {
                res[i,0] = ps2[i][0];
                res[i,1] = ps2[i][1];
            }

            return res;
        }
    }
}
