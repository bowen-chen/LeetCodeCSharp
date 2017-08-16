using System;
using System.Collections.Generic;

namespace Demo.Common
{
    // big heap
    public class PriorityQueue<T>
    {
        readonly IComparer<T> comparer;
        T[] heap;

        public int Count { get; private set; }

        public PriorityQueue(int capacity = 16, IComparer<T> comparer = null)
        {
            this.comparer = comparer ?? Comparer<T>.Default;
            this.heap = new T[capacity + 1];
        }

        public void Push(T v)
        {
            if (Count >= heap.Length - 1)
            {
                Array.Resize(ref heap, Count*2 + 1);
            }

            heap[++Count] = v;
            SiftUp(Count);
        }

        public T Pop()
        {
            var v = Top();
            heap[1] = heap[Count--];
            if (Count > 1)
            {
                SiftDown(0);
            }

            return v;
        }

        public T Top()
        {
            if (Count > 0)
            {
                return heap[1];
            }

            throw new InvalidOperationException("");
        }

        void SiftUp(int n)
        {
            var v = heap[n];
            for (var parent = n/2; n >=1; n = parent, parent /= 2)
            {
                if (comparer.Compare(v, heap[parent]) > 0)
                {
                    heap[n] = heap[parent];
                }
                else
                {
                    break;
                }
            }

            heap[n] = v;
        }

        private void SiftDown(int n)
        {
            var v = heap[n];
            for (var child = n*2; child <= Count; n = child, child *= 2)
            {
                if (child + 1 <= Count && comparer.Compare(heap[child + 1], heap[child]) > 0)
                {
                    child++;
                }

                if (comparer.Compare(v, heap[child]) >= 0)
                {
                    break;
                }

                heap[n] = heap[child];
            }

            heap[n] = v;
        }
    }
}