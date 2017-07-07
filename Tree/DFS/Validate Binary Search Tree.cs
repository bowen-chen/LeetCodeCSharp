/*
98	Validate Binary Search Tree
easy, tree
Given a binary tree, determine if it is a valid binary search tree (BST).

Assume a BST is defined as follows:

The left subtree of a node contains only nodes with keys less than the node's key.
The right subtree of a node contains only nodes with keys greater than the node's key.
Both the left and right subtrees must also be binary search trees.
confused what "{1,#,2,3}" means? > read more on how binary tree is serialized on OJ.
*/

namespace Demo
{
    /**
     * Definition for a binary tree node.
     * public class TreeNode {
     *     public int val;
     *     public TreeNode left;
     *     public TreeNode right;
     *     public TreeNode(int x) { val = x; }
     * }
     */
    public partial class Solution
    {
        public bool IsValidBST(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }

            int? dummy;
            return IsValidBST(root, out dummy, out dummy);
        }

        public bool IsValidBST(TreeNode root, out int? min, out int? max)
        {
            min = null;
            max = null;
            int? leftmin = null;
            int? leftmax = null;
            int? rightmin = null;
            int? rightmax = null;

            if (root.left != null && !IsValidBST(root.left, out leftmin, out leftmax))
            {
                return false;
            }

            if (root.right != null && !IsValidBST(root.right, out rightmin, out rightmax))
            {
                return false;
            }
            min = leftmin ?? root.val;
            max = rightmax ?? root.val;
            return (leftmax == null || leftmax < root.val) &&
                   (rightmin == null || rightmin > root.val);
        }

        public bool IsValidBST2(TreeNode root)
        {
            return IsValidBST2(root, int.MinValue, int.MaxValue);
        }

        public bool IsValidBST2(TreeNode root, long minVal, long maxVal)
        {
            if (root == null) return true;
            if (root.val >= maxVal || root.val <= minVal) return false;
            return IsValidBST2(root.left, minVal, root.val) && IsValidBST2(root.right, root.val, maxVal);
        }
    }
}
