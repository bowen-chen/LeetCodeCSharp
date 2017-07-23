/*
95	Unique Binary Search Trees
easy, dp
Given n, generate all structurally unique BST's (binary search trees) that store values 1...n.

For example,
Given n = 3, your program should return all 5 unique BST's shown below.

   1         3     3      2      1
    \       /     /      / \      \
     3     2     1      1   3      2
    /     /       \                 \
   2     1         2                 3
confused what "{1,#,2,3}" means? > read more on how binary tree is serialized on OJ.
*/
using System.Collections.Generic;

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
        // prefer
        public IList<TreeNode> GenerateTrees2(int n)
        {
            var result = new List<TreeNode>[n + 1];
            result[0] = new List<TreeNode> { null };

            for (int len = 1; len <= n; len++)
            {
                result[len] = new List<TreeNode>();

                // left tree node.
                for (int j = 0; j < len; j++)
                {
                    foreach (TreeNode nodeL in result[j])
                    {
                        foreach (TreeNode nodeR in result[len - j - 1])
                        {
                            TreeNode node = new TreeNode(j + 1)
                            {
                                left = nodeL,
                                right = Clone(nodeR, j + 1)
                            };

                            result[len].Add(node);
                        }
                    }
                }
            }

            return result[n];
        }

        private static TreeNode Clone(TreeNode n, int offset)
        {
            if (n == null)
            {
                return null;
            }

            TreeNode node = new TreeNode(n.val + offset)
            {
                left = Clone(n.left, offset),
                right = Clone(n.right, offset)
            };

            return node;
        }
    }
}
