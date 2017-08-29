/*
179	Largest Number
math, medium
Given a list of non negative integers, arrange them such that they form the largest number.

For example, given [3, 30, 34, 5, 9], the largest formed number is 9534330.

Note: The result may be very large, so you need to return a string instead of an integer.
*/

using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo
{
    public partial class Solution
    {
        public string LargestNumber(int[] nums)
        {
            var sb = new StringBuilder();
            foreach (var n in nums.Select(n => n.ToString())
                        .OrderByDescending(n => n, Comparer<string>.Create((s1, s2) => (s1 + s2).CompareTo(s2 + s1))))
            {
                sb.Append(n);
            }
            
            var ret = sb.ToString();
            ret = ret.TrimStart('0');
            return ret == "" ? "0" : ret;
        }
    }
}
