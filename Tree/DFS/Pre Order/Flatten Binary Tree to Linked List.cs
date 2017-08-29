/*
114. Flatten Binary Tree to Linked List
Given a binary tree, flatten it to a linked list in-place.

For example,
Given

         1
        / \
       2   5
      / \   \
     3   4   6
The flattened tree should look like:
   1
    \
     2
      \
       3
        \
         4
          \
           5
            \
             6
click to show hints.

Hints:
If you notice carefully in the flattened tree, each node's right child points to the next node of a pre-order traversal.
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
        public void Flatten(TreeNode root)
        {
            TreeNode pre = null;
            Flatten(root, ref pre);
            if (pre != null)
            {
                pre.left = null;
                pre.right = null;
            }
        }

        public void Flatten(TreeNode root, ref TreeNode pre)
        {
            if (root == null)
            {
                return;
            }

            if (pre != null)
            {
                pre.left = null;
                pre.right = root;
            }

            pre = root;
            var left = root.left;
            var right = root.right;

            Flatten(left, ref pre);
            Flatten(right, ref pre);
        }
    }
}
