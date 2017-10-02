/*
663	Equal Tree Partition
Given a binary tree with n nodes, your task is to check if it's possible to partition the tree to two trees which have the equal sum of values after removing exactly one edge on the original tree.

Example 1:

Input:     
    5
   / \
  10 10
    /  \
   2   3

Output: True
Explanation: 
    5
   / 
  10
      
Sum: 15

   10
  /  \
 2    3

Sum: 15
 

Example 2:

Input:     
    1
   / \
  2  10
    /  \
   2   20

Output: False
Explanation: You can't split the tree into two trees with equal sum after removing exactly one edge on the tree.
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public bool CheckEqualTree(TreeNode root)
        {
            var m = new Dictionary<int, int>();
            int sum = CheckEqualTree(root, m);
            if (sum == 0)
            {
                return m[0] > 1; /*make sure it is not same node*/
            }

            return sum % 2 == 0 && m.ContainsKey(sum / 2);
        }

        public int CheckEqualTree(TreeNode root, Dictionary<int, int> m)
        {
            if (root == null)
            {
                return 0;
            }

            var left = CheckEqualTree(root.left, m);
            var right = CheckEqualTree(root.right, m);
            var sum = left + right + root.val;
            if (!m.ContainsKey(sum))
            {
                m[sum] = 0;
            }

            m[sum]++;
            return sum;
        }
    }
}
