/*
297	Serialize and Deserialize Binary Tree
easy
Serialize and Deserialize Binary Tree
Serialization is the process of converting a data structure or object into a sequence of bits so that it can be stored in a file or memory buffer, or transmitted across a network connection link to be reconstructed later in the same or another computer environment.

Design an algorithm to serialize and deserialize a binary tree. There is no restriction on how your serialization/deserialization algorithm should work. You just need to ensure that a binary tree can be serialized to a string and this string can be deserialized to the original tree structure.

For example, you may serialize the following tree

    1
   / \
  2   3
     / \
    4   5
as "[1,2,3,null,null,4,5]", just the same as how LeetCode OJ serializes a binary tree. You do not necessarily need to follow this format, so please be creative and come up with different approaches yourself.
Note: Do not use class member/global/static variables to store states. Your serialize and deserialize algorithms should be stateless.
*/
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Demo
{
    public partial class Codec
    {
        public static void Test()
        {
            var codec = new Codec();
            codec.deserialize(codec.serialize(null));
            codec.deserialize(codec.serialize(new TreeNode(1)));
            codec.deserialize(codec.serialize(new TreeNode(1) {right = new TreeNode(2)}));
            codec.deserialize(codec.serialize(new TreeNode(1) {left = new TreeNode(2) }));
        }

        // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            // 0: null, 1 + 4 value
            var bytes = new List<byte>();
            var q = new Queue<TreeNode>();
            q.Enqueue(root);
            while (q.Count >0)
            {
                var n = q.Dequeue();
                if (n == null)
                {
                    bytes.Add(0);
                }
                else
                {
                    bytes.Add(1);
                    bytes.AddRange(BitConverter.GetBytes(n.val));
                    q.Enqueue(n.left);
                    q.Enqueue(n.right);
                }
            }

            return Convert.ToBase64String(bytes.ToArray());
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return null;
            }

            byte[] bytes = Convert.FromBase64String(data);
            List<TreeNode> nodes = new List<TreeNode>();
            int i = 0;
            while (i < bytes.Length)
            {
                if (bytes[i] == 0)
                {
                    nodes.Add(null);
                    i++;
                }
                else
                {

                    if (i + 4 >= bytes.Length)
                    {
                        throw new SerializationException();
                    }

                    i++;
                    nodes.Add(new TreeNode(BitConverter.ToInt32(bytes, i)));
                    i += 4;
                }
            }

            for (int j = 0, k = 1; j < nodes.Count && k < nodes.Count; j++)
            {
                if (nodes[j] != null)
                {
                    if (k < nodes.Count)
                    {
                        nodes[j].left = nodes[k];
                        k++;
                    }
                    if (k < nodes.Count)
                    {
                        nodes[j].right = nodes[k];
                        k++;
                    }
                }
            }

            return nodes[0];
        }
    }
}
