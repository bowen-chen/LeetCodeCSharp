﻿/*
203	Remove Linked List Elements	
easy, linked list, *
Remove Linked List Elements

Remove all elements from a linked list of integers that have value val.

Example
Given: 1 --> 2 --> 6 --> 3 --> 4 --> 5 --> 6, val = 6
Return: 1 --> 2 --> 3 --> 4 --> 5
*/

namespace Demo
{
    public partial class Solution
    {
        public ListNode RemoveElements(ListNode head, int val)
        {
            var ret = new ListNode(0);
            var pre = ret;
            while (pre.next != null)
            {
                if (pre.next.val == val)
                {
                    pre.next = pre.next.next;
                }
                else
                {
                    pre = pre.next;
                }
            }

            return ret.next;
        }

        public ListNode RemoveElements2(ListNode head, int val)
        {
            if (head == null)
            {
                return null;
            }

            head.next = RemoveElements2(head.next, val);
            return head.val == val ? head.next : head;
        }
    }
}
