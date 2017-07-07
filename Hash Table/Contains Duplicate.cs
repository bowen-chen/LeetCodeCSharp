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

        public bool ContainsDuplicate2(int[] nums)
        {
            int? pre = null;
            foreach (int n in nums.OrderBy(n => n))
            {
                if (pre != null && n == pre.Value)
                {
                    return true;
                }
                pre = n;
            }
            return false;
        }

        public bool ContainsDuplicate3(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i+1; j < nums.Length; j++)
                {
                    if (nums[i] == nums[j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
