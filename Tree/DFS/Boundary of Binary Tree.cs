/*
545	Boundary of Binary Tree
easy
Given a binary tree, return the values of its boundary in anti-clockwise direction starting from root. Boundary includes left boundary, leaves, and right boundary in order without duplicate nodes.

Left boundary is defined as the path from root to the left-most node. Right boundary is defined as the path from root to the right-most node. If the root doesn't have left subtree or right subtree, then the root itself is left boundary or right boundary. Note this definition only applies to the input binary tree, and not applies to any subtrees.

The left-most node is defined as a leaf node you could reach when you always firstly travel to the left subtree if exists. If not, travel to the right subtree. Repeat until you reach a leaf node.

The right-most node is also defined by the same way with left and right exchanged.

Example 1

Input:
  1
   \
    2
   / \
  3   4

Ouput:
[1, 3, 4, 2]

Explanation:
The root doesn't have left subtree, so the root itself is left boundary.
The leaves are node 3 and 4.
The right boundary are node 1,2,4. Note the anti-clockwise direction means you should output reversed right boundary.
So order them in anti-clockwise without duplicates and we have [1,3,4,2].
 

Example 2

Input:
    ____1_____
   /          \
  2            3
 / \          / 
4   5        6   
   / \      / \
  7   8    9  10  
       
Ouput:
[1,2,4,7,8,9,10,6,3]

Explanation:
The left boundary are node 1,2,4. (4 is the left-most node according to definition)
The leaves are node 4,7,8,9,10.
The right boundary are node 1,3,6,10. (10 is the right-most node).
So order them in anti-clockwise without duplicate nodes we have [1,2,4,7,8,9,10,6,3].
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {

        // A function to do boundary traversal of a given binary tree
        public IList<int> LeftBoundaryOfBinaryTree(TreeNode node)
        {
            var ret = new List<int>();
            if (node != null)
            {
                ret.Add(node.val);

                // Print the left boundary in top-down manner.
                LeavesOfBinaryTree(node.left, ret);

                // Print all leaf nodes
                LeavesOfBinaryTree(node.left, ret);
                LeavesOfBinaryTree(node.right, ret);

                // Print the right boundary in bottom-up manner
                RightBoundaryOfBinaryTree(node.right, ret);
            }

            return ret;
        }

        // A simple function to print leaf nodes of a binary tree
        public void LeavesOfBinaryTree(TreeNode node, List<int> output)
        {
            if (node != null)
            {
                LeavesOfBinaryTree(node.left, output);

                // Print it if it is a leaf node
                if (node.left == null && node.right == null)
                {
                    output.Add(node.val);
                }
                LeavesOfBinaryTree(node.right, output);
            }
        }

        // A function to print all left boundry nodes, except a leaf node.
        // Print the nodes in TOP DOWN manner
        private void LeftBoundaryOfBinaryTree(TreeNode node, List<int> output)
        {
            if (node != null)
            {
                if (node.left != null)
                {

                    // to ensure top down order, print the node
                    // before calling itself for left subtree
                    output.Add(node.val);
                    LeftBoundaryOfBinaryTree(node.left, output);
                }
                else if (node.right != null)
                {
                    output.Add(node.val);
                    LeftBoundaryOfBinaryTree(node.right, output);
                }

                // do nothing if it is a leaf node, this way we avoid
                // duplicates in output
            }
        }

        // A function to print all right boundry nodes, except a leaf node
        // Print the nodes in BOTTOM UP manner
        private void RightBoundaryOfBinaryTree(TreeNode node, List<int> output)
        {
            if (node != null)
            {
                if (node.right != null)
                {
                    // to ensure bottom up order, first call for right
                    //  subtree, then print this node
                    RightBoundaryOfBinaryTree(node.right, output);
                    output.Add(node.val);
                }
                else if (node.left != null)
                {
                    RightBoundaryOfBinaryTree(node.left, output);
                    output.Add(node.val);
                }
                // do nothing if it is a leaf node, this way we avoid
                // duplicates in output
            }
        }
    }
}
