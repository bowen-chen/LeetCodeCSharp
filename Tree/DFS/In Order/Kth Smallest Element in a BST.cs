/*
230	Kth Smallest Element in a BST
easy
Kth Smallest Element in a BST
Given a binary search tree, write a function kthSmallest to find the kth smallest element in it.

Note: 
You may assume k is always valid, 1 ≤ k ≤ BST's total elements.

Follow up:
What if the BST is modified (insert/delete operations) often and you need to find the kth smallest frequently? How would you optimize the kthSmallest routine?

Hint:

Try to utilize the property of a BST.
What if you could modify the BST node's structure?
The optimal runtime complexity is O(height of BST).
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public int KthSmallest(TreeNode root, int k)
        {
            if (root == null)
            {
                return 0;
            }

            var stack = new Stack<TreeNode>();

            // Push left
            while (root != null)
            {
                stack.Push(root);
                root = root.left;
            }

            while (stack.Count > 0)
            {
                var n = stack.Pop();
                k--;
                if (k == 0)
                {
                    return n.val;
                }

                n = n.right;

                while (n != null)
                {
                    stack.Push(n);
                    n = n.left;
                }
            }

            return 0;
        }

        // for follow up question, we could save the node count in the node
        public int KthSmallest2(TreeNode root, int k)
        {
            int left = NodeCount(root.left);
            if (left + 1 == k)
            {
                return root.val;
            }

            if (left + 1 < k)
            {
                return KthSmallest2(root.right, k - left - 1);
            }
            else
            {
                return KthSmallest2(root.left, k);
            }
        }

        private int NodeCount(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            return 1 + NodeCount(root.left) + NodeCount(root.right);
        }
    }
}
