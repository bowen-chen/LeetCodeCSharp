/*
217	Contains Duplicate
Easy
Contains Duplicate

Given an array of integers, find if the array contains any duplicates. Your function should return true if any value appears at least twice in the array, and it should return false if every element is distinct.
*/

using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    public partial class Solution
    {
        public bool ContainsDuplicate(int[] nums)
        {
            var h = new HashSet<int>();
            foreach (var n in nums)
            {
                if (h.Contains(n))
                {
                    return true;
                }

                h.Add(n);
            }
            return false;
        }
    }
}
