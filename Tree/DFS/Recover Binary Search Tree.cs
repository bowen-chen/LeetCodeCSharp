/*
99	Recover Binary Search Tree
hard
Two elements of a binary search tree (BST) are swapped by mistake.

Recover the tree without changing its structure.

Note:
A solution using O(n) space is pretty straight forward. Could you devise a constant space solution?
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
        public void RecoverTree(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            TreeNode cur = root;
            TreeNode first = null;
            TreeNode second = null;
            TreeNode parent = null;
            while (cur != null)
            {
                if (cur.left == null)
                {
                    if (parent != null && parent.val > cur.val)
                    {
                        if (first == null)
                        {
                            first = parent;
                        }

                        second = cur;
                    }
                    parent = cur;
                    cur = cur.right;
                }
                else
                {
                    // find the predecessor in my sub tree
                    TreeNode pre = cur.left;
                    while (pre.right != null && pre.right != cur)
                    {
                        pre = pre.right;
                    }

                    // My predecessor right is null, so it is the first time, go left
                    if (pre.right == null)
                    {
                        pre.right = cur;
                        cur = cur.left;
                    }
                    // My predecessor right is myself, so it is the second time, go right
                    else
                    {
                        if (parent != null && parent.val > cur.val)
                        {
                            if (first == null)
                            {
                                first = parent;
                            }

                            second = cur;
                        }
                        parent = cur;
                        pre.right = null;
                        cur = cur.right;
                    }
                }
            }

            if (first != null && second != null)
            {
                var temp = first.val;
                first.val = second.val;
                second.val = temp;
            }
        }

        public void RecoverTree2(TreeNode root)
        {
            TreeNode first = null;
            TreeNode second = null;
            TreeNode pre = new TreeNode(int.MinValue);
            RecoverTree2(root, ref pre, ref first, ref second);
            if (first != null && second != null)
            {
                int temp = first.val;
                first.val = second.val;
                second.val = temp;
            }
        }

        public void RecoverTree2(TreeNode root, ref TreeNode pre, ref TreeNode first, ref TreeNode second)
        {
            if (root == null)
            {
                return;
            }

            RecoverTree2(root.left, ref pre, ref first, ref second);

            // min, 6, 3, 4, 5, 2
            // First = pre if pre.val>root.val
            // Second = root if pre.val>root.val
            if (pre.val > root.val)
            {
                if (first==null)
                {
                    first = pre;
                }
                if(first != null)
                {
                    second = root;
                }
            }
            pre = root;

            RecoverTree2(root.right,ref pre, ref first, ref second);
        }
    }
}
