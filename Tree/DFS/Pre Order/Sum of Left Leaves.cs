/*
404	Sum of Left Leaves 
*
Find the sum of all left leaves in a given binary tree.

Example:

    3
   / \
  9  20
    /  \
   15   7

There are two left leaves in the binary tree, with values 9 and 15 respectively. Return 24.
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
        public int SumOfLeftLeaves(TreeNode root)
        {
            return SumOfLeftLeaves(root, false);
        }

        public int SumOfLeftLeaves(TreeNode root, bool left)
        {
            if (root == null)
            {
                return 0;
            }

            if (root.left == null && root.right == null & left)
            {
                return root.val;
            }

            return SumOfLeftLeaves(root.left, true) + SumOfLeftLeaves(root.right, false);
        }
    }
}
