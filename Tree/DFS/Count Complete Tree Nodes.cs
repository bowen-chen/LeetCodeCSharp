/*
222	Count Complete Tree Nodes
medium, tree, *
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
            // fast track for complete tree
            return root == null ? 0 : 1 + Height(root.left);
        }

        public int CountNodes(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            int l = Height(root.left);
            int r = Height(root.right);
            int ret = 1;
            if (l > r)
            {
                // right is complete tree
                ret += ((1 << r) - 1);
                ret += CountNodes(root.left);
            }
            else
            {
                // left is complete tree
                ret += ((1 << l) - 1);
                ret += CountNodes(root.right);
            }

            return ret;
        }
    }
}
