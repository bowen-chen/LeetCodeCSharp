/*
113	Path Sum II
easy, tree
Given a binary tree and a sum, find all root-to-leaf paths where each path's sum equals the given sum.

For example:
Given the below binary tree and sum = 22,
              5
             / \
            4   8
           /   / \
          11  13  4
         /  \    / \
        7    2  5   1
return
[
   [5,4,11,2],
   [5,8,4,5]
]
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public IList<IList<int>> PathSum(TreeNode root, int sum)
        {
            IList<IList<int>> ret = new List<IList<int>>();
            CheckSum(root, sum, 0, new List<int>(), ret);
            return ret;
        }

        private void CheckSum(TreeNode root, int sum, int current, IList<int> currentList, IList<IList<int>> ret)
        {
            if (root == null)
            {
                return;
            }

            current += root.val;
            currentList.Add(root.val);
            if (root.left == null && root.right == null && current == sum)
            {
                ret.Add(new List<int>(currentList));
            }

            CheckSum(root.left, sum, current, currentList, ret);
            CheckSum(root.right, sum, current, currentList, ret);
            currentList.RemoveAt(currentList.Count - 1);
        }
    }
}
