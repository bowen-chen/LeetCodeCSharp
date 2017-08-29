/*
100	Same Tree
easy, tree, *
Same Tree

Given two binary trees, write a function to check if they are equal or not.

Two binary trees are considered equal if they are structurally identical and the nodes have the same value.
*/

namespace Demo
{
    public partial class Solution
    {
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
            {
                return true;
            }

            if (p != null && q != null)
            {
                return p.val == q.val && IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
            }

            return false;
        }
    }
}
