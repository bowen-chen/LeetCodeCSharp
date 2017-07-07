/*
199. Binary Tree Right Side View
easy, tree
Given a binary tree, imagine yourself standing on the right side of it, return the values of the nodes you can see ordered from top to bottom.

For example:
Given the following binary tree,
   1            <---
 /   \
2     3         <---
 \     \
  5     4       <---
You should return [1, 3, 4].
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
        public IList<int> RightSideView(TreeNode root)
        {
            if (root == null)
            {
                return null;
            }

            var ret = new List<int>();
            TreeNode last = null;
            var q = new Queue<TreeNode>();
            q.Enqueue(root);
            q.Enqueue(null);
            while (q.Count !=0)
            {
                var node = q.Dequeue();
                if (node == null)
                {
                    ret.Add(last.val);
                    if (q.Count != 0)
                    {
                        q.Enqueue(null);
                    }
                }
                else
                {
                    last = node;
                    if (last.left != null)
                    {
                        q.Enqueue(last.left);
                    }
                    if (last.right != null)
                    {
                        q.Enqueue(last.right);
                    }
                }
            }
            return ret;
        }
    }
}
