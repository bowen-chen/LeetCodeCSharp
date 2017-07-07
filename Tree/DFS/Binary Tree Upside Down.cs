/*
156	Binary Tree Upside Down
medium, tree
Given a binary tree where all the right nodes are either leaf nodes with a sibling (a left node that shares the same parent node) or empty, flip it upside down and turn it into a tree where the original right nodes turned into left leaf nodes. Return the new root.
For example:
Given a binary tree {1,2,3,4,5},
    1
   / \
  2   3
 / \
4   5
return the root of the binary tree [4,5,2,#,#,3,1].
   4
  / \
 5   2
    / \
   3   1  
*/

namespace Demo
{
    public partial class Solution
    {
        public TreeNode UpsideDownBinaryTree(TreeNode root)
        {
            TreeNode curr = root;
            TreeNode pre = null; // will be co
            TreeNode pre_left = null;
            TreeNode pre_right = null;

            while (curr != null)
            {
                var left = curr.left;
                var right = curr.right;
                curr.left = pre_right;
                curr.right = pre;

                pre = curr;
                pre_left = left;
                pre_right = right;
                curr = left;
            }

            return pre;
        }

        public TreeNode UpsideDownBinaryTree2(TreeNode root)
        {
            TreeNode newRoot = null;
            UpsideDownBinaryTree2(root, ref newRoot);
            return newRoot;
        }

        public TreeNode UpsideDownBinaryTree2(TreeNode root, ref TreeNode newRoot)
        {
            if (root == null)
            {
                return null;
            }

            if (root.left == null && root.right == null)
            {
                newRoot = root;
                return root;
            }

            TreeNode parent = UpsideDownBinaryTree2(root.left, ref newRoot);
            parent.left = root.right;
            parent.right = root;
            root.left = null;
            root.right = null;
            return root;
        }
    }
}
