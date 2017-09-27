/*
447. Number of Boomerangs
easy, *
Given n points in the plane that are all pairwise distinct, a "boomerang" is a tuple of points (i, j, k) such that the distance between i and j equals the distance between i and k (the order of the tuple matters).

Find the number of boomerangs. You may assume that n will be at most 500 and coordinates of points are all in the range [-10000, 10000] (inclusive).

Example:
Input:
[[0,0],[1,0],[2,0]]

Output:
2

Explanation:
The two boomerangs are [[1,0],[0,0],[2,0]] and [[1,0],[2,0],[0,0]]
*/
using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public int NumberOfBoomerangs(int[,] points)
        {
            int res = 0;
            for (int i = 0; i < points.GetLength(0); ++i)
            {
                var m = new Dictionary<long, int>();
                for (int j = 0; j < points.GetLength(0); ++j)
                {
                    if (i != j)
                    {
                        long a = (long)points[i,0] - points[j,0];
                        long b = (long)points[i,1] - points[j,1];
                        long dis = a*a + b*b;
                        if (!m.ContainsKey(dis))
                        {
                            m[dis]=0;
                        }

                        m[dis] ++;
                    }
                }

                foreach (var kvp in m)
                {
                    res += kvp.Value * (kvp.Value - 1);
                }
            }

            return res;
        }
    }
}
