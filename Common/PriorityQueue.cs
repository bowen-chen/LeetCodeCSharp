using System;
using System.Collections.Generic;

namespace Demo.Common
{
    // big heap
    public class PriorityQueue<T>
    {
        IComparer<T> comparer;
        T[] heap;

        public int Count { get; private set; }
        
        public PriorityQueue(int capacity = 16, IComparer<T> comparer = null)
        {
            this.comparer = comparer ?? Comparer<T>.Default;
            this.heap = new T[capacity];
        }

        public void Push(T v)
        {
            if (Count >= heap.Length)
            {
                Array.Resize(ref heap, Count*2);
            }

            heap[Count] = v;
            SiftUp(Count++);
        }

        public T Pop()
        {
            var v = Top();
            heap[0] = heap[--Count];
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
                return heap[0];
            }

            throw new InvalidOperationException("");
        }

        void SiftUp(int n)
        {
            var v = heap[n];
            for (var n2 = n/2; n > 0; n = n2, n2 /= 2)
            {
                if (comparer.Compare(v, heap[n2]) > 0)
                {
                    heap[n] = heap[n2];
                }
                else
                {
                    break;
                }
            }
            heap[n] = v;
        }

        void SiftDown(int n)
        {
            var v = heap[n];
            for (var n2 = n * 2; n2 < Count; n = n2, n2 *= 2)
            {
                if (n2 + 1 < Count && comparer.Compare(heap[n2 + 1], heap[n2]) > 0)
                {
                    n2++;
                }
                if (comparer.Compare(v, heap[n2]) >= 0)
                {
                    break;
                }
                heap[n] = heap[n2];
            }
            heap[n] = v;
        }
    }
}