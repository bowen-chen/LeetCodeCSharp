/*
391. Perfect Rectangle
Given N axis-aligned rectangles where N > 0, determine if they all together form an exact cover of a rectangular region.

Each rectangle is represented as a bottom-left point and a top-right point. For example, a unit square is represented as [1,1,2,2]. (coordinate of bottom-left point is (1, 1) and top-right point is (2, 2)).


Example 1:

rectangles = [
  [1,1,3,3],
  [3,1,4,2],
  [3,2,4,4],
  [1,3,2,4],
  [2,3,3,4]
]

Return true. All 5 rectangles together form an exact cover of a rectangular region.

Example 2:

rectangles = [
  [1,1,2,3],
  [1,3,2,4],
  [3,1,4,2],
  [3,2,4,4]
]

Return false. Because there is a gap between the two rectangular regions.

Example 3:

rectangles = [
  [1,1,3,3],
  [3,1,4,2],
  [1,3,2,4],
  [3,2,4,4]
]

Return false. Because there is a gap in the top center.

Example 4:

rectangles = [
  [1,1,3,3],
  [3,1,4,2],
  [1,3,2,4],
  [2,2,4,4]
]

Return false. Because two of the rectangles overlap with each other.
*/
using System;
using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public bool IsRectangleCover(int[,] rectangles)
        {
            var st = new HashSet<long>();
            int min_x = int.MaxValue, min_y = int.MaxValue, max_x = int.MinValue, max_y = int.MinValue, area = 0;
            for (int i = 0; i < rectangles.GetLength(0); i++)
            {
                min_x = Math.Min(min_x, rectangles[i, 0]);
                min_y = Math.Min(min_y, rectangles[i, 1]);
                max_x = Math.Max(max_x, rectangles[i, 2]);
                max_y = Math.Max(max_y, rectangles[i, 3]);
                area += (rectangles[i, 2] - rectangles[i, 0])*(rectangles[i, 3] - rectangles[i, 1]);
                long s1 = ((long)rectangles[i, 0] << 32) + rectangles[i, 1]; // bottom-left
                long s2 = ((long)rectangles[i, 0] << 32) + rectangles[i, 3]; // top-left
                long s3 = ((long)rectangles[i, 2] << 32) + rectangles[i, 3]; // top-right
                long s4 = ((long)rectangles[i, 2] << 32) + rectangles[i, 1]; // bottom-right
                if (st.Contains(s1)) st.Remove(s1);
                else st.Add(s1);
                if (st.Contains(s2)) st.Remove(s2);
                else st.Add(s2);
                if (st.Contains(s3)) st.Remove(s3);
                else st.Add(s3);
                if (st.Contains(s4)) st.Remove(s4);
                else st.Add(s4);
            }

            long t1 = ((long)min_x << 32) + min_y;
            long t2 = ((long)min_x << 32) + max_y;
            long t3 = ((long)max_x << 32) + max_y;
            long t4 = ((long)max_x << 32) + min_y;
            if (!st.Contains(t1) || !st.Contains(t2) || !st.Contains(t3) || !st.Contains(t4) || st.Count != 4) return false;
            return area == (max_x - min_x) * (max_y - min_y);
        }
    }
}
