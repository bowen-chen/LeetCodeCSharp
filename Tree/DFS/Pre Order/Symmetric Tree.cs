/*
101	Symmetric Tree	
easy, tree, *
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
    }
}
