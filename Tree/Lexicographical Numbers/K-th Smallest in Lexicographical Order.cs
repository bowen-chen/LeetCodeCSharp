/*
440. K-th Smallest in Lexicographical Order
medium
Given integers n and k, find the lexicographically k-th smallest integer in the range from 1 to n.

Note: 1 ≤ k ≤ n ≤ 109.

Example:

Input:
n: 13   k: 2

Output:
10

Explanation:
The lexicographical order is [1, 10, 11, 12, 13, 2, 3, 4, 5, 6, 7, 8, 9], so the second smallest number is 10.
*/

namespace Demo
{
    public partial class Solution
    {
        public int FindKthNumber(int n, int k)
        {
            int curr = 1;
            k = k - 1;
            while (k > 0)
            {
                // Node count under curr subtree include curr
                int childcount = CalCount(n, curr, curr + 1);
                
                // K is not in the curr subtree, move to neighbor subtree
                if (childcount <= k)
                {
                    curr += 1;
                    k -= childcount;
                }
                else // k is in the curr subtree
                {
                    curr *= 10;
                    k -= 1; /*- node*/
                }
            }

            return curr;
        }

        //use long in case of overflow
        public int CalCount(int n, long levelBegin /*inclusive*/, long levelEnd /*exclusive*/)
        {
            long count = 0;
            while (levelBegin <= n)
            {
                if (levelEnd <= n)
                {
                    count += levelEnd - levelBegin;
                }
                else
                {
                    count += n - levelBegin + 1;
                }

                levelBegin *= 10;
                levelEnd *= 10;
            }

            return (int)count;
        }
    }
}
