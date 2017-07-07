/*
96	Unique Binary Search Trees
easy, dp
Given n, how many structurally unique BST's (binary search trees) that store values 1...n?

For example,
Given n = 3, there are a total of 5 unique BST's.

   1         3     3      2      1
    \       /     /      / \      \
     3     2     1      1   3      2
    /     /       \                 \
   2     1         2                 3
*/

namespace Demo
{
    public partial class Solution
    {
        public int NumTrees(int n)
        {
            int[] dp = new int[n + 1];
            dp[0] = dp[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                // number of tree node in the left tree
                for (int j = 0; j <= i - 1; j++)
                {
                    dp[i] += dp[j]*dp[i - 1 - j];
                }
            }

            return dp[n];
        }
    }
}
