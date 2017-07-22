/*
145. Binary Tree Postorder Traversal
Given a binary tree, return the postorder traversal of its nodes' values.

For example:
Given binary tree {1,#,2,3},
   1
    \
     2
    /
   3
return [3,2,1].

Note: Recursive solution is trivial, could you do it iteratively?
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public IList<int> PostorderTraversal(TreeNode root)
        {
            var res = new List<int>();
            if (root == null)
            {
                return res;
            }

            var dump = new TreeNode(0)
            {
                left = root
            };
            
            TreeNode cur = dump;
            while (cur != null)
            {
                // I don't have left, just go right and don't need go back
                if (cur.left == null)
                {
                    cur = cur.right;
                }
                else
                {
                    // find the predecessor in my left sub tree
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
                        // restore tree
                        pre.right = null;

                        // postorder visit
                        var temp = cur.left;
                        int i = 0;
                        while (temp != cur)
                        {
                            res.Add(temp.val);
                            i++;
                            temp = temp.right;
                        }

                        res.Reverse(res.Count-i, i);

                        // go right
                        cur = cur.right;
                    }
                }
            }

            return res;
        }

        public IList<int> PostorderTraversal2(TreeNode root)
        {
            var ret = new List<int>();
            PostorderTraversal2(root, ret);
            return ret;
        }

        public void PostorderTraversal2(TreeNode root, IList<int> ret)
        {
            if (root == null)
            {
                return;
            }

            PostorderTraversal2(root.left, ret);
            PostorderTraversal2(root.right, ret);
            ret.Add(root.val);
        }

        public IList<int> PostorderTraversal3(TreeNode root)
        {
            var ret = new List<int>();
            var s = new Stack<TreeNode>();

            // Check for empty tree
            if (root == null)
            {
                return ret;
            }

            s.Push(root);
            TreeNode prev = null;
            while (s.Count == 0)
            {
                var current = s.Peek();

                // go down the tree from parent
                // if it has child, push left/right child
                // otherwise process it and pop stack
                if (prev == null || prev.left == current || prev.right == current)
                {
                    if (current.left != null)
                    {
                        s.Push(current.left);
                    }
                    else if (current.right != null)
                    {
                        s.Push(current.right);
                    }
                    else
                    {
                        s.Pop();
                        ret.Add(current.val);
                    }
                }

                // go up the tree from left node
                // if it has right child push right child onto stack
                // otherwise process it and pop stack
                else if (current.left == prev)
                {
                    if (current.right != null)
                    {
                        s.Push(current.right);
                    }
                    else
                    {
                        s.Pop();
                        ret.Add(current.val);
                    }
                }

                // go up the tree from right node
                // process parent and pop stack */
                else if (current.right == prev)
                {
                    s.Pop();
                    ret.Add(current.val);
                }

                prev = current;
            }

            return ret;
        }
    }
}
