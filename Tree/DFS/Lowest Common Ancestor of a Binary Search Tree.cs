﻿/*
235	Lowest Common Ancestor of a Binary Search Tree
easy, tree, dfs
Lowest Common Ancestor of a Binary Search Tree

Given a binary search tree (BST), find the lowest common ancestor (LCA) of two given nodes in the BST.

According to the definition of LCA on Wikipedia: “The lowest common ancestor is defined between two nodes v and w as the lowest node in T that has both v and w as descendants (where we allow a node to be a descendant of itself).”

        _______6______
       /              \
    ___2__          ___8__
   /      \        /      \
   0      _4       7       9
         /  \
         3   5
For example, the lowest common ancestor (LCA) of nodes 2 and 8 is 6. Another example is LCA of nodes 2 and 4 is 2, since a node can be a descendant of itself according to the LCA definition.
*/

namespace Demo
{
    public partial class Solution
    {
        public TreeNode LowestCommonAncestor4(TreeNode root, TreeNode p, TreeNode q)
        {
            if (p.val < root.val && q.val < root.val)
            {
                return LowestCommonAncestor4(root.left, p, q);
            }

            if (p.val > root.val && q.val > root.val)
            {
                return LowestCommonAncestor4(root.right, p, q);
            }

            return root;
        }
        public TreeNode LowestCommonAncestor3(TreeNode root, TreeNode p, TreeNode q)
        {
            if (p.val > q.val)
            {
                var temp = p;
                p = q;
                q = temp;
            }

            return LowestCommonAncestor32(root, p, q);
        }

        public TreeNode LowestCommonAncestor32(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null)
            {
                return null;
            }

            if (root.val >= p.val && root.val <= q.val)
            {
                return root;
            }

            return LowestCommonAncestor32(root.left, p, q) ?? LowestCommonAncestor32(root.right, p, q);
        }
    }
}