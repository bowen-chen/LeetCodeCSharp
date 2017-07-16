/*
easy
  
Given two arrays/Lists (choose whatever you want to) with sorted and non intersecting intervals. Merge them to get a new sorted non intersecting array/list. 

Eg: 
Given: 
Arr1 = [3-11, 17-25, 58-73]; 
Arr2 = [6-18, 40-47]; 

Wanted: 
Arr3 = [3-25, 40-47, 58-73];
*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    public partial class Solution
    {
        public IList<Interval> Merge(IList<Interval> intervals1, IList<Interval> intervals2)
        {
            var ret = new List<Interval>();
            Interval cur = null;
            intervals1 = intervals1.OrderBy(a => a.start).ToList();
            intervals2 = intervals2.OrderBy(a => a.start).ToList();
            int i = 0;
            int j = 0;
            while (i < intervals1.Count || j < intervals2.Count)
            {
                Interval m;
                if (i < intervals1.Count && j < intervals2.Count)
                {
                    m = intervals1[i].start <= intervals2[j].start ? intervals1[i++] : intervals2[j++];
                }
                else
                {
                    m = i < intervals1.Count ? intervals1[i++] : intervals2[j++];
                }

                if (cur == null || cur.end < m.start)
                {
                    ret.Add(m);
                    cur = m;
                }
                else
                {
                    cur.end = Math.Max(cur.end, m.end);
                }
            }
            return ret;
        }
    }
}
