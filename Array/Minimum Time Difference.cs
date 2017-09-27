/*
539. Minimum Time Difference
*
Given a list of 24-hour clock time points in "Hour:Minutes" format, find the minimum minutes difference between any two time points in the list.

Example 1:
Input: ["23:59","00:00"]
Output: 1
Note:
The number of time points in the given list is at least 2 and won't exceed 20000.
The input time is legal and ranges from 00:00 to 23:59.
*/
namespace Demo
{
    using System;
    using System.Collections.Generic;
    public partial class Solution
    {
        public int FindMinDifference(IList<string> timePoints)
        {
            int res = int.MaxValue;
            int n = timePoints.Count;
            var nums = new List<int>();
            foreach (string str in timePoints)
            {
                int h = int.Parse(str.Substring(0, 2));
                int m = int.Parse(str.Substring(3));
                nums.Add(h * 60 + m);
            }

            nums.Sort();
            for (int i = 1; i < n; ++i)
            {
                res = Math.Min(res, nums[i] - nums[i - 1]);
            }

            return Math.Min(res, 1440 + nums[0] - nums[nums.Count -1]);
        }
    }
}
