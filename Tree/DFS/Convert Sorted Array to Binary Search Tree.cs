/*
108	Convert Sorted Array to Binary Search Tree
easy, tree
Given an array where elements are sorted in ascending order, convert it to a height balanced BST.
*/

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
        public TreeNode SortedArrayToBST(int[] nums)
        {
            return SortedArrayToBST(nums, 0, nums.Length - 1);
        }

        private TreeNode SortedArrayToBST(int[] nums, int low, int high)
        {
            if (low > high)
            {
                return null;
            }

            int mid = low + (high - low)/2;
            return new TreeNode(nums[mid])
            {
                left = SortedArrayToBST(nums, low, mid - 1),
                right = SortedArrayToBST(nums, mid + 1, high)
            };
        }
    }
}
