/*
632. Smallest Range
You have k lists of sorted integers in ascending order. Find the smallest range that includes at least one number from each of the k lists.

We define the range [a,b] is smaller than range [c,d] if b-a < d-c or a < c if b-a == d-c.

Example 1:
Input:[[4,10,15,24,26], [0,9,12,20], [5,18,22,30]]
Output: [20,24]
Explanation: 
List 1: [4, 10, 15, 24,26], 24 is in range [20,24].
List 2: [0, 9, 12, 20], 20 is in range [20,24].
List 3: [5, 18, 22, 30], 22 is in range [20,24].
Note:
The given list may contain duplicates, so ascending order means >= here.
1 <= k <= 3500
-105 <= value of elements <= 105.
For Java users, please note that the input type has been changed to List<List<Integer>>. And after you reset the code template, you'll see this point.
*/

using System;
using System.Collections.Generic;
using Demo.Common;

namespace Demo
{
    public partial class Solution
    {
        public int[] SmallestRange2(IList<IList<int>> nums)
        {
            int x = 0;
            int y = int.MaxValue;

            // cx, cy is the current low, high boundary in the heap
            int cx = 0;
            int cy = int.MinValue;
            var pq = new PriorityQueue<int[]>(nums.Count,
                Comparer<int[]>.Create((a, b) => nums[b[0]][b[1]] - nums[a[0]][a[1]]));
            for (int i = 0; i < nums.Count; i++)
            {
                pq.Push(new[] { i, 0 });
                cy = Math.Max(cy, nums[i][0]);
            }

            while (pq.Count != 0)
            {
                var c = pq.Pop();
                cx = nums[c[0]][c[1]];
                if (y - x > cy - cx)
                {
                    y = cy;
                    x = cx;
                }

                if (c[1] + 1 < nums[c[0]].Count)
                {
                    cy = Math.Max(cy, nums[c[0]][c[1] + 1]);
                    pq.Push(new[] { c[0], c[1] + 1 });

                }
                else
                {
                    break;
                }
            }

            return new[] {x, y};
        }

        public int[] SmallestRange(IList<IList<int>> nums)
        {
            int count = 0;
            int min = int.MaxValue;
            int[] ret = null;
            var m = new int[nums.Count];
            var q = new Queue<int[]>();
            var pq = new PriorityQueue<int[]>(nums.Count,
                Comparer<int[]>.Create((a, b) => nums[b[0]][b[1]] - nums[a[0]][a[1]]));

            for (int i = 0; i < nums.Count; i++)
            {
                pq.Push(new[] {i, 0});
            }

            while (pq.Count != 0)
            {
                var c = pq.Pop();
                q.Enqueue(c);

                if (m[c[0]]++ == 0)
                {
                    count++;
                }

                while (count == nums.Count)
                {
                    var temp = q.ToArray();
                    int a = nums[temp[0][0]][temp[0][1]];
                    int b = nums[temp[temp.Length - 1][0]][temp[temp.Length - 1][1]];
                    if (b - a < min)
                    {
                        min = b - a;
                        ret = new[] {a, b};
                    }

                    var cc = q.Dequeue();
                    if (--m[cc[0]] == 0)
                    {
                        count--;
                    }
                }

                if (c[1] + 1 < nums[c[0]].Count)
                {
                    pq.Push(new[] { c[0], c[1] + 1 });
                }
            }

            return ret;
        }
    }
}
