/*
246	Strobogrammatic Number $
A strobogrammatic number is a number that looks the same when rotated 180 degrees (looked at upside down).

Write a function to determine if a number is strobogrammatic. The number is represented as a string.

For example, the numbers "69", "88", and "818" are all strobogrammatic.
*/

namespace Demo
{
    public partial class Solution
    {
        private static readonly char[] StrobogrammaticMap =
            //            0,   1,   2,   3,   4,   5,   6,   7,   8,   6
            new char[] { '0', '1', 'x', 'x', 'x', 'x', '9', 'x', '8', '9' };
        public bool isStrobogrammatic(string num)
        {
            int l = 0, r = num.Length - 1;
            while (l <= r)
            {
                if (StrobogrammaticMap[num[l] - '0'] != num[r])
                {
                    return false;
                }
                l++;
                r--;
            }
            return true;
        }
    }
}
