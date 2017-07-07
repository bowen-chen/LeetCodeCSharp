/*
437. Path Sum III
medium
You are given a binary tree in which each node contains an integer value.

Find the number of paths that sum to a given value.

The path does not need to start or end at the root or a leaf, but it must go downwards (traveling only from parent nodes to child nodes).

The tree has no more than 1,000 nodes and the values are in the range -1,000,000 to 1,000,000.

Example:

root = [10,5,-3,3,2,null,11,3,-2,null,1], sum = 8

      10
     /  \
    5   -3
   / \    \
  3   2   11
 / \   \
3  -2   1

Return 3. The paths that sum to 8 are:

1.  5 -> 3
2.  5 -> 2 -> 1
3. -3 -> 11
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
        public int PathSum3(TreeNode root, int sum)
        {
            var m = new Dictionary<int, int>
            {
                [0] = 1
            };

            return PathSum3(root, sum, 0, m);
        }

        public int PathSum3(TreeNode node, int sum, int curSum, Dictionary<int, int> m)
        {
            if (node == null)
            {
                return 0;
            }

            curSum += node.val;
            int res = 0;
            if (m.ContainsKey(curSum - sum))
            {
                res += m[curSum - sum];
            }

            if (!m.ContainsKey(curSum))
            {
                m[curSum] = 0;
            }

            ++m[curSum];
            res += PathSum3(node.left, sum, curSum, m) + PathSum3(node.right, sum, curSum, m);
            // remove the path to this node
            --m[curSum];
            return res;
        }
    }
}
