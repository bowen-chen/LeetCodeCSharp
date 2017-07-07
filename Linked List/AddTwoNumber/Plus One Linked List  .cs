/*
369 Plus One Linked List
Given a non-negative number represented as a singly linked list of digits, plus one to the number.

The digits are stored such that the most significant digit is at the head of the list.

Example:
Input:
1->2->3

Output:
1->2->4
*/
namespace Demo
{
    public partial class Solution
    {
        public ListNode PlusOne(ListNode head)
        {
            if (head == null)
            {
                return null;
            }

            int carry = PlusOneReturnCarry(head);
            if (carry == 1)
            {
                ListNode res = new ListNode(1) {next = head};
                return res;
            }

            return head;
        }

        private int PlusOneReturnCarry(ListNode node)
        {
            int add = node.next == null ? 1 : PlusOneReturnCarry(node.next);

            // fast route
            if (add == 0)
            {
                return 0;
            }

            int sum = node.val + add;
            node.val = sum%10;
            return sum/10;
        }

        public ListNode PlusOne2(ListNode head)
        {
            ListNode cur = head;
            ListNode right = null;

            // from left, right is the last node is not 9
            // xxxxxxxxx899
            while (cur!=null)
            {
                if (cur.val != 9)
                {
                    right = cur;
                }

                cur = cur.next;
            }

            // all 9
            if (right == null)
            {
                right = new ListNode(0)
                {
                    next = head
                };

                head = right;
            }

            right.val ++;
            cur = right.next;
            while (cur != null)
            {
                cur.val = 0;
                cur = cur.next;
            }

            return head;
        }
    }
}
