/*
148	Sort List
hard
Sort a linked list in O(n log n) time using constant space complexity.
*/

namespace Demo
{
    public partial class Solution
    {
        public ListNode SortList(ListNode head)
        {
            if (head == null)
            {
                return null;
            }

            return QuickSort(head, null)[0];
        }

        // sort from head to node before end
        ListNode[] QuickSort(ListNode head, ListNode end)
        {
            if (head == null || head == end)
            {
                return null;
            }

            // only 1 node in the list
            var ret = new ListNode[2];
            if (head.next == end)
            {
                ret[0] = head;
                ret[1] = head;
                return ret;
            }

            ListNode pivot = head;
            ListNode[] p = Partition(head, end);

            // p[1] is always pivot
            ListNode[] p1 = QuickSort(p[0], pivot);
            if (p1 != null)
            {
                p1[1].next = p[1];
                ret[0] = p1[0];
            }
            else
            {
                ret[0] = pivot;
            }
            
            ListNode[] p2 = QuickSort(p[1].next, end);
            if (p2 != null)
            {
                p[1].next = p2[0];
                ret[1] = p2[1];
            }
            else
            {
                ret[1] = p[1];
            }

            return ret;
        }


        // return two partition head divided by head.
        ListNode[] Partition(ListNode head, ListNode end)
        {
            var ret = new []
            {
                head, head
            };

            if (head.next == end)
            {
                return ret;
            }

            ListNode p = head.next;
            head.next = end;
            while (p != end)
            {
                ListNode next = p.next;
                if (p.val >= head.val)
                {
                    p.next = ret[1].next;
                    ret[1].next = p;
                    if (p.val == ret[1].val)
                    {
                        ret[1] = p;
                    }
                }
                else
                {
                    p.next = ret[0];
                    ret[0] = p;
                }

                p = next;
            }

            return ret;
        }

        // Merge sort
        public ListNode SortList2(ListNode head)
        {
            return MergeSort(head, head.Count);
        }

        public ListNode MergeSort(ListNode head, int count)
        {
            if (count == 0 || head == null)
            {
                return null;
            }

            if (count == 1)
            {
                return head;
            }

            int count1 = count/2;
            int count2 = count - count1;
            ListNode head2 = head;
            for (int i = 0; i < count1; i++)
            {
                head2 = head2.next;
            }

            return Merge(MergeSort(head, count1), count1, MergeSort(head2, count2), count2);
        }

        public ListNode Merge(ListNode head1, int count1, ListNode head2, int count2)
        {
            ListNode ret = new ListNode(0);
            ListNode end = ret;
            while (count1 > 0 && count2 > 0)
            {
                if (head1.val < head2.val)
                {
                    end.next = head1;
                    end = head1;
                    head1 = head1.next;
                    count1--;
                }
                else
                {
                    end.next = head2;
                    end = head2;
                    head2 = head2.next;
                    count2--;
                }
            }

            while (count1 > 0)
            {
                end.next = head1;
                end = head1;
                head1 = head1.next;
                count1--;
            }

            while (count2 > 0)
            {
                end.next = head2;
                end = head2;
                head2 = head2.next;
                count2--;
            }

            end.next = null;

            return ret.next;
        }
    }
}
