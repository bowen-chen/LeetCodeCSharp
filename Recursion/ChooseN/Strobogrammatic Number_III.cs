/*
248	Strobogrammatic Number III $
A strobogrammatic number is a number that looks the same when rotated 180 degrees (looked at upside down).

Write a function to count the total strobogrammatic numbers that exist in the range of low <= num <= high.

For example,

Given low = "50", high = "100", return 3. Because 69, 88, and 96 are three strobogrammatic numbers.

Note:

Because the range might be a large number, the low and high numbers are represented as string.
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public int StrobogrammaticInRange(string low, string high)
        {
            int res = 0;
            StrobogrammaticInRange(low, high, "", ref res);
            StrobogrammaticInRange(low, high, "0", ref res);
            StrobogrammaticInRange(low, high, "1", ref res);
            StrobogrammaticInRange(low, high, "8", ref res);
            return res;
        }

        private void StrobogrammaticInRange(string low, string high, string w, ref int res)
        {
            if (w.Length >= low.Length && w.Length <= high.Length)
            {
                if ((w.Length == low.Length && w.CompareTo(low) < 0)
                    || (w.Length == high.Length && w.CompareTo(high) > 0))
                {
                    return;
                }
                if (!(w.Length > 1 && w[0] == '0')) {
                    ++res;
                }
            }

            if (w.Length + 2 > high.Length) {
                return;
            }

            StrobogrammaticInRange(low, high, "0" + w + "0", ref res);
            StrobogrammaticInRange(low, high, "1" + w + "1", ref res);
            StrobogrammaticInRange(low, high, "6" + w + "9", ref res);
            StrobogrammaticInRange(low, high, "8" + w + "8", ref res);
            StrobogrammaticInRange(low, high, "9" + w + "6", ref res);
        }

        public int StrobogrammaticInRange2(string low, string high)
        {
            int count = 0;
            var ret = new List<string>();
            for (int n = low.Length; n <= high.Length; n++)
            {
                ret.AddRange(FindStrobogrammatic2(n));
            }
            foreach (string num in ret)
            {
                if ((num.Length == low.Length && num.CompareTo(low) < 0) 
                    || (num.Length == high.Length && num.CompareTo(high) > 0))
                {
                    continue;
                }
                count++;
            }
            return count;
        }
    }
}
