/*
138	Copy List with Random Pointer   
easy, linkedlist, *
A linked list is given such that each node contains an additional random pointer which could point to any node in the list or null.

Return a deep copy of the list.
*/

namespace Demo
{
    public partial class Solution
    {
        public class RandomListNode
        {
            public int label;
            public RandomListNode next, random;

            public RandomListNode(int x)
            {
                this.label = x;
            }
        };

        public RandomListNode CopyRandomList(RandomListNode head)
        {
            if (head == null)
            {
                return null;
            }
            
            var p = head;

            // Create a copy of the node after each node.
            RandomListNode q;
            while (p != null)
            {
                q = new RandomListNode(p.label)
                {
                    next = p.next
                };

                p.next = q;
                p = p.next.next;
            }

            // Fix the random point 
            p = head;
            while (p != null)
            {
                if (p.random != null)
                {
                    p.next.random = p.random.next;
                }

                p = p.next.next;
            }

            // break the link
            p = head;
            var newhead = p.next;
            q = newhead;
            while (p != null)
            {
                p.next = p.next.next;
                p = p.next;
                if (p != null)
                {
                    q.next = p.next;
                    q = q.next;
                }
            }

            return newhead;
        }
    }
}
