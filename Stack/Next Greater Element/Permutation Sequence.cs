/*
60	Permutation Sequence
hard, math
The set[1, 2, 3,…, n] contains a total of n! unique permutations.

  By listing and labeling all of the permutations in order,
  We get the following sequence (ie, for n = 3):

"123"
"132"
"213"
"231"
"312"
"321"
Given n and k, return the kth permutation sequence.

Note: Given n will be between 1 and 9 inclusive.
*/

using System.Collections.Generic;
using System.Text;

namespace Demo
{
    public partial class Solution
    {
        public string GetPermutation(int n, int k)
        {
            // n!
            // Total sub number per number at i;
            int[] numPer = {0, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880};
            var l = new List<int>();
            for (int i = 1; i < n + 1; i++)
            {
                l.Add(i);
            }

            var s = new StringBuilder();
            for (int i = n; i > 1; i--)
            {
                // subtract 1 because of things always starting at 0
                int first = (k - 1) / numPer[i - 1];
                k = k - first * numPer[i - 1];
                s.Append(l[first]);
                l.RemoveAt(first);
            }

            s.Append(l[0]);
            return s.ToString();
        }
    }
}
