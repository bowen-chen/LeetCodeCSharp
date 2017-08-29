/*
147. Insertion Sort List
easy, *
Sort a linked list using insertion sort.
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
        public ListNode InsertionSortList(ListNode head)
        {
            var dummy = new ListNode(0);
            while (head != null)
            {
                var next = head.next;
                var p = dummy;
                while (p.next != null)
                {
                    if (p.next.val >= head.val)
                    {
                        break;
                    }
                    p = p.next;
                }

                head.next = p.next;
                p.next = head;

                head = next;
            }
            return dummy.next;
        }
    }
}
