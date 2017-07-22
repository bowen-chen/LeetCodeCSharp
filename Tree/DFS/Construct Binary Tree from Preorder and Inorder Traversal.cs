/*
105	Construct Binary Tree from Preorder and Inorder Traversal
easy, tree
Given preorder and inorder traversal of a tree, construct the binary tree.

Note:
 You may assume that duplicates do not exist in the tree. 
*/

namespace Demo
{
    public partial class Solution
    {
        public TreeNode BuildTreePreIn(int[] preorder, int[] inorder)
        {
            if (inorder == null || inorder.Length == 0)
            {
                return null;
            }

            return BuildTreePreIn(preorder, inorder, 0, inorder.Length - 1, 0);
        }

        public TreeNode BuildTreePreIn(int[] preorder, int[] inorder, int instart,
                int inend, int prestart)
        {
            int v = preorder[prestart];
            TreeNode ret = new TreeNode(v);
            int postin = -1;
            for (int i = instart; i <= inend; i++)
            {
                if (inorder[i] == v)
                {
                    postin = i;
                }
            }

            int leftinend = postin - 1;
            if (leftinend >= instart)
            {
                ret.left = BuildTreePreIn(preorder, inorder, instart, leftinend,
                        prestart + 1);
            }

            int leftno = postin - instart;
            int rightinstart = postin + 1;
            if (rightinstart <= inend)
            {
                ret.right = BuildTreePreIn(preorder, inorder, rightinstart, inend,
                        prestart + 1 + leftno);
            }

            return ret;
        }
    }
}
