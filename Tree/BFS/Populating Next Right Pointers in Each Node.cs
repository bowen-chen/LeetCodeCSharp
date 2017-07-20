/*
116. Populating Next Right Pointers in Each Node
easy, tree
Given a binary tree

    struct TreeLinkNode
{
    TreeLinkNode* left;
    TreeLinkNode* right;
    TreeLinkNode* next;
}
Populate each next pointer to point to its next right node.If there is no next right node, the next pointer should be set to NULL.

Initially, all next pointers are set to NULL.

Note:

You may only use constant extra space.
You may assume that it is a perfect binary tree(ie, all leaves are at the same level, and every parent has two children).
For example,
Given the following perfect binary tree,
         1
       /  \
      2    3
     / \  / \
    4  5  6  7
After calling your function, the tree should look like:
         1 -> NULL
       /  \
      2 -> 3 -> NULL
     / \  / \
    4->5->6->7 -> NULL
*/

using System.Collections.Generic;

namespace Demo
{
    public class TreeLinkNode
    {
        public TreeLinkNode next;
        public TreeLinkNode left;
        public TreeLinkNode right;
    }

    public partial class Solution
    {
        public void Connect(TreeLinkNode root)
        {
            TreeLinkNode level_start = root;
            while (level_start != null)
            {
                TreeLinkNode cur = level_start;
                while (cur != null)
                {
                    if (cur.left != null)
                    {
                        cur.left.next = cur.right;
                    }

                    if (cur.right != null && cur.next != null)
                    {
                        cur.right.next = cur.next.left;
                    }

                    cur = cur.next;
                }

                level_start = level_start.left;
            }
        }

        public void Connect2(TreeLinkNode root)
        {
            if (root == null)
            {
                return;
            }

            Queue<TreeLinkNode> q = new Queue<TreeLinkNode>();
            q.Enqueue(root);
            q.Enqueue(null);
            TreeLinkNode pre = null;
            while (q.Count > 0)
            {
                TreeLinkNode n = q.Dequeue();
                if (pre != null)
                {
                    pre.next = n;
                }

                pre = n;

                if (n == null)
                {
                    if (q.Count > 0)
                    {
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
        }
    }
}
