/*
328	Odd Even Linked List
medium, linked list
Given a singly linked list, group all odd nodes together followed by the even nodes. Please note here we are talking about the node number and not the value in the nodes.

You should try to do it in place. The program should run in O(1) space complexity and O(nodes) time complexity.

Example:
Given 1->2->3->4->5->NULL,
return 1->3->5->2->4->NULL.

Note:
The relative order inside both the even and odd groups should remain as it was in the input. 
The first node is considered odd, the second node even and so on ...
*/

namespace Demo
{
    /**
     * Definition for singly-linked list.
     * public class ListNode {
     *     public int val;
     *     public ListNode next;
     *     public ListNode(int x) { val = x; }
     * }
     */
    public partial class Solution
    {
        public ListNode OddEvenList2(ListNode head)
        {
            if (head != null)
            {
                ListNode odd = head, even = head.next, evenHead = even;
                while (even != null && even.next != null)
                {
                    odd.next = odd.next.next;
                    even.next = even.next.next;
                    odd = odd.next;
                    even = even.next;
                }
                odd.next = evenHead;
            }
            return head;
        }

        public ListNode OddEvenList(ListNode head)
        {
            var oHead = new ListNode(0);
            var oTail = oHead;
            var eHead = new ListNode(0);
            var eTail = eHead;
            int i = 1;
            while (head != null)
            {
                if (i % 2 == 0)
                {
                    eTail.next = head;
                    eTail = head;
                }
                else
                {
                    oTail.next = head;
                    oTail = head;
                }
                i++;
                head = head.next;
            }

            eTail.next = null;
            oTail.next = null;

            if (eHead.next != null)
            {
                oTail.next = eHead.next;
            }

            return oHead.next ?? eHead.next;
        }
    }
}
