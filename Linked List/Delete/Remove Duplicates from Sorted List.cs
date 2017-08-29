/*
83	Remove Duplicates from Sorted List
easy, *
Given a sorted linked list, delete all duplicates such that each element appear only once.

For example,
Given 1->1->2, return 1->2.
Given 1->1->2->3->3, return 1->2->3.
*/

namespace Demo
{
    public partial class Solution
    {
        public ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null)
            {
                return null;
            }

            ListNode pre = head;
            while (pre != null)
            {
                ListNode q = pre.next;
                while (q != null && q.val == pre.val)
                {
                    q = q.next;
                }

                pre.next = q;
                pre = q;
            }

            return head;
        }
    }
}
