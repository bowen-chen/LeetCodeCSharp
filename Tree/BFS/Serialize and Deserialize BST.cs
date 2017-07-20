/*
449. Serialize and Deserialize BST
Serialization is the process of converting a data structure or object into a sequence of bits so that it can be stored in a file or memory buffer, or transmitted across a network connection link to be reconstructed later in the same or another computer environment.

Design an algorithm to serialize and deserialize a binary search tree. There is no restriction on how your serialization/deserialization algorithm should work. You just need to ensure that a binary search tree can be serialized to a string and this string can be deserialized to the original tree structure.

The encoded string should be as compact as possible.

Note: Do not use class member/global/static variables to store states. Your serialize and deserialize algorithms should be stateless.
*/

using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    public class Codec2
    {
        // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            if (root == null)
            {
                return null;
            }

            var res = new StringBuilder();
            var s = new Stack<TreeNode>();
            s.Push(root);
            while (s.Count != 0)
            {
                var c = s.Pop();
                res.Append(c.val).Append(",");
                if (c.right != null)
                {
                    s.Push(c.right);
                }
                if (c.left != null)
                {
                    s.Push(c.left);
                }
            }

            return res.ToString().TrimEnd(',');
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            if (data == null)
            {
                return null;
            }
            
            int[] values = data.Split(',').Select(int.Parse).ToArray();
            return deserialize(values, 0, values.Length-1);
        }

        private TreeNode deserialize(int[] values, int low, int high)
        {
            if (low > high)
            {
                return null;
            }

            var c = new TreeNode(values[low++]);
            int mid = low;
            while (mid <= high && values[mid] <= c.val)
            {
                mid++;
            }

            c.left = deserialize(values, low, mid-1);
            c.right = deserialize(values, mid, high);
            return c;
        }
    }

    // Your Codec object will be instantiated and called as such:
    // Codec codec = new Codec();
    // codec.deserialize(codec.serialize(root));
}
