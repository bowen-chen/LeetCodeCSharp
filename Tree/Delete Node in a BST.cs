/*
450. Delete Node in a BST
medium
Given a root node reference of a BST and a key, delete the node with the given key in the BST. Return the root node reference (possibly updated) of the BST.

Basically, the deletion can be divided into two stages:

Search for a node to remove.
If the node is found, delete the node.
Note: Time complexity should be O(height of tree).

Example:

root = [5,3,6,2,4,null,7]
key = 3

    5
   / \
  3   6
 / \   \
2   4   7

Given key to delete is 3. So we find the node with value 3 and delete it.

One valid answer is [5,4,6,2,null,null,7], shown in the following BST.

    5
   / \
  4   6
 /     \
2       7

Another valid answer is [5,2,6,null,4,null,7].

    5
   / \
  2   6
   \   \
    4   7
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
        public TreeNode DeleteNode(TreeNode root, int key)
        {
            if (root == null)
            {
                return null;
            }

            if (root.val == key)
            {
                return DeleteNode(root);
            }

            if (root.val > key)
            {
                root.left = DeleteNode(root.left, key);
            }
            else
            {
                root.right = DeleteNode(root.right, key);
            }

            return root;
        }

        public TreeNode DeleteNode(TreeNode root)
        {
            // only right child (could be null)
            if (root.left == null)
            {
                return root.right;
            }

            // only left child
            if (root.right == null)
            {
                return root.left;
            }

            // move precedencessor to node
            // Go left and all the way right
            TreeNode parent = root;
            TreeNode pre = root.left;
            while (pre.right != null)
            {
                parent = pre;
                pre = pre.right;
            }

            root.val = pre.val;

            //  root
            // /
            //left
            // \
            //   ...
            //    \
            //     parent
            //      \
            //       pre
            //       /
            //      pre.left
            if (parent != root)
            {
                // reconnect left child
                parent.right = pre.left;
            }

            //     root (parent)
            //    /
            //   pre
            //  /
            // pre.left
            else
            {
                parent.left = pre.left;
            }

            return root;
        }
    }
}
