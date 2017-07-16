/*
421. Maximum XOR of Two Numbers in an Array
Given a non-empty array of numbers, a0, a1, a2, … , an-1, where 0 ≤ ai < 231.

Find the maximum result of ai XOR aj, where 0 ≤ i, j < n.

Could you do this in O(n) runtime?

Example:

Input: [3, 10, 5, 25, 2, 8]

Output: 28

Explanation: The maximum result is 5 ^ 25 = 28.
*/
using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public int FindMaximumXOR(int[] nums)
        {
            int res = 0;
            int mask = 0;

            // from high to low, we test each bit to see if it is possible to be 1
            for (int i = 31; i >= 0; i--)
            {
                mask |= (1 << i);
                var s = new HashSet<int>();
                foreach (int num in nums)
                {
                    s.Add(num & mask);
                }

                // t is next possible max res
                int t = res | (1 << i);
                foreach (int prefix in s)
                {
                    // a= b^c b=a^c
                    if (s.Contains(t ^ prefix))
                    {
                        res = t;
                        break;
                    }
                }
            }

            return res;
        }
    };
}
