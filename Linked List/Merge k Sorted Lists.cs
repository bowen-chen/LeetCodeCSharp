/*
23	Merge k Sorted Lists
Merge k sorted linked lists and return it as one sorted list. Analyze and describe its complexity.
*/

using System.Collections.Generic;
using Demo.Common;

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
        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists == null || lists.Length == 0)
            {
                return null;
            }

            PriorityQueue<ListNode> queue =
                new PriorityQueue<ListNode>(lists.Length, Comparer<ListNode>.Create(
                    (n1, n2) => Comparer<int>.Default.Compare(n1.val, n2.val)));
            
            foreach (ListNode node in lists)
            {
                if (node != null)
                {
                    queue.Push(node);
                }
            }

            ListNode dummy = new ListNode(0);
            ListNode tail = dummy;
            while (queue.Count != 0)
            {
                tail.next = queue.Pop();
                tail = tail.next;

                if (tail.next != null)
                {
                    queue.Push(tail.next);
                }
            }

            return dummy.next;
        }
    }
}
