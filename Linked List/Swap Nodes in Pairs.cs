/*
24	Swap Nodes in Pairs
easy, linked list
Given a linked list, swap every two adjacent nodes and return its head.

For example,
Given 1->2->3->4, you should return the list as 2->1->4->3.

Your algorithm should use only constant space. You may not modify the values in the list, only nodes itself can be changed.
*/

namespace Demo
{
    public partial class Solution
    {
        public ListNode SwapPairs(ListNode head)
        {
            if (head == null || head.next ==null)
            {
                return head;
            }
            var p = head;
            var q = head.next;
            var newhead = SwapPairs(q.next);
            q.next = p;
            p.next = newhead;
            return q;
        }
        public ListNode SwapPairs2(ListNode head)
        {
            ListNode ret = new ListNode(0);
            ret.next = head;
            ListNode current = ret;
            while (current.next != null && current.next.next != null)
            {
                ListNode first = current.next;
                ListNode second = current.next.next;

                first.next = second.next;
                second.next = first;
                current.next = second;
                current = current.next.next;
            }
            return ret.next;
        }
    }
}
