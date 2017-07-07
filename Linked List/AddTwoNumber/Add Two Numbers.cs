/*
2	Add Two Numbers
Easy, link
You are given two linked lists representing two non-negative numbers.
The digits are stored in reverse order and each of their nodes contain a single digit.
Add the two numbers and return it as a linked list.

Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
Output: 7 -> 0 -> 8
*/

namespace Demo
{
    public partial class Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode ret = new ListNode(0);
            ListNode head = ret;
            int c = 0; //carrier
            while (l1 != null || l2 != null || c != 0)
            {
                int sum = c;

                if (l1 != null)
                {
                    sum += l1.val;
                    l1 = l1.next;
                }

                if (l2 != null)
                {
                    sum += l2.val;
                    l2 = l2.next;
                }

                head.next = new ListNode(sum % 10);
                head = head.next;
                c = sum / 10;
            }
            return ret.next;
        }
    }
}
