/*
106	Construct Binary Tree from Inorder and Postorder Traversal
easy, tree
Given inorder and postorder traversal of a tree, construct the binary tree.

Note:
 You may assume that duplicates do not exist in the tree. 
*/

namespace Demo
{
    public partial class Solution
    {
        public TreeNode BuildTreeInPost(int[] inorder, int[] postorder)
        {
            if (inorder == null || inorder.Length == 0)
            {
                return null;
            }

            return BuildTreeInPost(inorder, postorder, 0, inorder.Length - 1,
                postorder.Length - 1);
        }

        public TreeNode BuildTreeInPost(int[] inorder, int[] postorder,
            int instart, int inend, int postend)
        {
            int v = postorder[postend];
            TreeNode ret = new TreeNode(v);
            int postin = -1;
            for (int i = instart; i <= inend; i++)
            {
                if (inorder[i] == v)
                {
                    postin = i;
                }
            }

            int rightno = inend - postin;
            int leftinend = postin - 1;
            if (leftinend >= instart)
            {
                ret.left = BuildTreeInPost(inorder, postorder, instart, leftinend,
                    postend - 1 - (inend - rightno));
            }

            int rightinstart = postin + 1;
            if (rightinstart <= inend)
            {
                ret.right = BuildTreeInPost(inorder, postorder, rightinstart,
                    inend, postend - 1);
            }

            return ret;
        }
    }
}
