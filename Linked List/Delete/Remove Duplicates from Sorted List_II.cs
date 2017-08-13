/*
82	Remove Duplicates from Sorted List II
easy
Given a sorted linked list, delete all nodes that have duplicate numbers, leaving only distinct numbers from the original list.

For example,
Given 1->2->3->3->4->4->5, return 1->2->5.
Given 1->1->1->2->3, return 2->3.
*/

namespace Demo
{
    public partial class Solution
    {
        public ListNode DeleteDuplicatesList2(ListNode head)
        {
            var ret = new ListNode(0);
            var pre = ret;
            while (head != null)
            {
                int val = head.val;
                if (head.next == null || val != head.next.val)
                {
                    pre.next = head;
                    pre = head;
                    head = head.next;
                }
                else
                {
                    while (head != null && head.val == val)
                    {
                        head = head.next;
                    }
                }
            }

            pre.next = null;
            return ret.next;
        }
    }
}
