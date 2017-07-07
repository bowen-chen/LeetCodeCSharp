/*
110	Balanced Binary Tree
easy, tree
Given a binary tree, determine if it is height-balanced.

For this problem, a height-balanced binary tree is defined as a binary tree in which the depth of the two subtrees of every node never differ by more than 1.
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
        public bool IsBalanced(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }
            int level;
            return IsBalanced(root, out level);
        }

        private bool IsBalanced(TreeNode root, out int depth)
        {
            int ldepth = 0;
            bool leftb = true;
            if (root.left != null)
            {
                leftb = IsBalanced(root.left, out ldepth);
            }

            int rdepth = 0;
            bool rightb = true;
            if (root.right != null)
            {
                rightb = IsBalanced(root.right, out rdepth);
            }

            depth = Math.Max(ldepth, rdepth) + 1;
            return leftb && rightb && Math.Abs(ldepth - rdepth) <= 1;
        }
    }
}
