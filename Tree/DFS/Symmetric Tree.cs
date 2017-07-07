/*
101	Symmetric Tree	
easy, tree
Symmetric Tree
Given a binary tree, check whether it is a mirror of itself (ie, symmetric around its center).

For example, this binary tree is symmetric:

    1
   / \
  2   2
 / \ / \
3  4 4  3
But the following is not:
    1
   / \
  2   2
   \   \
   3    3
Note:
Bonus points if you could solve it both recursively and iteratively.
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public bool IsSymmetric(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }

            return IsSymmetric(root.left, root.right);
        }

        public bool IsSymmetric(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
            {
                return true;
            }

            if (p != null && q != null)
            {
                return p.val == q.val && IsSymmetric(p.left, q.right) && IsSymmetric(p.right, q.left);
            }

            return false;
        }

        public bool IsSymmetric2(TreeNode root)
        {
            if (root == null) return true;

            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode left, right;
            if (root.left != null)
            {
                if (root.right == null) return false;
                stack.Push(root.left);
                stack.Push(root.right);
            }
            else if (root.right != null)
            {
                return false;
            }

            while (stack.Count > 0)
            {
                if (stack.Count%2 != 0)
                {
                    return false;
                }
                right = stack.Pop();
                left = stack.Pop();
                if (right.val != left.val)
                {
                    return false;
                }

                if (left.left != null)
                {
                    if (right.right == null)
                    {
                        return false;
                    }
                    stack.Push(left.left);
                    stack.Push(right.right);
                }
                else if (right.right != null)
                {
                    return false;
                }

                if (left.right != null)
                {
                    if (right.left == null)
                    {
                        return false;
                    }
                    stack.Push(left.right);
                    stack.Push(right.left);
                }
                else if (right.left != null)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
