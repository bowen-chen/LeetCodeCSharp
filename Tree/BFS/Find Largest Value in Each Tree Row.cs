/*
515. Find Largest Value in Each Tree Row
You need to find the largest value in each row of a binary tree.

Example:
Input: 

          1
         / \
        3   2
       / \   \  
      5   3   9 

Output: [1, 3, 9]
*/

using System;
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
        public IList<int> LargestValues(TreeNode root)
        {
            var ret = new List<int>();
            if (root == null)
            {
                return ret;
            }

            Queue<TreeNode> q = new Queue<TreeNode>();
            int max = int.MinValue;
            q.Enqueue(root);
            q.Enqueue(null);
            while (q.Count > 0)
            {
                TreeNode n = q.Dequeue();
                if (n == null)
                {
                    ret.Add(max);
                    max = int.MinValue;
                    if (q.Count > 0)
                    {
                        q.Enqueue(null);
                    }
                }
                else
                {;
                    max = Math.Max(max, n.val);
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
