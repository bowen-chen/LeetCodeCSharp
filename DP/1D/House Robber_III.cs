/*
337	House Robber III 
easy, tree, *
The thief has found himself a new place for his thievery again. There is only one entrance to this area, called the "root." Besides the root, each house has one and only one parent house. After a tour, the smart thief realized that "all houses in this place forms a binary tree". It will automatically contact the police if two directly-linked houses were broken into on the same night.

Determine the maximum amount of money the thief can rob tonight without alerting the police.

Example 1:
     3
    / \
   2   3
    \   \ 
     3   1
Maximum amount of money the thief can rob = 3 + 3 + 1 = 7.
Example 2:
     3
    / \
   4   5
  / \   \ 
 1   3   1
Maximum amount of money the thief can rob = 4 + 5 = 9.
*/
using System;

namespace Demo.DP._1D
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
    public class Solution
    {
        public int Rob(TreeNode root)
        {
            int rob;
            int notrob;
            Rob(root, out rob, out notrob);
            return Math.Max(rob, notrob);
        }

        private void Rob(TreeNode root, out int rob, out int notrob)
        {
            if (root == null)
            {
                rob = 0;
                notrob = 0;
                return;
            }

            int leftrob;
            int leftnotrob;
            Rob(root.left, out leftrob, out leftnotrob);
            int rightrob;
            int rightnotrob;
            Rob(root.right, out rightrob, out rightnotrob);

            rob = root.val + leftnotrob + rightnotrob;
            notrob = Math.Max(leftrob, leftnotrob) + Math.Max(rightrob, rightnotrob);
        }
    }
}
