/*
236	Lowest Common Ancestor of a Binary Tree
easy
Lowest Common Ancestor of a Binary Tree

Given a binary tree, find the lowest common ancestor (LCA) of two given nodes in the tree.

According to the definition of LCA on Wikipedia: “The lowest common ancestor is defined between two nodes v and w as the lowest node in T that has both v and w as descendants (where we allow a node to be a descendant of itself).”

        _______3______
       /              \
    ___5__          ___1__
   /      \        /      \
   6      _2       0       8
         /  \
         7   4
For example, the lowest common ancestor (LCA) of nodes 5 and 1 is 3. Another example is LCA of nodes 5 and 4 is 5, since a node can be a descendant of itself according to the LCA definition.
*/

namespace Demo
{
    public partial class Solution
    {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || root == p || root == q)
            {
                return root;
            }

            TreeNode left = LowestCommonAncestor(root.left, p, q);
            TreeNode right = LowestCommonAncestor(root.right, p, q);

            // we found p,q in left and right;
            if (left != null && right != null)
            {
                return root;
            }

            return left ?? right;
        }

        public TreeNode LowestCommonAncestor2(TreeNode root, TreeNode p, TreeNode q)
        {
            TreeNode ret = null;
            LowestCommonAncestor2(root, p, q, ref ret);
            return ret;
        }

        public int LowestCommonAncestor2(TreeNode root, TreeNode p, TreeNode q, ref TreeNode ret)
        {
            if (root == null)
            {
                return 0;
            }
            
            int center = (root == p || root == q) ? 1 : 0;
            int left = LowestCommonAncestor2(root.left, p, q, ref ret);
            int right = left != 2 ? LowestCommonAncestor2(root.right, p, q, ref ret) : 0;

            if ((left == 1 && right == 1) || (left == 1 && center == 1) || (center == 1 && right == 1))
            {
                ret = root;
            }

            return left + right + center;
        }
    }
}
