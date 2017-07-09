/*
549	Binary Tree Longest Consecutive Sequence II
Medium
Given a binary tree, you need to find the length of Longest Consecutive Path in Binary Tree.

Especially, this path can be either increasing or decreasing. For example, [1,2,3,4] and [4,3,2,1] are both considered valid, but the path [1,2,4,3] is not valid. On the other hand, the path can be in the child-Parent-child order, where not necessarily be parent-child order.

Example 1:

Input:
        1
       / \
      2   3
Output: 2
Explanation: The longest consecutive path is [1, 2] or [2, 1].
Example 2:

Input:
        2
       / \
      1   3
Output: 3
Explanation: The longest consecutive path is [1, 2, 3] or [3, 2, 1].
*/

using System;

namespace Demo
{
    public partial class Solution
    {
        public int LongestConsecutive2(TreeNode root)
        {
            int inc;
            int dec;
            return LongestConsecutive2(root, out inc, out dec);
        }

        private int LongestConsecutive2(TreeNode root, out int inc, out int dec)
        {
            inc = 1;
            dec = 1;
            int res = 0;
            foreach (var child in new[] {root.left, root.right})
            {
                if (child != null)
                {
                    int cinc;
                    int cdec;
                    res = Math.Max(res, LongestConsecutive2(child, out cinc, out cdec));
                    if (child.val == root.val - 1)
                    {
                        dec = Math.Max(dec, cdec + 1);
                    }
                    else if (child.val == root.val + 1)
                    {
                        inc = Math.Max(inc, cinc + 1);
                    }
                }
            }

            res = Math.Max(res, inc+dec-1);
            return res;
        }
    }
}
