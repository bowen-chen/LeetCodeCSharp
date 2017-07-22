/*
173	Binary Search Tree Iterator
easy, tree
Implement an iterator over a binary search tree (BST). Your iterator will be initialized with the root node of a BST.

Calling next() will return the next smallest number in the BST.

Note: next() and hasNext() should run in average O(1) time and uses O(h) memory, where h is the height of the tree.
*/

using System.Collections.Generic;

namespace Demo
{
    /**
     * Definition for binary tree
     * public class TreeNode {
     *     public int val;
     *     public TreeNode left;
     *     public TreeNode right;
     *     public TreeNode(int x) { val = x; }
     * }
     */

    public class BSTIterator
    {
        private readonly Stack<TreeNode> s = new Stack<TreeNode>(); 

        public BSTIterator(TreeNode root)
        {
            PushLeft(root);
        }

        /** @return whether we have a next smallest number */
        public bool HasNext()
        {
            return s.Count != 0;
        }

        /** @return the next smallest number */
        public int Next()
        {
            if (!HasNext())
            {
                return 0;
            }

            var n = s.Pop();
            PushLeft(n.right);
            return n.val;
        }

        private void PushLeft(TreeNode root)
        {
            while (root != null)
            {
                s.Push(root);
                root = root.left;
            }
        }
    }

    /**
     * Your BSTIterator will be called like this:
     * BSTIterator i = new BSTIterator(root);
     * while (i.HasNext()) v[f()] = i.Next();
     */
}
