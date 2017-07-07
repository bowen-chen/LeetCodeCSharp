/*
222	Count Complete Tree Nodes
medium, tree
Count Complete Tree Nodes

Given a complete binary tree, count the number of nodes.

Definition of a complete binary tree from Wikipedia:
In a complete binary tree every level, except possibly the last, is completely filled, and all nodes in the last level are as far left as possible. It can have between 1 and 2h nodes inclusive at the last level h.

*/

using System;

namespace Demo
{
    public partial class Solution
    {
        public void Test_CountNodes()
        {
            Console.WriteLine(CountNodes(new TreeNode(1)));
            Console.WriteLine(CountNodes(new TreeNode(1) { left = new TreeNode(2) }));
            Console.WriteLine(CountNodes(new TreeNode(1) { left = new TreeNode(2), right = new TreeNode(3) }));
            Console.WriteLine(
                CountNodes(new TreeNode(1) {left = new TreeNode(2) {left = new TreeNode(4)}, right = new TreeNode(3)}));
        }
        private int Height(TreeNode root)
        {
            return root == null ? 0 : 1 + Height(root.left);
        }
        public int CountNodes(TreeNode root)
        {
            int h = Height(root);
            if (h == 0)
            {
                return 0;
            }

            int rh = Height(root.right);
            int ret = 1;
            if (rh == h - 1) //left is complete tree, height is h-1
            {
                if (h - 1 > 0)
                {
                    ret += (1<<(h-1))-1;
                }
                ret += CountNodes(root.right);
            }
            else //right is complete tree, height is h-2
            {
                if (h - 2 > 0)
                {
                    ret += (1 << (h - 2)) - 1;
                }
                ret += CountNodes(root.left);
            }
            return ret;
        }
    }
}
