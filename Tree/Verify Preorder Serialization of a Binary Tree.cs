/*
331	Verify Preorder Serialization of a Binary Tree
medium, tree
One way to serialize a binary tree is to use pre-order traversal.When we encounter a non-null node, we record the node's value. If it is a null node, we record using a sentinel value such as #.

     _9_
    /   \
   3     2
  / \   / \
 4   1  #  6
/ \ / \   / \
# # # #   # #
For example, the above binary tree can be serialized to the string "9,3,4,#,#,1,#,#,2,#,6,#,#", where # represents a null node.

Given a string of comma separated values, verify whether it is a correct preorder traversal serialization of a binary tree.Find an algorithm without reconstructing the tree.

Each comma separated value in the string must be either an integer or a character '#' representing null pointer.

You may assume that the input format is always valid, for example it could never contain two consecutive commas such as "1,,3".

Example 1:
"9,3,4,#,#,1,#,#,2,#,6,#,#"
Return true

Example 2:
"1,#"
Return false

Example 3:
"9,#,#,1"
Return false
*/

using System;

namespace Demo
{
    public partial class Solution
    {
        public void Test_IsValidSerialization()
        {
            IsValidSerialization("9,3,4,#,#,1,#,#,2,#,6,#,#");
        }

        public bool IsValidSerialization(string preorder)
        {
            var tokens = preorder.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
            bool? [,] dp = new bool?[tokens.Length, tokens.Length];
            return IsValidSerialization(dp, tokens, 0, tokens.Length - 1);
        }

        private bool IsValidSerialization(bool?[,] dp, string[] tokens, int s, int e)
        {
            if (dp[s, e] != null)
            {
                return dp[s, e].Value;
            }
            bool ret = false;
            if (tokens[s] == "#")
            {
                ret = e == s;
            }
            else
            {
                for (int i = s + 1; i <= e - 1; i++)
                {
                    if (IsValidSerialization(dp, tokens, s + 1, i) && IsValidSerialization(dp, tokens, i + 1, e))
                    {
                        ret = true;
                        break;
                    }
                }
            }
            dp[s, e] = ret;
            return ret;
        }

        public bool IsValidSerialization2(string preorder)
        {
            string[] tokens = preorder.Split(',');
            int slot = 1;
            foreach (string node in tokens)
            {
                if (--slot < 0)
                {
                    return false;
                }

                if (!node.Equals("#"))
                {
                    slot += 2;
                }
            }

            return slot == 0;
        }
    }
}
