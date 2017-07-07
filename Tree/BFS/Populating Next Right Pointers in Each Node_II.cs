/*
117. Populating Next Right Pointers in Each Node II
Follow up for problem "Populating Next Right Pointers in Each Node".

What if the given tree could be any binary tree? Would your previous solution still work?

Note:

You may only use constant extra space.
For example,
Given the following binary tree,
         1
       /  \
      2    3
     / \    \
    4   5    7
After calling your function, the tree should look like:
         1 -> NULL
       /  \
      2 -> 3 -> NULL
     / \    \
    4-> 5 -> 7 -> NULL
*/

namespace Demo
{
    public partial class Solution
    {
        public void Connect3(TreeLinkNode root)
        {
            TreeLinkNode level_start = root;
            while (level_start != null)
            {
                TreeLinkNode cur = level_start;
                TreeLinkNode pre = null;
                level_start = null;
                while (cur != null)
                {
                    if (cur.left != null)
                    {
                        if (pre == null)
                        {
                            level_start = cur.left;
                        }
                        else
                        {
                            pre.next = cur.left;
                        }

                        pre = cur.left;
                    }

                    if (cur.right != null)
                    {
                        if (pre == null)
                        {
                            level_start = cur.right;
                        }
                        else
                        {
                            pre.next = cur.right;
                        }

                        pre = cur.right;
                    }

                    cur = cur.next;
                }
            }
        }
    }
}
