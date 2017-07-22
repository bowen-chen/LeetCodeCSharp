/*
538. Convert BST to Greater Tree
easy
Given a Binary Search Tree (BST), convert it to a Greater Tree such that every key of the original BST is changed to the original key plus sum of all keys greater than the original key in BST.

Example:

Input: The root of a Binary Search Tree like this:
              5
            /   \
           2     13

Output: The root of a Greater Tree like this:
             18
            /   \
          20     13

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
        public TreeNode ConvertBST(TreeNode root)
        {
            int sum = 0;
            ConvertBST(root, ref sum);
            return root;
        }
        private void ConvertBST(TreeNode root, ref int sum)
        {
            if (root == null)
            {
                return;
            }

            ConvertBST(root.right, ref sum);
            root.val += sum;
            sum = root.val;
            ConvertBST(root.left, ref sum);
        }
    }
}
