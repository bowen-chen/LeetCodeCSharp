/*
314	Binary Tree Vertical Order Traversal
easy, tree
Given a binary tree, return the vertical order traversal of its nodes' values. (ie, from top to bottom, column by column).

If two nodes are in the same row and column, the order should be from left to right.

Examples:
Given binary tree [3,9,20,null,null,15,7],
    3
   / \
  9  20
    /  \
   15   7
return its vertical order traversal as:
[
  [9],
  [3,15],
  [20],
  [7]
]
Given binary tree [3,9,20,4,5,2,7],
    _3_
   /   \
  9    20
 / \   / \
4   5 2   7
return its vertical order traversal as:
[
  [4],
  [9],
  [3,5,2],
  [20],
  [7]
]
*/

using System;
using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public List<List<int>> VerticalOrder(TreeNode root)
        {
            var res = new List<List<int>>();
            if (root == null)
            {
                return res;
            }

            var map = new Dictionary<int, List<int>>();
            var q = new Queue<Tuple<TreeNode, int>>();

            q.Enqueue(Tuple.Create(root, 0));
            int min = 0, max = 0;
            while (q.Count != 0)
            {
                var node = q.Dequeue();
                if (!map.ContainsKey(node.Item2))
                {
                    map.Add(node.Item2, new List<int>());
                }
                map[node.Item2].Add(node.Item1.val);

                if (node.Item1.left != null)
                {
                    q.Enqueue(Tuple.Create(node.Item1.left, node.Item2 - 1));
                    min = Math.Min(min, node.Item2 - 1);
                }

                if (node.Item1.right != null)
                {
                    q.Enqueue(Tuple.Create(node.Item1.right, node.Item2 + 1));
                    max = Math.Max(max, node.Item2 + 1);
                }
            }

            for (int i = min; i <= max; i++)
            {
                res.Add(map[i]);
            }

            return res;
        }
    }
}
