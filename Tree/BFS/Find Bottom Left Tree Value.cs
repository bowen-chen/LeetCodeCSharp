/*
513. Find Bottom Left Tree Value
*
Given a binary tree, find the leftmost value in the last row of the tree.

Example 1:
Input:

    2
   / \
  1   3

Output:
1
Example 2: 
Input:

        1
       / \
      2   3
     /   / \
    4   5   6
       /
      7

Output:
7
Note: You may assume the tree (i.e., the given root node) is not NULL.
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
        public int FindBottomLeftValue(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            int res = root.val;
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            q.Enqueue(null);
            while (q.Count > 0)
            {
                TreeNode n = q.Dequeue();
                if (n == null)
                {
                    if (q.Count > 0)
                    {
                        res = q.Peek().val;
                        q.Enqueue(null);
                    }
                }
                else
                {
                    if (n.left != null)
                    {
                        q.Enqueue(n.left);
                    }

                    if (n.right != null)
                    {
                        q.Enqueue(n.right);
                    }
                }
            }

            return res;
        }

        public int FindBottomLeftValue2(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            int max = 1, res = root.val;
            FindBottomLeftValue2(root, 1, ref max, ref res);
            return res;
        }
        private void FindBottomLeftValue2(TreeNode node, int depth, ref int max, ref int res)
        {
            if (node == null)
            {
                return;
            }

            if (depth > max)
            {
                max = depth;
                res = node.val;
            }

            FindBottomLeftValue2(node.left, depth + 1, ref max, ref res);
            FindBottomLeftValue2(node.right, depth + 1, ref max, ref res);
        }
    }
}
