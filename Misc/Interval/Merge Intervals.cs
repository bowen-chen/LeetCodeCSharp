/*
56	Merge Intervals
easy
Given a collection of intervals, merge all overlapping intervals.

For example,
Given [1,3],[2,6],[8,10],[15,18],
return [1,6],[8,10],[15,18].
*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    /**
     * Definition for an interval.
     * public class Interval {
     *     public int start;
     *     public int end;
     *     public Interval() { start = 0; end = 0; }
     *     public Interval(int s, int e) { start = s; end = e; }
     * }
     */
    public partial class Solution
    {
        public IList<Interval> Merge(IList<Interval> intervals)
        {
            if (intervals == null)
            {
                return intervals;
            }

            var ret = new List<Interval>();
            Interval cur = null;
            foreach (var i in intervals.OrderBy(i => i.start))
            {
                if (cur == null || cur.end < i.start)
                {
                    ret.Add(i);
                    cur = i;
                }
                else
                {
                    cur.end = Math.Max(cur.end, i.end);
                }
            }

            return ret;
        }
    }
}
