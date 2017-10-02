/*
653. Two Sum IV - Input is a BST
*
Given a Binary Search Tree and a target number, return true if there exist two elements in the BST such that their sum is equal to the given target.

Example 1:
Input: 
    5
   / \
  3   6
 / \   \
2   4   7

Target = 9

Output: True
Example 2:
Input: 
    5
   / \
  3   6
 / \   \
2   4   7

Target = 28

Output: False
*/

using System.Collections.Generic;

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
        public bool FindTarget(TreeNode root, int k)
        {
            var left = new TreeIterator(root, true);
            var right = new TreeIterator(root, false);

            while (left.Current != right.Current)
            {
                int sum = left.Current.val + right.Current.val;
                if (sum == k)
                {
                    return true;
                }

                if (sum < k)
                {
                    left.MoveNext();
                }
                else
                {
                    right.MoveNext();
                }
            }

            return false;
        }

        private class TreeIterator
        {
            private readonly bool _left;
            private readonly Stack<TreeNode> _s = new Stack<TreeNode>();

            public TreeIterator(TreeNode root, bool left)
            {
                _left = left;
                Push(root);
            }

            private void Push(TreeNode node)
            {
                while (node != null)
                {
                    _s.Push(node);
                    node = _left ? node.left : node.right;
                }
            }

            public TreeNode Current
            {
                get
                {
                    if (_s.Count == 0)
                    {
                        return null;
                    }

                    return _s.Peek();
                }
            }

            public bool MoveNext()
            {
                var node = _s.Pop();
                node = _left ? node.right : node.left;
                Push(node);
                return _s.Count != 0;
            }
        }
    }
}
