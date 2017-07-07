/*
medium, linked list
Given a list, rotate the list to the right by k places, where k is non-negative.

For example:
Given 1->2->3->4->5->NULL and k = 2,
return 4->5->1->2->3->NULL.
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
        public void Test_RotateRight()
        {
            RotateRight(new ListNode(1) {next = new ListNode(2)}, 3).Print();
        }

        public ListNode RotateRight(ListNode head, int k)
        {
            if (k == 0 || head == null)
            {
                return head;
            }

            int length = 0;
            var p = head;
            while (p != null)
            {
                p = p.next;
                length++;
            }

            k = k%length;

            if (k == 0)
            {
                return head;
            }
            k = length - k;
            p = head;
            int j = 1;
            ListNode newhead = null;
            while (p.next != null)
            {
                if (j == k)
                {
                    // set new head
                    var temp = p.next;
                    p.next = null;
                    p = temp;
                    newhead = temp;
                    j++;
                }
                else
                {
                    // p need go to end
                    j++;
                    p = p.next;
                }
            }

            p.next = head;
            return newhead;
        }
    }
}
