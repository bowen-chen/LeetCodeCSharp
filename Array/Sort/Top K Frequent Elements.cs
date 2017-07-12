/*
347. Top K Frequent Elements
Given a non-empty array of integers, return the k most frequent elements.

For example,
Given [1,1,1,2,2,3] and k = 2, return [1,2].

Note: 
You may assume k is always valid, 1 ≤ k ≤ number of unique elements.
Your algorithm's time complexity must be better than O(n log n), where n is the array's size.
*/

using System.Collections.Generic;
using Demo.Common;

namespace Demo
{
    public partial class Solution
    {
        public IList<int> TopKFrequent(int[] nums, int k)
        {
            var m = new Dictionary<int, int>();
            var q = new PriorityQueue<KeyValuePair<int, int>>(nums.Length,
                Comparer<KeyValuePair<int, int>>.Create((n1, n2) => Comparer<int>.Default.Compare(n1.Value, n2.Value)));
            var res = new List<int>();
            foreach (int a in nums)
            {
                if (!m.ContainsKey(a))
                {
                    m[a] = 0;
                }

                m[a]++;
            }

            foreach (var kvp in m)
            {
                q.Push(kvp);
            }

            for (int i = 0; i < k; ++i)
            {
                res.Add(q.Pop().Key);
            }
            return res;
        }

        public IList<int> TopKFrequent2(int[] nums, int k)
        {
            var m = new Dictionary<int, int>();
            var bucket = new Dictionary<int, List<int>>();
            var res = new List<int>();
            foreach (int a in nums)
            {
                if (!m.ContainsKey(a))
                {
                    m[a] = 0;
                }

                m[a]++;
            }

            foreach (var kvp in m)
            {
                if (!m.ContainsKey(kvp.Value))
                {
                    bucket[kvp.Value] = new List<int>();
                }

                bucket[kvp.Value].Add(kvp.Key);
            }

            // max freq is nums.length
            for (int i = nums.Length; i >= 0; --i)
            {
                if (bucket.ContainsKey(i))
                {
                    foreach (var n in bucket[i])
                    {
                        res.Add(n);
                        if (res.Count == k)
                        {
                            return res;
                        }
                    }
                }
            }

            return res;
        }
    }
}
