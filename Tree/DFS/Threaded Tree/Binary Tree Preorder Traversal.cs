/*
144. Binary Tree Preorder Traversal
hard
Given a binary tree, return the preorder traversal of its nodes' values.

For example:
Given binary tree {1,#,2,3},
   1
    \
     2
    /
   3
return [1,2,3].

Note: Recursive solution is trivial, could you do it iteratively?
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public IList<int> PreorderTraversal(TreeNode root)
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
                    // preorder visit, before go right since no left
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
                        // preorder visit, before go left
                        res.Add(cur.val);

                        // thread myself
                        pre.right = cur;
                        cur = cur.left;
                    }
                    // My predecessor right is myself, so it is the second time, go right
                    else
                    {
                        // restore tree
                        pre.right = null;
                        cur = cur.right;
                    }
                }
            }
            return res;
        }

        public IList<int> PreorderTraversal2(TreeNode root)
        {
            var ret = new List<int>();
            PreorderTraversal2(root, ret);
            return ret;
        }

        public void PreorderTraversal2(TreeNode root, IList<int> ret)
        {
            if (root == null)
            {
                return;
            }

            ret.Add(root.val);
            PreorderTraversal2(root.left, ret);
            PreorderTraversal2(root.right, ret);
        }

        public IList<int> PreorderTraversal3(TreeNode root)
        {
            var ret = new List<int>();
            var s = new Stack<TreeNode>();
            var p = root;
            while (p != null || s.Count != 0)
            {
                if (p != null)
                {
                    ret.Add(p.val);
                    s.Push(p);
                    p = p.left;
                }
                else
                {
                    p = s.Pop();
                    p = p.right;
                }
            }

            return ret;
        }
    }
}
