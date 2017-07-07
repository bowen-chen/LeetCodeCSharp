/*
250 Count Univalue Subtrees
easy
Given a binary tree, count the number of uni-value subtrees.

A Uni-value subtree means all nodes of the subtree have the same value.

For example:
Given binary tree,
              5
             / \
            1   5
           / \   \
          5   5   5
return 4.
*/

namespace Demo
{
    public partial class Solution
    {
        public int CountUnivalSubtrees(TreeNode root)
        {
            int count = 0;
            CountUnivalSubtrees(root, ref count);
            return count;
        }

        private bool CountUnivalSubtrees(TreeNode root, ref int count)
        {
            if (root == null)
            {
                return true;
            }

            // all leaf is unival tree
            if (root.left == null && root.right == null)
            {
                count++;
                return true;
            }

            bool left = CountUnivalSubtrees(root.left, ref count);
            bool right = CountUnivalSubtrees(root.right, ref count);
            if (left && right 
                && (root.left == null || root.left.val == root.val)
                && (root.right == null || root.right.val == root.val))
            {
                count++;
                return true;
            }

            return false;
        }
    }
}
