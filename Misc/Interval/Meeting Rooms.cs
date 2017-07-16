/*
252	Meeting Rooms $
easy
Given an array of meeting time intervals consisting of start and end times [[s1,e1],[s2,e2],...] (si < ei), determine if a person could attend all meetings.

For example,
Given [[0, 30],[5, 10],[15, 20]],
return false. 
 */
using System.Linq;

namespace Demo
{
    public partial class Solution
    {
        // no overlap
        public bool CanAttendMeetings(Interval[] intervals)
        {
            if (intervals == null)
            {
                return false;
            }

            intervals = intervals.OrderBy(i => i.start).ToArray();
            for (int i = 1; i < intervals.Length; i++)
            {
                if (intervals[i].start < intervals[i - 1].end)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
