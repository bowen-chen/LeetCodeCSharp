/*
445. Add Two Numbers II
You are given two non-empty linked lists representing two non-negative integers. The most significant digit comes first and each of their nodes contain a single digit. Add the two numbers and return it as a linked list.

You may assume the two numbers do not contain any leading zero, except the number 0 itself.

Follow up:
What if you cannot modify the input lists? In other words, reversing the lists is not allowed.

Example:

Input: (7 -> 2 -> 4 -> 3) + (5 -> 6 -> 4)
Output: 7 -> 8 -> 0 -> 7
*/

using System.Collections.Generic;

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
        public ListNode AddTwoNumbers2(ListNode l1, ListNode l2)
        {
            var s1 = new Stack<int>();
            var s2 = new Stack<int>();
            while (l1 != null)
            {
                s1.Push(l1.val);
                l1 = l1.next;
            }
            while (l2 != null)
            {
                s2.Push(l2.val);
                l2 = l2.next;
            }

            int sum = 0;
            ListNode head = null;
            while (s1.Count !=0 || s2.Count != 0 || sum !=0)
            {
                if (s1.Count != 0) { sum += s1.Pop();  }
                if (s2.Count != 0) { sum += s2.Pop(); }
                var temp = new ListNode(sum%10);
                temp.next = head;
                head = temp;
                sum /= 10;
            }
            return head;
        }
    }
}
