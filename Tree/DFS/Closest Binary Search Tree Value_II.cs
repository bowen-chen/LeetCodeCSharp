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
using Demo.Common;
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

        public List<int> ClosestKValues3(TreeNode root, double target, int k)
        {
            var res = new List<int>();

            var s1 = new Stack<int>(); // predecessors
            var s2 = new Stack<int>(); // successors

            ClosestKValues3(root, target, false, s1);
            ClosestKValues3(root, target, true, s2);

            while (k-- > 0)
            {
                if (s1.Count == 0)
                    res.Add(s2.Pop());
                else if (s2.Count == 0)
                    res.Add(s1.Pop());
                else if (Math.Abs(s1.Peek() - target) < Math.Abs(s2.Peek() - target))
                    res.Add(s1.Pop());
                else
                    res.Add(s2.Pop());
            }

            return res;
        }

        // inorder traversal
        private void ClosestKValues3(TreeNode root, double target, bool reverse, Stack<int> stack)
        {
            if (root == null) return;

            ClosestKValues3(reverse ? root.right : root.left, target, reverse, stack);
            // early terminate, no need to traverse the whole tree
            if ((reverse && root.val <= target) || (!reverse && root.val > target)) return;
            // track the value of current node
            stack.Push(root.val);
            ClosestKValues3(reverse ? root.left : root.right, target, reverse, stack);
        }

        public List<int> ClosestKValues2(TreeNode root, double target, int k)
        {
            var pq = new PriorityQueue<Tuple<double, int>>(16, Comparer<Tuple<double, int>>.Create((t1, t2) => t2.Item1.CompareTo(t1.Item2)));
            ClosestKValues2(root, pq, target, k);
            var ret = new List<int>();
            while (pq.Count != 0)
            {
                ret.Add(pq.Pop().Item2);
            }
            return ret;
        }
        private void ClosestKValues2(TreeNode node, PriorityQueue<Tuple<double, int>> pq, double target, int k)
        {
            if (node == null) return;
            pq.Push(Tuple.Create(Math.Abs(target - node.val), node.val));
            if (pq.Count > k) pq.Pop();
            ClosestKValues2(node.left, pq, target, k);
            ClosestKValues2(node.right, pq, target, k);
        }
    }
}
