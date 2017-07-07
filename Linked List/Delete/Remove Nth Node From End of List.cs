/*
19	Remove Nth Node From End of List
easy, linked list
Given a linked list, remove the nth node from the end of list and return its head.

For example,

   Given linked list: 1->2->3->4->5, and n = 2.

   After removing the second node from the end, the linked list becomes 1->2->3->5.
Note:
Given n will always be valid.
Try to do this in one pass.
*/

namespace Demo
{
    public partial class Solution
    {
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode start = new ListNode(0);
            start.next = head;

            ListNode slow = start;
            ListNode fast = start;

            //Move fast in front so that the gap between slow and fast becomes n
            for (int i = 0; i <= n; i++)
            {
                fast = fast.next;
            }

            //Move fast to the end, maintaining the gap
            while (fast != null)
            {
                slow = slow.next;
                fast = fast.next;
            }

            //Skip the desired node
            slow.next = slow.next.next;
            return start.next;
        }
    }
}
