/*
255	Verify Preorder Sequence in Binary Search Tree
hard
Given an array of numbers, verify whether it is the correct preorder traversal sequence of a binary search tree.
You may assume each number in the sequence is unique.

Follow up:
Could you do it using only constant space complexity?
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public bool VerifyPreorder2(int[] preorder)
        {
            int low = int.MinValue;
            var s = new Stack<int>();
            foreach (int a in preorder)
            {
                if (a < low)
                {
                    return false;
                }

                while (s.Count !=0 && a > s.Peek())
                {
                    low = s.Pop();
                }

                s.Push(a);
            }

            return true;
        }

        public bool VerifyPreorder10(int[] preorder)
        {
            int low = int.MinValue;
            int i = -1;
            foreach (int p in preorder)
            {
                if (p < low)
                {
                    return false;
                }

                while (i >= 0 && p > preorder[i])
                {
                    low = preorder[i--];
                }

                preorder[++i] = p;
            }
            return true;
        }
    }
}
