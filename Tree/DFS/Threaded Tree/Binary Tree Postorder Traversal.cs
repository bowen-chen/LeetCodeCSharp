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
                        cur = cur.right;
                    }
                }
            }
            return res;
        }
    }
}
