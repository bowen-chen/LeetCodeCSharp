/*
hard
Sort a linked list in O(n log n) time using constant space complexity.
*/

using System.Data;

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

            return QuickSort(head, null).first;
        }

        // sort from head to node before end
        Pair<ListNode> QuickSort(ListNode head, ListNode end)
        {
            if (head == null || head == end)
            {
                return null;
            }

            // only head in the list
            var ret = new Pair<ListNode>();
            if (head.next == end)
            {
                ret.first = head;
                ret.second = head;
                return ret;
            }

            ListNode pivot = head;
            Pair<ListNode> p = Partition(head, end);

            Pair<ListNode> p1 = QuickSort(p.first, pivot);
            if (p1 != null)
            {
                p1.second.next = pivot;
                ret.first = p1.first;
            }
            else
            {
                ret.first = pivot;
            }
            Pair<ListNode> p2 = QuickSort(p.second.next, end);
            if (p2 != null)
            {
                p.second.next = p2.first;
                ret.second = p2.second;
            }
            else
            {
                ret.second = p.second;
            }

            return ret;
        }


        // return two partition head divided by head.
        Pair<ListNode> Partition(ListNode head, ListNode end)
        {
            Pair<ListNode> ret = new Pair<ListNode>
            {
                first = head,
                second = head
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
                if (p.val >= ret.second.val)
                {
                    ListNode temp = ret.second.next;
                    ret.second.next = p;
                    p.next = temp;
                    if (p.val == ret.second.val)
                    {
                        ret.second = p;
                    }
                }
                else
                {
                    p.next = ret.first;
                    ret.first = p;
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


        // Buble Down
        public ListNode SortList3 (ListNode head)
        {
            if (head == null)
            {
                return null;
            }

            ListNode ret = new ListNode(0) {next = head};
            ListNode newend = null;
            bool changed = false;

            do
            {
                ListNode pre = ret;
                ListNode cur = ret.next;
                ListNode end = newend;
                changed = false;
                while (cur.next != end)
                {
                    ListNode next = cur.next;
                    if (next.val < cur.val)
                    {
                        pre.next = next;
                        cur.next = next.next;
                        next.next = cur;

                        pre = next;
                        newend = next;
                        changed = true;
                    }
                    else
                    {
                        pre = cur;
                        cur = cur.next;
                    }
                }
            } while (changed);

            return ret.next;
        }

        // buble up
        public ListNode SortList4(ListNode head)
        {
            if (head == null)
            {
                return null;
            }

            ListNode ret = new ListNode(0)
            {
                next = head
            };

            ListNode p = ret;
            while (p.next != null)
            {
                ListNode premin = p;
                ListNode min = p.next;
                ListNode p2 = p.next;
                while (p2.next != null)
                {
                    if (p2.next.val < min.val)
                    {
                        premin = p2;
                        min = p2.next;
                    }

                    p2 = p2.next;
                }

                premin.next = min.next;
                min.next = p.next;
                p.next = min;
                p = p.next;
            }

            return ret.next;
        }

        public ListNode SortList5(ListNode head)
        {
            if (head == null)
            {
                return null;
            }

            ListNode ret = new ListNode(0);
            ListNode p = head;
            while (p != null)
            {
                ListNode pre = ret;
                ListNode cur = pre.next;
                while (cur != null && cur.val < p.val)
                {
                    pre = cur;
                    cur = cur.next;
                }

                ListNode next = p.next;
                pre.next = p;
                p.next = cur;
                p = next;
            }
            return ret.next;
        }
    }
}
