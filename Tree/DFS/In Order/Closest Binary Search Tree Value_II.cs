/*
272	Closest Binary Search Tree Value II
medium
Given a non-empty binary search tree and a target value, find k values in the BST that are closest to the target.

Note:

Given target value is a floating point.
You may assume k is always valid, that is: k ≤ total nodes.
You are guaranteed to have only one unique set of k values in the BST that are closest to the target.
 

Follow up:
Assume that the BST is balanced, could you solve it in less than O(n) runtime (where n = total nodes)?

Hint:

Consider implement these two helper functions:
getPredecessor(N), which returns the next smaller node to N.
getSuccessor(N), which returns the next larger node to N.
Try to assume that each node has a parent pointer, it makes the problem much easier.
Without parent pointer we just need to keep track of the path from the root to the current node using a stack.
You would need two stacks to track the path in finding predecessor and successor node separately.
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    public partial class Solution
    {
        public List<int> ClosestKValues(TreeNode root, double target, int k)
        {
            var res = new Queue<int>();
            ClosestKValues(root, target, k, res);
            return res.ToList();
        }
        private void ClosestKValues(TreeNode root, double target, int k, Queue<int> res)
        {
            if (root == null)
            {
                return;
            }

            ClosestKValues(root.left, target, k, res);

            if (res.Count < k)
            {
                res.Enqueue(root.val);
            }
            else if (Math.Abs(root.val - target) < Math.Abs(res.Peek() - target))
            {
                res.Dequeue();
                res.Enqueue(root.val);
            }
            else
            {
                return;
            }

            ClosestKValues(root.right, target, k, res);
        }
    }
}
