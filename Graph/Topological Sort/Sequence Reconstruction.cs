/*
444	Sequence Reconstruction
easy
Check whether the original sequence org can be uniquely reconstructed from the sequences in seqs. The org sequence is a permutation of the integers from 1 to n, with 1 ≤ n ≤ 104. Reconstruction means building a shortest common supersequence of the sequences in seqs (i.e., a shortest sequence so that all sequences in seqs are subsequences of it). Determine whether there is only one sequence that can be reconstructed from seqs and it is the org sequence.

Example 1:

Input:
org: [1,2,3], seqs: [[1,2],[1,3]]

Output:
false

Explanation:
[1,2,3] is not the only one sequence that can be reconstructed, because [1,3,2] is also a valid sequence that can be reconstructed.
Example 2:

Input:
org: [1,2,3], seqs: [[1,2]]

Output:
false

Explanation:
The reconstructed sequence can only be [1,2].
Example 3:

Input:
org: [1,2,3], seqs: [[1,2],[1,3],[2,3]]

Output:
true

Explanation:
The sequences [1,2], [1,3], and [2,3] can uniquely reconstruct the original sequence [1,2,3].
Example 4:

Input:
org: [4,1,5,2,6,3], seqs: [[5,2,6,3],[4,1,5,2]]

Output:
true
*/

using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    public partial class Solution
    {
        public bool SequenceReconstruction(int[] org, int[][] seqs)
        {
            var i = new Dictionary<int, int>();
            var o = new Dictionary<int, ISet<int>>();
            foreach (var s in seqs)
            {
                if (!i.ContainsKey(s[0]))
                {
                    i.Add(s[0], 0);
                }

                if (!o.ContainsKey(s[0]))
                {
                    o.Add(s[0], new HashSet<int>());
                }

                // dedup
                if (!o[s[0]].Contains(s[1]))
                {
                    o[s[0]].Add(s[1]);
                    i[s[1]]++;
                }
            }

            var q = new Queue<int>();
            foreach (var p in i.Where(kv => kv.Value == 0))
            {
                q.Enqueue(p.Key);
            }

            int index = 0;
            while (q.Count != 0)
            {
                // should be only one possible char
                if (q.Count != 1)
                {
                    return false;
                }

                var c = q.Dequeue();
                if (c != org[index++])
                {
                    return false;
                }

                foreach (var n in o[c])
                {
                    if (--i[n] == 0)
                    {
                        q.Enqueue(n);
                    }
                }
            }

            return index == org.Length;
        }
    }
}
