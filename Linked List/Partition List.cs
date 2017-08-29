/*
86 Partition List   
easy, linked list, *
Given a linked list and a value x, partition it such that all nodes less than x come before nodes greater than or equal to x.

You should preserve the original relative order of the nodes in each of the two partitions.

For example,
Given 1->4->3->2->5->2 and x = 3,
return 1->2->2->4->3->5.
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
        public ListNode Partition(ListNode head, int x)
        {
            ListNode lh = new ListNode(0);
            ListNode hh = new ListNode(0);
            ListNode le = lh;
            ListNode he = hh;
            while (head != null)
            {
                if (head.val < x)
                {
                    le.next = head;
                    le = le.next;
                }
                else
                {
                    he.next = head;
                    he = he.next;
                }

                head = head.next;
            }

            le.next = hh.next;
            he.next = null;
            return lh.next;
        }
    }
}
