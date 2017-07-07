/*
564. Find the Closest Palindrome

Given an integer n, find the closest integer (not including itself), which is a palindrome.

The 'closest' is defined as absolute difference minimized between two integers.

Example 1:

Input: "123"
Output: "121"
Note:

The input n is a positive integer represented by string, whose length will not exceed 18.
If there is a tie, return the smaller one as answer.
*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    public partial class Solution
    {
        public int NearestPalindromic(int n)
        {
            // when n is not palidromic, return mid+rev(mid)
            // when n is palidromic, return (mid-1)+ rev((mid-1))
            // When overflow, 100001 or 99999
            string sn = n.ToString();
            var len = sn.Length;
            // we put all cadicate in s
            var s = new HashSet<string>();
            s.Add("1" + new string(Enumerable.Repeat('0', len - 1).ToArray()) + "1");
            if (len > 1)
            {
                s.Add(new string(Enumerable.Repeat('9', len  - 1).ToArray()));
            }

            int mid = int.Parse(sn.Substring(0, (len + 1)/2));
            int skip = len%2;
            s.Add(mid + new string(mid.ToString().Reverse().Skip(skip).ToArray()));
            s.Add((mid+1) + new string((mid+1).ToString().Reverse().Skip(skip).ToArray()));
            s.Add((mid-1) + new string((mid-1).ToString().Reverse().Skip(skip).ToArray()));
            s.Remove(sn);
            int res = 0;
            int diff = Math.Abs(n-res);
            foreach (var c in s)
            {
                int ic = int.Parse(c);
                int icdiff= Math.Abs(n - ic);
                if (diff > icdiff)
                {
                    res = ic;
                    diff = icdiff;
                }
                else if (diff == icdiff && ic < res)
                {
                    res = ic;
                }
            }
            return res;
        }
    }
}
