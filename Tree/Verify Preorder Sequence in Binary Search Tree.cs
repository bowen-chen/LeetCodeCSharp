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

        public bool VerifyPreorder(int[] preorder)
        {
            if (preorder == null || preorder.Length <= 1)
            {
                return true;
            }

            return VerifyPreorder(preorder, 0, preorder.Length - 1);
        }

        private bool VerifyPreorder(int[] preorder, int lo, int hi)
        {
            if (lo >= hi)
            {
                return true;
            }

            int root = preorder[lo];
            int i = lo + 1;
            while (i <= hi && preorder[i] < root)
            {
                i++;
            }

            int j = i;
            while (j <= hi && preorder[j] > root)
            {
                j++;
            }

            if (j <= hi)
            {
                return false;
            }

            return VerifyPreorder(preorder, lo + 1, i - 1) &&
                   VerifyPreorder(preorder, i, hi);
        }

        public bool VerifyPreorder3(int[] preorder)
        {
            int low = int.MinValue;
            var path = new Stack<int>();
            foreach (int p in preorder)
            {
                if (p < low)
                {
                    return false;
                }
                while (path.Count > 0 && p > path.Peek())
                {
                    low = path.Pop();
                }
                path.Push(p);
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
