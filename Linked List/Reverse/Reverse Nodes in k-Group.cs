/*
medium
Given a linked list, reverse the nodes of a linked list k at a time and return its modified list.

If the number of nodes is not a multiple of k then left-out nodes in the end should remain as it is.

You may not alter the values in the nodes, only nodes itself may be changed.

Only constant memory is allowed.

For example,
Given this linked list: 1->2->3->4->5

For k = 2, you should return: 2->1->4->3->5

For k = 3, you should return: 3->2->1->4->5
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
        public void Test_ReverseKGroup()
        {
            ReverseKGroup(new ListNode(0) {next = new ListNode(1)}, 1);
        }

        public ListNode ReverseKGroup(ListNode head, int k)
        {
            var x = head;
            int j = k;
            while (x!= null && j>0)
            {
                x = x.next;
                j--;
            }

            if (j >0)
            {
                return head;
            }

            var dummyHead = new ListNode(0);
            var p = head;
            var tail = head;
            for (int i = k; i > 0 && p != null; i--)
            {
                var temp = p.next;
                p.next = dummyHead.next;
                dummyHead.next = p;
                p = temp;
            }

            if (p != null)
            {
                tail.next = ReverseKGroup(p, k);
            }

            return dummyHead.next;
        }

        public ListNode ReverseKGroup2(ListNode head, int k)
        {
            ListNode curr = head;
            int count = 0;
            while (curr != null && count != k)
            { 
                // find the k+1 node
                curr = curr.next;
                count++;
            }

            if (count == k)
            { 
                // if k+1 node is found
                curr = ReverseKGroup2(curr, k); // reverse list with k+1 node as head
                
                // head - head-pointer to direct part, 
                // curr - head-pointer to reversed part;
                while (count-- > 0)
                { 
                    // reverse current k-group: 
                    ListNode tmp = head.next; // tmp - next head in direct part
                    head.next = curr; // preappending "direct" head to the reversed list 
                    curr = head; // move head of reversed part to a new node
                    head = tmp; // move "direct" head to the next node in direct part
                }

                head = curr;
            }

            return head;
        }
    }
}
