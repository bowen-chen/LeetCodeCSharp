/*
143	Reorder List
easy, linked list
Given a singly linked list L: L0→L1→…→Ln-1→Ln,
reorder it to: L0→Ln→L1→Ln-1→L2→Ln-2→…

You must do this in-place without altering the nodes' values.

For example,
Given {1,2,3,4}, reorder it to {1,4,2,3}.
*/

using System.Collections.Generic;
namespace Demo
{
    public partial class Solution
    {
        public void ReorderList_Test()
        {
            var head = new ListNode(1) {next = new ListNode(2)};
            head.Print();
            ReorderList(head);
            head.Print();
        }

        public void ReorderList(ListNode head)
        {
            if (head == null)
            {
                return;
            }

            var stack = new Stack<ListNode>();
            var p = head;
            while (p != null)
            {
                stack.Push(p);
                p = p.next;
            }

            int i = 0;
            int j = stack.Count - 1;
            p = head;
            var q = stack.Pop();
            while (i < j)
            {
                q.next = p.next;
                p.next = q;
                p = q;

                q = stack.Pop();
                p = p.next;
                i++;
                j--;
            }

            p.next = null;
        }

        public ListNode ReorderList2(ListNode head)
        {
            if (head == null)
            {
                return null;
            }

            ListNode slow = head;
            ListNode fast = head;

            while (fast.next != null && fast.next.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }

            ListNode second = slow.next;
            slow.next = null;

            return Merge(head, Reverse(second));
        }

        private ListNode Reverse(ListNode head)
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

        private ListNode Merge(ListNode first, ListNode second)
        {
            if (first == null)
            {
                return second;
            }

            ListNode ret = first;
            ListNode p = ret;
            first = first.next;
            while (first != null && second != null)
            {
                p.next = second;
                p = second;
                second = second.next;
                p.next = first;
                p = first;
                first = first.next;
            }
            if (first != null)
            {
                p.next = first;
            }
            if (second != null)
            {
                p.next = second;
            }
            return ret;
        }
    }
}
