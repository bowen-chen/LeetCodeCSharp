/*
149	Max Points on a Line
easy
Given n points on a 2D plane, find the maximum number of points that lie on the same straight line.
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    public partial class Solution
    {
        public int MaxPoints(Point[] points)
        {
            int ret = 0;
            for (int i = 0; i < points.Length; i++)
            {
                var hash = new Dictionary<long, int>();
                int samepoint = 1;
                for (int j = i + 1; j < points.Length; j++)
                {
                    bool samex = points[i].x == points[j].x;
                    bool samey = points[i].y == points[j].y;
                    if (samex && samey)
                    {
                        samepoint++;
                        continue;
                    }

                    long y = points[j].y - points[i].y;
                    long x = points[j].x - points[i].x;
                    var sign = y != 0 && x != 0 && (y > 0) ^ (x > 0);
                    y = Math.Abs(y);
                    x = Math.Abs(x);
                    long gcd = this.gcd(y, x);
                    y = y/gcd;
                    x = x/gcd;
                    var slope = y << 32 | x;
                    slope = sign ? -slope : slope;

                    if (!hash.ContainsKey(slope))
                    {
                        hash[slope]=0;
                    }

                    hash[slope]++;
                }

                int currentMax = (hash.Count == 0 ? 0 : hash.Values.Max()) + samepoint;
                if (ret < currentMax)
                {
                    ret = currentMax;
                }
            }

            return ret;
        }

        private long gcd(long x, long y)
        {
            return y == 0 ? x : gcd(y, x % y);
        }
    }
}
