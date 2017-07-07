/*
333	Largest BST Subtree
easy, tree
Given a binary tree, find the largest subtree which is a Binary Search Tree (BST), where largest means subtree with largest number of nodes in it.

Note:
A subtree must include all of its descendants.
Here's an example:

    10
    / \
   5  15
  / \   \ 
 1   8   7
The Largest BST Subtree in this case is the highlighted one. 
The return value is the subtree's size, which is 3.

 

Hint:

You can recursively use algorithm similar to 98. Validate Binary Search Tree at each node of the tree, which will result in O(nlogn) time complexity.
Follow up:
Can you figure out ways to solve it with O(n) time complexity?
*/
using System;

namespace Demo
{
    public partial class Solution
    {
        public int LargestBSTSubtree(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            int max;
            int min;
            int ret = -1;
            LargestBSTSubtree(root, out min, out max, ref ret);
            return ret;
        }

        private int LargestBSTSubtree(TreeNode root, out int min, out int max, ref int ret)
        {
            min = int.MinValue;
            max = int.MaxValue;
            if (root == null)
            {
                return 0;
            }
            int leftMin;
            int leftMax;
            int leftSize = LargestBSTSubtree(root.left, out leftMin, out leftMax, ref ret);
            int rightMin;
            int rightMax;
            int rightSize = LargestBSTSubtree(root.right, out rightMin, out rightMax, ref ret);
            if (leftSize == -1 || rightSize == -1 || root.val < leftMax || root.val > rightMin)
            {
                return -1;
            }
            int size = leftSize + 1 + rightSize;
            ret = Math.Max(size, max);
            min = leftSize == 0 ? root.val : leftMin;
            max = rightSize == 0 ? root.val : rightMax;
            return size;
        }
    }
}
