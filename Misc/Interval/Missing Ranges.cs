/*
163	Missing Ranges $
Given a sorted integer array where the range of elements are [0, 99] inclusive, return its missing ranges.
For example, given [0, 1, 3, 50, 75], return [“2”, “4->49”, “51->74”, “76->99”]
*/
using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public List<string> FindMissingRanges(int[] vals, int start, int end)
        {
            List<string> ranges = new List<string>();
            int prev = start - 1;
            for (int i = 0; i <= vals.Length; ++i)
            {
                int curr = (i == vals.Length) ? end + 1 : vals[i];
                if (curr - prev >= 2)
                {
                    ranges.Add(getRange(prev + 1, curr - 1));
                }

                prev = curr;
            }

            return ranges;
        }

        private string getRange(int from, int to)
        {
            return (from == to) ? from.ToString() : from + "->" + to;
        }
    }
}
