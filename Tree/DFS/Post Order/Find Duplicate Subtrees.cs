/*
652. Find Duplicate Subtrees
Given a binary tree, return all duplicate subtrees. For each kind of duplicate subtrees, you only need to return the root node of any one of them.

Two trees are duplicate if they have the same structure with same node values.

Example 1: 
        1
       / \
      2   3
     /   / \
    4   2   4
       /
      4
The following are two duplicate subtrees:
      2
     /
    4
and
    4
Therefore, you need to return above trees' root in the form of a list.
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
        public IList<TreeNode> FindDuplicateSubtrees(TreeNode root)
        {
            var ret = new List<TreeNode>();
            FindDuplicateSubtrees(root, new Dictionary<string, int>(), ret);
            return ret;
        }

        public string FindDuplicateSubtrees(TreeNode root, Dictionary<string, int> dic, IList<TreeNode>  ret)
        {
            if (root == null)
            {
                return "#";
            }

            string key = root.val + "," + FindDuplicateSubtrees(root.left, dic, ret) + "," +
                         FindDuplicateSubtrees(root.right, dic, ret);
            if (dic.ContainsKey(key))
            {
                if (dic[key]++ == 1)
                {
                    ret.Add(root);
                }
            }
            else
            {
                dic[key] = 1;
            }

            return key;
        }
    }
}
