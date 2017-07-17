/*
356	Line Reflection
Given n points on a 2D plane, find if there is such a line parallel to y-axis that reflect the given set of points.

Example 1:
Given points = [[1,1],[-1,1]], return true.

Example 2:
Given points = [[1,1],[-1,-1]], return false.

Follow up:
Could you do better than O(n2)?

Hint:

Find the smallest and largest x-value for all points.
If there is a line then it should be at y = (minX + maxX) / 2.
For each point, make sure that it has a reflected point in the opposite side.
*/

using System;
using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public bool IsReflected(List<Tuple<int, int>> points)
        {
            HashSet<long> m = new HashSet<long>();
            int max = int.MinValue, min = int.MaxValue;
            foreach (var a in points)
            {
                max = Math.Max(max, a.Item1);
                min = Math.Min(min, a.Item1);
                m.Add(a.Item1<<32|a.Item2);
            }

            int dx = (max + min);
            foreach (var a in points)
            {
                int t = dx - a.Item1;
                if (!m.Contains(t<<32|a.Item2))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
