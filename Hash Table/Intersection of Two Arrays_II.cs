/*
350. Intersection of Two Arrays II
easy, hashtable
Given two arrays, write a function to compute their intersection.

Example:
Given nums1 = [1, 2, 2, 1], nums2 = [2, 2], return [2, 2].

Note:
Each element in the result should appear as many times as it shows in both arrays.
The result can be in any order.
Follow up:
What if the given array is already sorted? How would you optimize your algorithm?
What if nums1's size is small compared to nums2's size? Which algorithm is better?
What if elements of nums2 are stored on disk, and the memory is limited such that you cannot load all elements into the memory at once?
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public int[] Intersection2(int[] nums1, int[] nums2)
        {
            var h = new Dictionary<int, int>();
            foreach (int n in nums1)
            {
                if (!h.ContainsKey(n))
                {
                    h[n] = 0;
                }

                h[n]++;
            }

            var l = new List<int>();
            foreach (int n in nums2)
            {
                if (h.ContainsKey(n))
                {
                    l.Add(n);
                    if (--h[n] == 0)
                    {
                        h.Remove(n);
                    }
                }
            }

            return l.ToArray();
        }
    }
}
