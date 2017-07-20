/*
102. Binary Tree Level Order Traversal
easy, tree
Given a binary tree, return the level order traversal of its nodes' values. (ie, from left to right, level by level).

For example:
Given binary tree {3,9,20,#,#,15,7},
    3
   / \
  9  20
    /  \
   15   7
return its level order traversal as:
[
  [3],
  [9,20],
  [15,7]
]
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            IList<IList<int>> ret = new List<IList<int>>();
            if (root == null)
            {
                return ret;
            }

            Queue<TreeNode> q = new Queue<TreeNode>();
            List<int> c = new List<int>();
            q.Enqueue(root);
            q.Enqueue(null);
            while (q.Count > 0)
            {
                TreeNode n = q.Dequeue();
                if (n == null)
                {
                    ret.Add(c);
                    c = new List<int>();
                    if (q.Count> 0)
                    {
                        q.Enqueue(null);
                    }
                }
                else
                {
                    c.Add(n.val);
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

            return ret;
        }
    }
}
