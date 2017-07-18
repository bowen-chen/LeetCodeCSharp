/*
141	Linked List Cycle
easy
Given a linked list, determine if it has a cycle in it.

Follow up:
Can you solve it without using extra space?
*/
/*
Given a linked list, determine if it has a cycle in it.

Follow up:
Can you solve it without using extra space?
*/
namespace Demo
{
    public partial class Solution
    {
        public bool HasCycle(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;
            if (fast != null)
            {
                fast = fast.next;
            }

            while (slow != null && fast != null)
            {
                if (slow == fast)
                {
                    return true;
                }

                slow = slow.next;
                fast = fast.next;
                if (fast != null)
                {
                    fast = fast.next;
                }
            }
            return false;
        }
    }
}
