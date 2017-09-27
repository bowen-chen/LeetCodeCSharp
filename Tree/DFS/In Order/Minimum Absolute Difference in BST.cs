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
            TreeNode pre = null;
            return GetMinimumDifference(root, ref pre);
        }

        private int GetMinimumDifference(TreeNode root, ref TreeNode pre)
        {
            if (root == null)
            {
                return int.MaxValue;
            }

            var left = GetMinimumDifference(root.left, ref pre);
            int current = int.MaxValue;
            if (pre != null)
            {
                current = root.val - pre.val;
            }
            pre = root;
            var right = GetMinimumDifference(root.right, ref pre);
            return Math.Min(Math.Min(left, current), right);
        }
    }
}
