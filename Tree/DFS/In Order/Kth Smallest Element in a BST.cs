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
    }
}
