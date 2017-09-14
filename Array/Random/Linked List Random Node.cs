/*
382. Linked List Random Node
easy, *
Given a singly linked list, return a random node's value from the linked list. Each node must have the same probability of being chosen.

Follow up:
What if the linked list is extremely large and its length is unknown to you? Could you solve this efficiently without using extra space?

Example:

// Init a singly linked list [1,2,3].
ListNode head = new ListNode(1);
head.next = new ListNode(2);
head.next.next = new ListNode(3);
Solution solution = new Solution(head);

// getRandom() should return either 1, 2, or 3 randomly. Each element should have equal probability of returning.
solution.getRandom();
*/

using System;

namespace Demo
{
    public class RandLinkedListSolution
    {
        private readonly ListNode _head;
        private readonly Random _rd = new Random();
        /** @param head The linked list's head.
            Note that the head is guaranteed to be not null, so it contains at least one node. */

        public RandLinkedListSolution(ListNode head)
        {
            _head = head;
        }

        /** Returns a random node's value.
        Reservoir sampling*/
        public int GetRandom()
        {
            int res = 0;
            int i = 1;
            ListNode cur = _head;
            while (cur != null)
            {
                if (_rd.Next(i) == 0)
                {
                    res = cur.val;
                }

                ++i;
                cur = cur.next;
            }

            return res;
        }
    }

    /**
     * Your Solution object will be instantiated and called as such:
     * Solution obj = new Solution(head);
     * int param_1 = obj.GetRandom();
     */
}
