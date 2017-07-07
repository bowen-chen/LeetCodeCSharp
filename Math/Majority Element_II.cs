/*
229	Majority Element II
medium, math, voting
Majority Element II

Given an integer array of size n, find all elements that appear more than ⌊ n/3 ⌋ times. The algorithm should run in linear time and in O(1) space.

Hint:

How many majority elements could it possibly have?
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public IList<int> MajorityElement3(int[] nums)
        {
            int y = 0, z = 0, cy = 0, cz = 0;
            foreach (int x in nums)
            {
                if (x == y)
                {
                    cy++;
                }
                else if (x == z)
                {
                    cz++;
                }
                else if (cy == 0)
                {
                    y = x;
                    cy = 1;
                }
                else if (cz == 0)
                {
                    z = x;
                    cz = 1;
                }
                else
                {
                    cy--;
                    cz--;
                }
            }

            cy = 0;
            cz = 0;
            foreach (int x in nums)
            {
                if (x == y)
                {
                    cy++;
                }
                else if (x == z)
                {
                    cz++;
                }
            }

            var r = new List<int>();
            if (cy > nums.Length/3) r.Add(y);
            if (cz > nums.Length/3) r.Add(z);
            return r;
        }
    }
}
