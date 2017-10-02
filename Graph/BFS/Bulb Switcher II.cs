/*
672. Bulb Switcher II
There is a room with n lights which are turned on initially and 4 buttons on the wall. After performing exactly m unknown operations towards buttons, you need to return how many different kinds of status of the n lights could be.

Suppose n lights are labeled as number [1, 2, 3 ..., n], function of these 4 buttons are given below:

Flip all the lights.
Flip lights with even numbers.
Flip lights with odd numbers.
Flip lights with (3k + 1) numbers, k = 0, 1, 2, ...
Example 1:
Input: n = 1, m = 1.
Output: 2
Explanation: Status can be: [on], [off]
Example 2:
Input: n = 2, m = 1.
Output: 3
Explanation: Status can be: [on, off], [off, on], [off, off]
Example 3:
Input: n = 3, m = 1.
Output: 4
Explanation: Status can be: [off, on, off], [on, off, on], [off, off, off], [off, on, on].
*/

using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public int FlipLights(int n, int m)
        {
            n = n <= 6 ? n : 6;
            int start = (1 << n) - 1;
            var q = new Queue<int>();
            q.Enqueue(start);
            for (int i = 0; i < m; ++i)
            {
                int len = q.Count;
                var s = new HashSet<int>();
                for (int k = 0; k < len; ++k)
                {
                    int t = q.Dequeue();
                    foreach (int num in new [] { flipAll(t, n), flipEven(t, n), flipOdd(t, n), flip3k1(t, n) } )
                    {
                        if (s.Contains(num))
                        {
                            continue;
                        }

                        q.Enqueue(num);
                        s.Add(num);
                    }
                }
            }
            return q.Count;
        }

        int flipAll(int t, int n)
        {
            int x = (1 << n) - 1;
            return t ^ x;
        }

        int flipEven(int t, int n)
        {
            for (int i = 0; i < n; i += 2)
            {
                t ^= 1 << i;
            }

            return t;
        }

        int flipOdd(int t, int n)
        {
            for (int i = 1; i < n; i += 2)
            {
                t ^= 1 << i;
            }
            return t;
        }

        int flip3k1(int t, int n)
        {
            for (int i = 0; i < n; i += 3)
            {
                t ^= 1 << i;
            }
            return t;
        }
    }
}
