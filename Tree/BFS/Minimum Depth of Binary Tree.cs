/*
111. Minimum Depth of Binary Tree
easy, bfs
Given a binary tree, find its minimum depth.

The minimum depth is the number of nodes along the shortest path from the root node down to the nearest leaf node.
*/

using System;
using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public int MinDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            if (root.right == null && root.left == null)
            {
                return 1;
            }

            int left = root.left == null ? int.MaxValue : MinDepth(root.left);
            int right = root.right == null ? int.MaxValue : MinDepth(root.right);

            return Math.Min(left, right) + 1;
        }

        public int MinDepth2(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            Queue<TreeNode> queue = new Queue<TreeNode>();
            TreeNode mark = new TreeNode(0);
            queue.Enqueue(root);
            queue.Enqueue(mark);
            int level = 1;
            while (queue.Count > 1 || queue.Peek() == mark)
            {
                TreeNode n = queue.Dequeue();
                if (n == mark)
                {
                    queue.Enqueue(mark);
                    level++;
                }
                else if (n.left == null && n.right == null)
                {
                    return level;
                }
                else
                {
                    if (n.left != null)
                    {
                        queue.Enqueue(n.left);
                    }
                    if (n.right != null)
                    {
                        queue.Enqueue(n.right);
                    }
                }
            }
            return 0;
        }
    }
}