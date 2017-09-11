/*
352. Data Stream as Disjoint Intervals
easy, *
Given a data stream input of non-negative integers a1, a2, ..., an, ..., summarize the numbers seen so far as a list of disjoint intervals.

For example, suppose the integers from the data stream are 1, 3, 7, 2, 6, ..., then the summary will be:

[1, 1]
[1, 1], [3, 3]
[1, 1], [3, 3], [7, 7]
[1, 3], [7, 7]
[1, 3], [6, 7]
Follow up:
What if there are lots of merges and the number of disjoint intervals are small compared to the data stream's size?
*/

using System;
using System.Collections.Generic;

namespace Demo
{
    /**
     * Definition for an interval.
     * struct Interval {
     *     int start;
     *     int end;
     *     Interval() : start(0), end(0) {}
     *     Interval(int s, int e) : start(s), end(e) {}
     * };
     */
    public class SummaryRanges
    {
        private List<Interval> list = new List<Interval>();

        public void AddNum(int val)
        {
            Interval newInterval = new Interval(val, val);
            List<Interval> res = new List<Interval>();
            bool notadd = true;
            foreach (var a in list)
            {
                // cur is before a
                if (newInterval.end < a.start -1)
                {
                    if (notadd)
                    {
                        res.Add(newInterval);
                        notadd = false;
                    }

                    res.Add(a);
                }
                // cur is after a
                else if (a.end + 1 < newInterval.start)
                {
                    res.Add(a);
                }
                else
                {
                    if (notadd)
                    {
                        res.Add(newInterval);
                        notadd = false;
                    }

                    // cur is overlap with a
                    // a.start-1 <= cur.end
                    // a.end >=cur.start-1
                    newInterval.start = Math.Min(newInterval.start, a.start);
                    newInterval.end = Math.Max(newInterval.end, a.end);
                }
            }

            if (notadd)
            {
                res.Add(newInterval);
            }

            list = res;
        }

        public List<Interval> GetIntervals()
        {
            return list;
        }
    };

    /**
     * Your SummaryRanges object will be instantiated and called as such:
     * SummaryRanges obj = new SummaryRanges();
     * obj.addNum(val);
     * vector<Interval> param_2 = obj.getIntervals();
     */
}
