/*
103. Binary Tree Zigzag Level Order Traversal
easy, tree
Given a binary tree, return the zigzag level order traversal of its nodes' values. (ie, from left to right, then right to left for the next level and alternate between).

For example:
Given binary tree {3,9,20,#,#,15,7},
    3
   / \
  9  20
    /  \
   15   7
return its zigzag level order traversal as:
[
  [3],
  [20,9],
  [15,7]
]
confused what "{1,#,2,3}" means? > read more on how binary tree is serialized on OJ.
*/
using System.Collections.Generic;
using System.Linq;

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
        public void Test_ZigzagLevelOrder()
        {
            ZigzagLevelOrder(new TreeNode(1));
        }

        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            var ret = new List<IList<int>>();
            if (root == null)
            {
                return ret;
            }
            var q = new Queue<TreeNode>();
            q.Enqueue(root);
            q.Enqueue(null);
            ret.Add(new List<int>());
            int level = 0;
            while (q.Count != 0)
            {
                var n = q.Dequeue();
                if (n == null)
                {
                    if (q.Count != 0)
                    {
                        q.Enqueue(null);
                        ret.Add(new List<int>());
                        level++;
                    }
                }
                else
                {
                    if (level%2 == 0)
                    {
                        ret[ret.Count - 1].Add(n.val);
                    }
                    else
                    {
                        ret[ret.Count - 1].Insert(0, n.val);
                    }

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

        public IList<IList<int>> ZigzagLevelOrder2(TreeNode root)
        {
            var sol = new List<IList<int>>();
            travel(root, sol, 0);
            return sol;
        }

        private void travel(TreeNode curr, IList<IList<int>> sol, int level)
        {
            if (curr == null) return;

            if (sol.Count <= level)
            {
                List<int> newLevel = new List<int>();
                sol.Add(newLevel);
            }

            IList<int> collection = sol[level];
            if (level%2 == 0)
            {
                collection.Add(curr.val);
            }
            else
            {
                collection.Insert(0, curr.val);
            }

            travel(curr.left, sol, level + 1);
            travel(curr.right, sol, level + 1);
        }
    }
}
