/*
124. Binary Tree Maximum Path Sum
easy, tree, *
Given a binary tree, find the maximum path sum.

For this problem, a path is defined as any sequence of nodes from some starting node to any node in the tree along the parent-child connections. The path does not need to go through the root.

For example:
Given the below binary tree,

       1
      / \
     2   3
Return 6.
*/

using System;

namespace Demo
{
    public partial class Solution
    {
        public int MaxPathSum(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            int temp;
            return MaxPath(root, out temp);
        }


        // return path under this subtree, including path thru this node
        // maxPathToHere max path to this node
        private int MaxPath(TreeNode root, out int maxPathToHere)
        {
            maxPathToHere = 0;
            if (root == null)
            {
                return int.MinValue;
            }

            int fromLeft;
            int underLeft = MaxPath(root.left, out fromLeft);
            int fromRight;
            int underRight = MaxPath(root.right, out fromRight);

            maxPathToHere = root.val + Math.Max(fromLeft, fromRight);
            maxPathToHere = maxPathToHere < 0 ? 0 : maxPathToHere;
            int currentMax = root.val + fromLeft + fromRight;
            return Math.Max(Math.Max(underLeft, underRight), currentMax);
        }
    }
}
