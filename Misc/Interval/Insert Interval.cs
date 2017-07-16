/*
57	Insert Interval
easy
Given a set of non-overlapping intervals, insert a new interval into the intervals (merge if necessary).

You may assume that the intervals were initially sorted according to their start times.

Example 1:
Given intervals [1,3],[6,9], insert and merge [2,5] in as [1,5],[6,9].

Example 2:
Given [1,2],[3,5],[6,7],[8,10],[12,16], insert and merge [4,9] in as [1,2],[3,10],[12,16].

This is because the new interval [4,9] overlaps with [3,5],[6,7],[8,10].
*/
using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

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
        public IList<Interval> Insert(IList<Interval> intervals, Interval newInterval)
        {
            var ret = new List<Interval>();
            bool notadd = true;
            foreach (Interval interval in intervals)
            {
                // before
                if (newInterval.end < interval.start)
                {
                    if (notadd)
                    {
                        ret.Add(newInterval);
                        notadd = false;
                    }

                    ret.Add(interval);
                }
                // after
                else if (newInterval.start > interval.end)
                {
                    ret.Add(interval);
                }
                // merge
                else
                {
                    newInterval.start = Math.Min(newInterval.start, interval.start);
                    newInterval.end = Math.Min(newInterval.end, interval.end);
                    if (notadd)
                    {
                        ret.Add(newInterval);
                        notadd = false;
                    }
                }
            }

            if (notadd)
            {
                ret.Add(newInterval);
            }

            return ret;
        }
    }
}
