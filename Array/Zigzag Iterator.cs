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

namespace Demo
{
    public class ZigzagIterator
    {
        int[] indexes;
        int[][] vs;
        int cur;

        public ZigzagIterator(int[][] vs)
        {
            indexes = new int[vs.Length];
            this.vs = vs;
            cur = -1;
        }

        public int Next()
        {
            do
            {
                cur = (cur + 1)%indexes.Length;
            } while (indexes[cur] >= vs[cur].Length);

            return vs[cur][indexes[cur]++];
        }

        public bool HasNext()
        {
            for (int i = 0; i < indexes.Length; i++)
            {
                if (indexes[i] < vs[cur].Length)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
