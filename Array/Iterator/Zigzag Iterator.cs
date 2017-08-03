/*
281	Zigzag Iterator $
Problem Description:

Given two 1d vectors, implement an iterator to return their elements alternately.

For example, given two 1d vectors:

v1 = [1, 2]
v2 = [3, 4, 5, 6] 
By calling next repeatedly until hasNext returns false, the order of elements returned by next should be: [1, 3, 2, 4, 5, 6].

Follow up: What if you are given k 1d vectors? How well can your code be extended to such cases?
*/

using System.Collections.Generic;

namespace Demo
{
    public class ZigzagIterator
    {
        readonly int[] indexes;
        readonly int[][] vs;
        int cur;

        public ZigzagIterator(int[][] vs)
        {
            indexes = new int[vs.Length];
            this.vs = vs;
            cur = -1;
        }

        public int Next()
        {
            return vs[cur][indexes[cur++]++];
        }

        public bool HasNext()
        {
            for (int i = 0; i < indexes.Length; i++)
            {
                cur = cur%indexes.Length;
                if (indexes[cur] < vs[cur].Length)
                {
                    return true;
                }

                cur++;
            }

            return false;
        }
    }

    public class ZigzagIterator2
    {
        private readonly int[][] vs;
        private readonly Queue<int[]> q = new Queue<int[]>();

        public ZigzagIterator2(int[][] vs)
        {
            for(int i =0;i<vs.Length;i++)
            {
                if (vs[i].Length > i)
                {
                    q.Enqueue(new[] {i, 0});
                }
            }

            this.vs = vs;
        }

        public int next()
        {
            var it = q.Dequeue();
            if (it[1] + 1 < vs[it[0]].Length)
            {
                q.Enqueue(new [] { it[0], it[1]+1});
            }

            return vs[it[0]][it[1]];
        }

        public bool hasNext()
        {
            return q.Count != 0;
        }
    };
}
