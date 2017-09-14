/*
373. Find K Pairs with Smallest Sums
You are given two integer arrays nums1 and nums2 sorted in ascending order and an integer k.

Define a pair (u,v) which consists of one element from the first array and one element from the second array.

Find the k pairs (u1,v1),(u2,v2) ...(uk,vk) with the smallest sums.

Example 1:

Given nums1 = [1,7,11], nums2 = [2,4,6],  k = 3

Return: [1,2],[1,4],[1,6]

The first 3 pairs are returned from the sequence:
[1,2],[1,4],[1,6],[7,2],[7,4],[11,2],[7,6],[11,4],[11,6]
 

Example 2:

Given nums1 = [1,1,2], nums2 = [1,2,3],  k = 2

Return: [1,1],[1,1]

The first 2 pairs are returned from the sequence:
[1,1],[1,1],[1,2],[2,1],[1,2],[2,2],[1,3],[1,3],[2,3]
 

Example 3:

Given nums1 = [1,2], nums2 = [3],  k = 3 

Return: [1,3],[2,3]

All possible pairs are returned from the sequence:
[1,3],[2,3]
*/

using System.Collections.Generic;
using Demo.Common;

namespace Demo
{
    public partial class Solution
    {
        public IList<int[]> KSmallestPairs(int[] nums1, int[] nums2, int k)
        {
            var ret = new List<int[]>();
            var q = new PriorityQueue<int[]>(k,
                Comparer<int[]>.Create((a, b) => a[2] - b[2]));

            // build a heap of nums1 + nums2
            // 败者树
            if (nums2.Length > 0)
            {
                for (int i = 0; i < nums1.Length && i < k; i++)
                {
                    q.Push(new[] {i, 0, nums1[i] + nums2[0]});
                }
            }

            while (q.Count != 0 && ret.Count < k)
            {
                var c = q.Pop();
                ret.Add(new [] {nums1[c[0]], nums2[c[1]]});
                if (c[1] + 1 < nums2.Length)
                {
                    q.Push(new[] {c[0], c[1] + 1, nums1[c[0]]+nums2[c[1] + 1]});
                }
            }

            return ret;
        }

        public IList<int[]> KSmallestPairs2(int[] nums1, int[] nums2, int k)
        {
            var res = new List<int[]>();
            int i = 0;
            int j = 0;
            while (res.Count < k && i < nums1.Length && j < nums2.Length)
            {
                res.Add(new[] { nums1[i], nums2[j] });
                if (i == nums1.Length - 1)
                {
                    j++;
                }
                else if (j == nums2.Length - 1)
                {
                    i++;
                }
                else if (nums1[i + 1] + nums2[j] < nums1[i] + nums2[j + 1])
                {
                    i++;
                }
                else
                {
                    j++;
                }
            }

            return res;
        }
    }
}
