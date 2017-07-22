/*
366	Find Leaves of Binary Tree
easy
Given a binary tree, find all leaves and then remove those leaves. Then repeat the previous steps until the tree is empty.

Example:
Given binary tree 
          1
         / \
        2   3
       / \     
      4   5    
Returns [4, 5, 3], [2], [1].

Explanation:
1. Remove the leaves [4, 5, 3] from the tree

          1
         / 
        2          
2. Remove the leaf [2] from the tree

          1          
3. Remove the leaf [1] from the tree

          []         
Returns [4, 5, 3], [2], [1].
*/

using System;
using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public List<List<int>> FindLeaves(TreeNode root)
        {
            List<List<int>> res = new List<List<int>>();
            FindLeaves(root, res);
            return res;
        }

        // return depth
        private int FindLeaves(TreeNode root, List<List<int>>  res)
        {
            if (root == null) return -1;
            int left = FindLeaves(root.left, res);
            int right = FindLeaves(root.right, res);

            // reverse depth
            int depth = 1 + Math.Max(left, right);
            if (depth >= res.Count)
            {
                res.Add(new List<int>());
            }

            res[depth].Add(root.val);
            return depth;
        }
    }
}
