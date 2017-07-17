/*
349. Intersection of Two Arrays
easy, hashtable
Given two arrays, write a function to compute their intersection.

Example:
Given nums1 = [1, 2, 2, 1], nums2 = [2, 2], return [2].

Note:
Each element in the result must be unique.
The result can be in any order.
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public int[] Intersection(int[] nums1, int[] nums2)
        {
            // Each element in the result must be unique.
            var h = new HashSet<int>();
            foreach (int n in nums1)
            {
                if (!h.Contains(n))
                {
                    h.Add(n);
                }
            }

            var l = new List<int>();
            foreach (int n in nums2)
            {
                if (h.Contains(n))
                {
                    l.Add(n);
                    h.Remove(n);
                }
            }

            return l.ToArray();
        }
    }
}
