/*
234	Palindrome Linked List
medium, linked list
Palindrome Linked List

Given a singly linked list, determine if it is a palindrome.

Follow up:
Could you do it in O(n) time and O(1) space?
*/

namespace Demo
{
    public partial class Solution
    {
        public bool IsPalindrome(ListNode head)
        {
            if (head == null)
            {
                return true;
            }

            ListNode pre = head;
            ListNode fast = head;
            ListNode slow = pre.next;

            //find mid pointer, and reverse head half part
            while (fast.next != null && fast.next.next != null)
            {
                fast = fast.next.next;

                var prepre = pre;
                pre = slow;
                pre.next = prepre;
                slow = slow.next;
            }

            //odd number of elements, need left move p1 one step
            if (fast.next == null)
            {
                pre = pre.next;
            }

            //compare from mid to head/tail
            while (slow != null)
            {
                if (pre.val != slow.val)
                {
                    return false;
                }

                pre = pre.next;
                slow = slow.next;
            }
            return true;
        }
    }
}
