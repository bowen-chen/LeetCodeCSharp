/*
315. Count of Smaller Numbers After Self
hard
You are given an integer array nums and you have to return a new counts array. The counts array has the property where counts[i] is the number of smaller elements to the right of nums[i].

Example:

Given nums = [5, 2, 6, 1]

To the right of 5 there are 2 smaller elements (2 and 1).
To the right of 2 there is only 1 smaller element (1).
To the right of 6 there is 1 smaller element (1).
To the right of 1 there is 0 smaller element.
Return the array [2, 1, 1, 0].
*/

using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    public partial class Solution
    {
        public void Test_CountSmaller()
        {
            CountSmaller(new [] {5, 2, 6, 1}).Print();
        }

        public IList<int> CountSmaller(int[] nums)
        {
            int[] ret = new int[nums.Length];
            IList<int> sortedList = new List<int>();

            // insert sort
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                int count;
                if (sortedList.Count == 0)
                {
                    count = 0;
                }
                else
                {
                    // find the first sortedlist[low] does not meet sortedList[low] < nums[i]
                    int low = 0;
                    int high = sortedList.Count - 1;
                    while (low <= high)
                    {
                        int mid = low + (high - low)/2;
                        if (sortedList[mid] < nums[i])
                        {
                            low = mid + 1;
                        }
                        else
                        {
                            high = mid - 1;
                        }
                    }

                    count = low;
                }

                ret[i] = count;
                sortedList.Insert(count, nums[i]);
            }

            return ret;
        }

        class Node
        {
            public Node left;
            public Node right;
            public readonly int val;
            public int sum; /*sum of left sub tree*/
            public int count;
            public Node(int v)
            {
                val = v;
            }
        }
        public List<int> CountSmaller2(int[] nums)
        {
            var ret = new List<int>();
            Node root = new Node(0);
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                ret.Add(Insert(nums[i], root));
            }

            return ret;
        }

        private int Insert(int num, Node node)
        {
            int ret = 0;
            while (node.val != num)
            {
                if (node.val > num)
                {
                    node.sum++;
                    node.left = node.left ?? new Node(num);
                    node = node.left;
                }
                else
                {
                    ret += node.count;
                    ret += node.sum;
                    node.right = node.right ?? new Node(num);
                    node = node.right;
                }
            }

            node.count++;
            return ret + node.sum;
        }
    }
}
