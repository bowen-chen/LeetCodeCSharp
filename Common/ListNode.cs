using System;

namespace Demo
{
    //Definition for singly-linked list.
    public class ListNode
    {
        public int val;

        public ListNode next;

        public ListNode(int x)
        {
            val = x;
        }

        public void Print()
        {
            Console.Write(val);
            var p = next;
            while (p != null)
            {
                Console.Write(", {0}", p.val);
                p = p.next;
            }
            Console.WriteLine();
        }

        public int Count
        {
            get
            {
                int i = 0;
                var head = this;
                while (head != null)
                {
                    i++;
                    head = head.next;
                }

                return i;
            }
        }
    }
}
