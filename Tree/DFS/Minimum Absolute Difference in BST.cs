/*
530. Minimum Absolute Difference in BST
easy
Given a binary search tree with non-negative values, find the minimum absolute difference between values of any two nodes.

Example:

Input:

   1
    \
     3
    /
   2

Output:
1

Explanation:
The minimum absolute difference is 1, which is the difference between 2 and 1 (or between 2 and 3).
*/

using System;

namespace Demo
{
    /**
     * Definition for a binary tree node.
     * public class TreeNode {
     *     public int val;
     *     public TreeNode left;
     *     public TreeNode right;
     *     public TreeNode(int x) { val = x; }
     * }
     */
    public partial class Solution
    {
        public int GetMinimumDifference(TreeNode root)
        {
            int res = int.MaxValue;
            TreeNode pre = null;
            GetMinimumDifference(root, ref pre, ref res);
            return res;
        }
        private void GetMinimumDifference(TreeNode root, ref TreeNode pre, ref int res)
        {
            if (root == null)
            {
                return;
            }

            GetMinimumDifference(root.left, ref pre, ref res);
            if (pre != null)
            {
                res = Math.Min(res, root.val - pre.val);
            }
            pre = root;
            GetMinimumDifference(root.right, ref pre, ref res);
        }
    }
}
