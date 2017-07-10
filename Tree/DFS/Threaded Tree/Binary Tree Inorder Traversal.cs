/*
94	Binary Tree Inorder Traversal
hard
Given a binary tree, return the inorder traversal of its nodes' values.

For example:
Given binary tree {1,#,2,3},

   1
    \
     2
    /
   3
 

return [1,3,2].

Note: Recursive solution is trivial, could you do it iteratively?

confused what "{1,#,2,3}" means? > read more on how binary tree is serialized on OJ.
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public IList<int> InorderTraversal(TreeNode root)
        {
            var res = new List<int>();
            if (root == null)
            {
                return res;
            }

            TreeNode cur = root;
            while (cur != null)
            {
                if (cur.left == null)
                {
                    // inorder visit, before go right
                    res.Add(cur.val);
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
                        // thread myself
                        pre.right = cur;
                        cur = cur.left;
                    }
                    // My predecessor right is myself, so it is the second time, go right
                    else
                    {
                        // restore the tree
                        pre.right = null;

                        // inorder visit, before go right
                        res.Add(cur.val);
                        cur = cur.right;
                    }
                }
            }
            return res;
        }

        public IList<int> InorderTraversal2(TreeNode root)
        {
            var ret = new List<int>();
            InorderTraversal2(root, ret);
            return ret;
        }

        public void InorderTraversal2(TreeNode root, IList<int> ret)
        {
            if (root == null)
            {
                return;
            }

            InorderTraversal2(root.left, ret);
            ret.Add(root.val);
            InorderTraversal2(root.right, ret);
        }

        public IList<int> InorderTraversal3(TreeNode root)
        {
            var ret = new List<int>();
            var s = new Stack<TreeNode>();
            var p = root;
            while (p!= null || s.Count != 0)
            {
                if (p != null)
                {
                    s.Push(p);
                    p = p.left;
                }
                else
                {
                    p = s.Pop();
                    ret.Add(p.val);
                    p = p.right;
                }
            }

            return ret;
        }
    }
}
