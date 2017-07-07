/*
149	Max Points on a Line
easy
Given n points on a 2D plane, find the maximum number of points that lie on the same straight line.
*/
using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    public partial class Solution
    {
        public int MaxPoints(Point[] points)
        {
            Dictionary<double, int> hash = new Dictionary<double, int>();
            int ret = 0;
            for (int i = 0; i < points.Length; i++)
            {
                hash.Clear();
                int samepoint = 1;
                for (int j = i + 1; j < points.Length; j++)
                {
                    double slope;
                    bool samex = points[i].x == points[j].x;
                    bool samey = points[i].y == points[j].y;
                    if (samex & samey)
                    {
                        samepoint++;
                        continue;
                    }
                    else if (samex & !samey)
                    {

                        slope = double.MaxValue;
                    }
                    else if (!samex & samey)
                    {
                        slope = 0;
                    }
                    else
                    {
                        slope = (double) (points[j].y - points[i].y)
                                /(points[j].x - points[i].x);
                    }

                    if (hash.ContainsKey(slope))
                    {
                        hash[slope] ++;
                    }
                    else
                    {
                        hash[slope] = 1;
                    }
                }

                int currentMax = (hash.Count == 0 ? 0 : hash.Values.Max()) + samepoint;
                if (ret < currentMax)
                {
                    ret = currentMax;
                }
            }
            return ret;

        }
    }
}
