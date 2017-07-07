/*
206	Reverse Linked List
easy
Reverse a singly linked list.

Hint:
A linked list can be reversed either iteratively or recursively. Could you implement both?
*/

namespace Demo
{
    public partial class Solution
    {
        public ListNode ReverseList(ListNode head)
        {
            ListNode pre = null;
            while (head != null)
            {
                ListNode next = head.next;
                head.next = pre;
                pre = head;
                head = next;
            }
            return pre;
        }

        public ListNode ReverseList2(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }
            
            var ret = ReverseList2(head.next);
            head.next.next = head;
            head.next = null;
            return ret;
        }
    }
}
