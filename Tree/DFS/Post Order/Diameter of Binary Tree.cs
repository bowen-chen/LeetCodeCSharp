/*
543. Diameter of Binary Tree
easy， *
Given a binary tree, you need to compute the length of the diameter of the tree. The diameter of a binary tree is the length of the longest path between any two nodes in a tree. This path may or may not pass through the root.

Example:
Given a binary tree 
          1
         / \
        2   3
       / \     
      4   5    
Return 3, which is the length of the path [4,2,1,3] or [5,2,1,3].

Note: The length of path between two nodes is represented by the number of edges between them.
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
        public int DiameterOfBinaryTree(TreeNode root)
        {
            int len = 0;
            return DiameterOfBinaryTree(root, out len);
        }
        public int DiameterOfBinaryTree(TreeNode node, out int len)
        {
            if (node == null)
            {
                len = 0;
                return 0;
            }

            int leftLen;
            var left = DiameterOfBinaryTree(node.left, out leftLen);
            int rightLen;
            var right = DiameterOfBinaryTree(node.right, out rightLen);
            len = Math.Max(leftLen, rightLen) + 1;
            return Math.Max(Math.Max(left, right), leftLen + rightLen);
        }
    }
}
