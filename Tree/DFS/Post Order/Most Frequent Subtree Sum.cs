/*
508. Most Frequent Subtree Sum
easy, *
Given the root of a tree, you are asked to find the most frequent subtree sum. The subtree sum of a node is defined as the sum of all the node values formed by the subtree rooted at that node (including the node itself). So what is the most frequent subtree sum value? If there is a tie, return all the values with the highest frequency in any order.

Examples 1
Input:

  5
 /  \
2   -3
return [2, -3, 4], since all the values happen only once, return all of them in any order.
Examples 2
Input:

  5
 /  \
2   -5
return [2], since 2 happens twice, however -5 only occur once.
Note: You may assume the sum of values in any subtree is in the range of 32-bit signed integer.
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
        public int[] FindFrequentTreeSum(TreeNode root)
        {
            var m = new Dictionary<int, int>();
            var res = new List<int>();
            int max = 0;
            FindFrequentTreeSum(root, m, ref max, res);
            return res.ToArray();
        }

        // return sum of subtree
        private int FindFrequentTreeSum(TreeNode node, Dictionary<int, int> m, ref int max, List<int> res)
        {
            if (node == null)
            {
                return 0;
            }
            int left = FindFrequentTreeSum(node.left, m, ref max, res);
            int right = FindFrequentTreeSum(node.right, m, ref max, res);
            int sum = left + right + node.val;

            if (!m.ContainsKey(sum))
            {
                m[sum] = 0;
            }

            ++m[sum];
            if (m[sum] >= max)
            {
                if (m[sum] > max)
                {
                    res.Clear();
                }

                res.Add(sum);
                max = m[sum];
            }

            return sum;
        }
    }
}
