/*
285	Inorder Successor in BST
medium
Problem Description:

Given a binary search tree and a node in it, find the in-order successor of that node in the BST.

Note: If the given node has no in-order successor in the tree, return null.
*/

namespace Demo
{
    public partial class Solution
    {
        public TreeNode InOrderSuccessor2(TreeNode root, TreeNode p)
        {
            // succ pointing to the successor of root subtree.
            TreeNode succ = null;
            while (root != null)
            {
                if (p.val < root.val)
                {
                    succ = root;
                    root = root.left;
                }
                else
                {
                    root = root.right;
                }
            }

            return succ;
        }

        public TreeNode InOrderSuccessor(TreeNode root, TreeNode p)
        {
            if (root == null)
            {
                return null;
            }

            if (root.val <= p.val)
            {
                return InOrderSuccessor(root.right, p);
            }
            else
            {
                TreeNode left = InOrderSuccessor(root.left, p);
                return (left != null) ? left : root;
            }
        }

        public TreeNode InOrderPredecessor(TreeNode root, TreeNode p)
        {
            if (root == null)
            {
                return null;
            }

            if (root.val >= p.val)
            {
                return InOrderPredecessor(root.left, p);
            }
            else
            {
                TreeNode right = InOrderPredecessor(root.right, p);
                return right ?? root;
            }
        }
    }
}
