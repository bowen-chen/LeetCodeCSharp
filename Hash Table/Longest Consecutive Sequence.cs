/*
128. Longest Consecutive Sequence
hard, double link
Given an unsorted array of integers, find the length of the longest consecutive elements sequence.

For example,
Given [100, 4, 200, 1, 3, 2],
The longest consecutive elements sequence is [1, 2, 3, 4]. Return its length: 4.

Your algorithm should run in O(n) complexity.
*/

using System;
using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public int LongestConsecutive3(int[] nums)
        {
            int res = 0;
            // the longest sequence start/end at i
            // We only keept the start and end of the sequence accurate
            var m = new Dictionary<int, int>();
            foreach (int d in nums)
            {
                if (!m.ContainsKey(d))
                {
                    int left = m.ContainsKey(d - 1) ? m[d - 1] : 0;
                    int right = m.ContainsKey(d + 1) ? m[d + 1] : 0;
                    int sum = left + right + 1;
                    m[d] = sum;
                    res = Math.Max(res, sum);
                    m[d - left] = sum;
                    m[d + right] = sum;
                }
            }
            return res;
        }

        public int LongestConsecutive(int[] nums)
        {
            // Use a hashtable as a linklist loop. value is the head of the seq.
            // For head the value is tail
            Dictionary<int, int> seq = new Dictionary<int, int>();

            foreach (int i in nums)
            {
                if (seq.ContainsKey(i))
                {
                    continue;
                }

                seq.Add(i, i); // First link it to itself

                if (seq.ContainsKey(i - 1))
                {
                    // Numbers before v exists, append
                    // itself as new tail
                    int head = seq[i - 1];
                    seq[i] = head; // Update seq's head
                    seq[head] = i; // Update seq's tail
                }

                if (seq.ContainsKey(i + 1))
                {
                    // Numbers after v exists, join
                    // 2 linklists
                    int tail = seq[i + 1]; // Find out the tail
                    int head = seq[i];
                    seq[tail] = head; // Update next seq's tail
                    seq[head] = tail; // Update head's tail
                }
            }

            int maxdiff = 0;
            foreach (var entry in seq)
            {
                if (entry.Value - entry.Key > maxdiff)
                {
                    maxdiff = entry.Value - entry.Key;
                }
            }

            return maxdiff + 1;
        }

        private class DoubleLink
        {
            public int Pre { get; set; }

            public int Next { get; set; }
        }

        // Easy to understand Version
        public int LongestConsecutive2(int[] nums)
        {
            // Use a hashtable as a double loop linklist.
            Dictionary<int, DoubleLink> seq = new Dictionary<int, DoubleLink>();

            foreach (int i in nums)
            {
                if (seq.ContainsKey(i))
                {
                    continue;
                }

                seq.Add(i, new DoubleLink
                {
                    Pre = i,
                    Next = i
                }); // First link it to itself

                if (seq.ContainsKey(i - 1))
                {
                    // Numbers before v exists, append
                    // itself as new tail
                    seq[i].Pre = i - 1;
                    seq[i].Next = seq[i - 1].Next; 
                    seq[seq[i - 1].Next].Pre = i;
                    seq[i - 1].Next = i;
                }

                if (seq.ContainsKey(i + 1))
                {
                    // Numbers after v exists, join
                    // 2 linklists
                    seq[seq[i].Next].Pre = seq[i + 1].Pre;
                    seq[seq[i + 1].Pre].Next = seq[i].Next;
                    seq[i].Next = i + 1;
                    seq[i + 1].Pre = i;
                }
            }

            int maxdiff = 0;
            foreach (var entry in seq)
            {
                if (entry.Value.Pre - entry.Key > maxdiff)
                {
                    maxdiff = entry.Value.Pre - entry.Key;
                }
            }

            return maxdiff + 1;
        }
    }
}
