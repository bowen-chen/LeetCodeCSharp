/*
270	Closest Binary Search Tree Value
easy, tree
Given a non-empty binary search tree and a target value, find the value in the BST that is closest to the target.

Note: Given target value is a floating point. You are guaranteed to have only one unique value in the BST that is closest to the target.
*/

using System;

namespace Demo
{
    public partial class Solution
    {
        public int ClosestValue(TreeNode root, double target)
        {
            TreeNode kid = target < root.val ? root.left : root.right;
            if (kid == null) return root.val;
            int closest = ClosestValue(kid, target);
            return Math.Abs(root.val - target) < Math.Abs(closest - target) ? root.val : closest;
        }

        public int ClosestValue2(TreeNode root, double target)
        {
            int res = root.val;
            while (root != null)
            {
                if (Math.Abs(res - target) >= Math.Abs(root.val - target))
                {
                    res = root.val;
                }

                root = target < root.val ? root.left : root.right;
            }

            return res;
        }
    }
}
