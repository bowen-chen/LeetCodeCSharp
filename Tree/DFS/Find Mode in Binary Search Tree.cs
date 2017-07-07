/*
501. Find Mode in Binary Search Tree
easy
Given a binary search tree (BST) with duplicates, find all the mode(s) (the most frequently occurred element) in the given BST.

Assume a BST is defined as follows:

The left subtree of a node contains only nodes with keys less than or equal to the node's key.
The right subtree of a node contains only nodes with keys greater than or equal to the node's key.
Both the left and right subtrees must also be binary search trees.
For example:
Given BST [1,null,2,2],
   1
    \
     2
    /
   2
return [2].

Note: If a tree has more than one mode, you can return them in any order.

Follow up: Could you do that without using any extra space? (Assume that the implicit stack space incurred due to recursion does not count).
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
        public int[] FindMode(TreeNode root)
        {
            var res = new List<int>();
            int max = 0;
            int preValue = 0;
            int preCount = 0;
            FindMode(root, ref preValue, ref preCount, ref max, res);
            return res.ToArray();
        }

        private void FindMode(TreeNode node, ref int preValue, ref int preCount, ref int max, List<int> res)
        {
            if (node == null)
            {
                return;
            }
            FindMode(node.left, ref preValue, ref preCount, ref max, res);
            if (node.val == preValue)
            {
                preCount ++;
            }
            else
            {
                preValue = node.val;
                preCount = 1;
            }

            if (preCount == max)
            {
                res.Add(node.val);
            }
            else if (preCount > max)
            {
                res.Clear();
                res.Add(node.val);
                max = preCount;
            }

            FindMode(node.right, ref preValue, ref preCount, ref max, res);
        }
    }
}
