/*
109	Convert Sorted List to Binary Search Tree
medium, tree
Given a singly linked list where elements are sorted in ascending order, convert it to a height balanced BST.
*/

namespace Demo
{
    /**
     * Definition for singly-linked list.
     * public class ListNode {
     *     public int val;
     *     public ListNode next;
     *     public ListNode(int x) { val = x; }
     * }
     */
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
        public TreeNode SortedListToBST(ListNode head)
        {
            if (head == null)
            {
                return null;
            }

            int size = 0;
            ListNode runner = head;
            while (runner != null)
            {
                runner = runner.next;
                size++;
            }

            ListNode node = head;
            return SortedListToBST(ref node, 0, size - 1);
        }

        private TreeNode SortedListToBST(ref ListNode node, int high, int low)
        {
            if (low > high)
            {
                return null;
            }

            int mid = low + (high - low) / 2;
            TreeNode left = SortedListToBST(ref node, low, mid - 1);

            TreeNode treenode = new TreeNode(node.val);
            treenode.left = left; 
            node = node.next;

            treenode.right = SortedListToBST(ref node, mid + 1, high);

            return treenode;
        }
    }
}
