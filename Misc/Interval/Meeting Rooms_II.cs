/*
253	Meeting Rooms II $
Given an array of meeting time intervals consisting of start and end times [[s1,e1],[s2,e2],...] (si < ei), find the minimum number of conference rooms required.

For example,
Given [[0, 30],[5, 10],[15, 20]],
return 2.
*/
using Demo.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    public partial class Solution
    {
        public int MinMeetingRooms2(Interval[] intervals)
        {
            var m = new Dictionary<int, int>();
            foreach (var a in intervals)
            {
                if (!m.ContainsKey(a.start))
                {
                    m[a.start] = 0;
                }

                if (!m.ContainsKey(a.end))
                {
                    m[a.end] = 0;
                }

                ++m[a.start];
                --m[a.end];
            }

            int rooms = 0, res = 0;
            foreach (var it in m.OrderBy(kvp=>kvp.Key))
            {
                res = Math.Max(res, rooms += it.Value);
            }

            return res;
        }

        public int MinMeetingRooms(Interval[] intervals)
        {
            if (intervals == null || intervals.Length == 0)
            {
                return 0;
            }

            var pq = new PriorityQueue<int>();
            int ret = 0;
            foreach (var i in intervals.OrderBy(i => i.start))
            {
                while (pq.Count > 0 && pq.Top() <= i.start)
                {
                    pq.Pop();
                }

                pq.Push(i.end);
                ret = Math.Max(ret, pq.Count);
            }
            return ret;
        }
    }
}
