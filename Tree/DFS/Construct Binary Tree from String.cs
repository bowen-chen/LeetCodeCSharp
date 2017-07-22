/*
536	Construct Binary Tree from String 
easy
You need to construct a binary tree from a string consisting of parenthesis and integers.

The whole input represents a binary tree. It contains an integer followed by zero, one or two pairs of parenthesis. The integer represents the root's value and a pair of parenthesis contains a child binary tree with the same structure.

You always start to construct the left child node of the parent first if it exists.

Example:

Input: "4(2(3)(1))(6(5))"
Output: return the tree root node representing the following tree:

       4
     /   \
    2     6
   / \   / 
  3   1 5  
*/

using System.Diagnostics;

namespace Demo
{
    public partial class Solution
    {
        public TreeNode Str2Tree(string s)
        {
            int index = 0;
            return Str2Tree(s, ref index);
        }

        public TreeNode Str2Tree(string s, ref int index)
        {
            // must begin with a number
            if (s[index] != '-' && !(s[index] >= '0' || s[index] <= '9'))
            {
                return null;
            }

            int j = s.IndexOfAny(new[] {'(', ')'}, index);
            TreeNode n = new TreeNode(int.Parse(s.Substring(index, j - index)));
            index = j;

            // if it is ')', then it is a leaf

            // it is not a leaf, parse first child
            if (s[index] == '(')
            {
                index++; // eat '('
                n.left = Str2Tree(s, ref index);
                Debug.Assert(s[index] == ')');
                index++; // eat ')'
            }


            // parse second child
            if (s[index] == '(')
            {
                index++; // eat '('
                n.right = Str2Tree(s, ref index);
                Debug.Assert(s[index] == ')');
                index++; // eat ')'
            }

            return n;
        }
    }
}
