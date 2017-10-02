/*
637. Average of Levels in Binary Tree
*
Given a non-empty binary tree, return the average value of the nodes on each level in the form of an array.

Example 1:
Input:
    3
   / \
  9  20
    /  \
   15   7
Output: [3, 14.5, 11]
Explanation:
The average value of nodes on level 0 is 3,  on level 1 is 14.5, and on level 2 is 11. Hence return [3, 14.5, 11].
Note:
The range of node's value is in the range of 32-bit signed integer.
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
        public IList<double> AverageOfLevels(TreeNode root)
        {
            var res = new List<double>();
            var q = new Queue<TreeNode>();
            q.Enqueue(root);
            while (q.Count != 0)
            {
                int size = q.Count;
                double sum = 0;
                for (int i = 0; i < size; i++)
                {
                    var node = q.Dequeue();
                    sum += node.val;
                    if (node.left != null)
                    {
                        q.Enqueue(node.left);
                    }

                    if (node.right != null)
                    {
                        q.Enqueue(node.right);
                    }
                }

                res.Add(sum/size);
            }

            return res;
        }
    }
}
