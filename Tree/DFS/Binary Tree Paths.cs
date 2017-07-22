/*
257	Binary Tree Paths
easy, tree
Binary Tree Paths

Given a binary tree, return all root-to-leaf paths.

For example, given the following binary tree:

   1
 /   \
2     3
 \
  5
All root-to-leaf paths are:

["1->2->5", "1->3"]
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public IList<string> BinaryTreePaths(TreeNode root)
        {
            var ret = new List<string>();
            if (root == null)
            {
                return ret;
            }

            BinaryTreePaths(root, null, ret);
            return ret;
        }

        private void BinaryTreePaths(TreeNode root, string path, IList<string> ret)
        {
            if (root == null)
            {
                return;
            }

            // visit
            if (path != null)
            {
                path += "->";
            }

            path += root.val;
            if (root.left == null && root.right == null)
            {
                ret.Add(path);
                return;
            }

            BinaryTreePaths(root.left, path, ret);
            BinaryTreePaths(root.right, path, ret);
        }
    }
}
