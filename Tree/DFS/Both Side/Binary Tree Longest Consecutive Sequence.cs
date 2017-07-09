/*
298	Binary Tree Longest Consecutive Sequence 
easy
Binary Tree Longest Consecutive Sequence
Given a binary tree, find the length of the longest consecutive sequence path.
The path refers to any sequence of nodes from some starting node to any node in the tree along the parent-child connections. The longest consecutive path need to be from parent to child (cannot be the reverse).
For example,
   1
    \
     3
    / \
   2   4
        \
         5
Longest consecutive sequence path is 3-4-5, so return 3.
   2
    \
     3
    / 
   2    
  / 
 1
Longest consecutive sequence path is 2-3,not3-2-1, so return 2.
*/
using System;

namespace Demo
{
    public partial class Solution
    {
        public int LongestConsecutive(TreeNode root)
        {
            if (root == null) return 0;
            int ret = 1;
            LongestConsecutive(root, 1, root.val, ref ret);
            return ret;
        }

        public void LongestConsecutive(TreeNode root, int currentLength, int parent, ref int res)
        {
            if (root == null)
            {
                return;
            }
            if (root.val == parent + 1)
            {
                currentLength++;
            }
            else
            {
                currentLength = 1;
            }
            res = Math.Max(current, res);
            LongestConsecutive(root.left, currentLength, root.val, ref res);
            LongestConsecutive(root.right, currentLength, root.val, ref res);
        }
    }
}
