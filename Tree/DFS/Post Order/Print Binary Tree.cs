/*
655. Print Binary Tree
Print a binary tree in an m*n 2D string array following these rules:

The row number m should be equal to the height of the given binary tree.
The column number n should always be an odd number.
The root node's value (in string format) should be put in the exactly middle of the first row it can be put. The column and the row where the root node belongs will separate the rest space into two parts (left-bottom part and right-bottom part). You should print the left subtree in the left-bottom part and print the right subtree in the right-bottom part. The left-bottom part and the right-bottom part should have the same size. Even if one subtree is none while the other is not, you don't need to print anything for the none subtree but still need to leave the space as large as that for the other subtree. However, if two subtrees are none, then you don't need to leave space for both of them.
Each unused space should contain an empty string "".
Print the subtrees following the same rules.
Example 1:
Input:
     1
    /
   2
Output:
[["", "1", ""],
 ["2", "", ""]]
Example 2:
Input:
     1
    / \
   2   3
    \
     4
Output:
[["", "", "", "1", "", "", ""],
 ["", "2", "", "", "", "3", ""],
 ["", "", "4", "", "", "", ""]]
Example 3:
Input:
      1
     / \
    2   5
   / 
  3 
 / 
4 
Output:

[["",  "",  "", "",  "", "", "", "1", "",  "",  "",  "",  "", "", ""]
 ["",  "",  "", "2", "", "", "", "",  "",  "",  "",  "5", "", "", ""]
 ["",  "3", "", "",  "", "", "", "",  "",  "",  "",  "",  "", "", ""]
 ["4", "",  "", "",  "", "", "", "",  "",  "",  "",  "",  "", "", ""]]
Note: The height of binary tree is in the range of [1, 10].
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
        public IList<IList<string>> PrintTree(TreeNode root)
        {
            var ret = new List<IList<string>>();
            int d = TreeDepth(root);
            int w = (1 << d) - 1;
            for (int i = 0; i < d; i++)
            {
                var t = new List<string>();
                for (int j = 0; j < w; j++)
                {
                    t.Add(string.Empty);
                }

                ret.Add(t);
            }

            PrintTree(root, 0, 0, w - 1, ret);
            return ret;
        }

        private int TreeDepth(TreeNode node)
        {
            if (node == null)
            {
                return 0;
            }

            return Math.Max(TreeDepth(node.left), TreeDepth(node.right)) + 1;
        }

        public void PrintTree(TreeNode root, int row, int left, int right, IList<IList<string>> ret)
        {
            if (root == null || row >= ret.Count)
            {
                return;
            }

            int mid = (left + right)/2;
            ret[row][mid] = root.val.ToString();
            PrintTree(root.left, row + 1, left, mid - 1, ret);
            PrintTree(root.right, row + 1, mid + 1, right, ret);
        }
    }
}
