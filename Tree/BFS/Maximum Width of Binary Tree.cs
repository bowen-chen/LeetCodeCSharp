/*
662. Maximum Width of Binary Tree
Given a binary tree, write a function to get the maximum width of the given tree. The width of a tree is the maximum width among all levels. The binary tree has the same structure as a full binary tree, but some nodes are null.

The width of one level is defined as the length between the end-nodes (the leftmost and right most non-null nodes in the level, where the null nodes between the end-nodes are also counted into the length calculation.

Example 1:
Input: 

           1
         /   \
        3     2
       / \     \  
      5   3     9 

Output: 4
Explanation: The maximum width existing in the third level with the length 4 (5,3,null,9).
Example 2:
Input: 

          1
         /  
        3    
       / \       
      5   3     

Output: 2
Explanation: The maximum width existing in the third level with the length 2 (5,3).
Example 3:
Input: 

          1
         / \
        3   2 
       /        
      5      

Output: 2
Explanation: The maximum width existing in the second level with the length 2 (3,2).
Example 4:
Input: 

          1
         / \
        3   2
       /     \  
      5       9 
     /         \
    6           7
Output: 8
Explanation:The maximum width existing in the fourth level with the length 8 (6,null,null,null,null,null,null,7).


Note: Answer will in the range of 32-bit signed integer.
*/

using System;
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
        public int WidthOfBinaryTree(TreeNode root)
        {
            var q = new Queue<Tuple<TreeNode, int>>();
            q.Enqueue(Tuple.Create(root, 0));
            int res = 0;
            while (q.Count > 0)
            {
                int count = q.Count;
                int left = q.Peek().Item2;
                int right = left;
                for (int i = 0; i < count; i++)
                {
                    var t = q.Dequeue();
                    right = t.Item2;
                    if (t.Item1.left != null)
                    {
                        q.Enqueue(Tuple.Create(t.Item1.left, 2 * right));
                    }
                    if (t.Item1.right != null)
                    {
                        q.Enqueue(Tuple.Create(t.Item1.right, 2 * right + 1));
                    }
                }

                res = Math.Max(res, right - left + 1);
            }

            return res;
        }
    }
}
