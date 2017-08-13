/*
92	Reverse Linked List II
easy
Reverse a linked list from position m to n. Do it in-place and in one-pass.

For example:
Given 1->2->3->4->5->NULL, m = 2 and n = 4,

return 1->4->3->2->5->NULL.

Note:
Given m, n satisfy the following condition:
1 ≤ m ≤ n ≤ length of list.
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
        public ListNode ReverseBetween(ListNode head, int m, int n)
        {
            if (m == n)
            {
                return head;
            }

            // in case m = 0
            ListNode ret = new ListNode(0)
            {
                next = head
            };

            ListNode reverseHead = ret;
            n -= m;
            while (m != 1) /*m is 1 based*/
            {
                reverseHead = reverseHead.next;
                m--;
            }

            ListNode reverseTail = reverseHead.next;
            while (n>0)
            {
                ListNode q = reverseTail.next;
                reverseTail.next = q.next;
                q.next = reverseHead.next;
                reverseHead.next = q;
                n--;
            }

            return ret.next;
        }
    }
}
