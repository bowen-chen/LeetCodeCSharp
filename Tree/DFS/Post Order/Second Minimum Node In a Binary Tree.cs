﻿/*
671. Second Minimum Node In a Binary Tree
Given a non-empty special binary tree consisting of nodes with the non-negative value, where each node in this tree has exactly two or zero sub-node. If the node has two sub-nodes, then this node's value is the smaller value among its two sub-nodes.

Given such a binary tree, you need to output the second minimum value in the set made of all the nodes' value in the whole tree.

If no such second minimum value exists, output -1 instead.

Example 1:
Input: 
    2
   / \
  2   5
     / \
    5   7

Output: 5
Explanation: The smallest value is 2, the second smallest value is 5.
Example 2:
Input: 
    2
   / \
  2   2

Output: -1
Explanation: The smallest value is 2, but there isn't any second smallest value.
*/

using System;

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
        public int FindSecondMinimumValue(TreeNode root)
        {
            if (root.left == null)
            {
                return -1;
            }
            int left = root.left.val == root.val ? FindSecondMinimumValue(root.left) : root.left.val;
            int right = root.right.val == root.val ? FindSecondMinimumValue(root.right) : root.right.val;
            if (left == -1)
            {
                return right;
            }
            if (right == -1)
            {
                return left;
            }
            return Math.Min(left, right);
        }
    }
}
