/*
142	Linked List Cycle II
Easy, linkedlist
Given a linked list, return the node where the cycle begins. If there is no cycle, return null.

Note: Do not modify the linked list.

Follow up:
Can you solve it without using extra space?
*/

namespace Demo
{
    public partial class Solution
    {
        public ListNode DetectCycle(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;
            while (slow != null && fast != null)
            {
                slow = slow.next;
                fast = fast.next;
                if (fast != null)
                {
                    fast = fast.next;
                }

                if (slow == fast)
                {
                    break;
                }
            }

            if (slow == null || fast == null)
            {
                return null;
            }

            slow = head;
            while (slow != fast)
            {
                slow = slow.next;
                fast = fast.next;
            }
            return slow;
        }
    }
}
