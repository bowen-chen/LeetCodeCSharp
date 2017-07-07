using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Common
{
    public class PriorityQueue2<T>
    {
        private readonly SortedList<T, T> sortedList;
        
        public PriorityQueue2(int capacity = 16, IComparer<T> comparer = null)
        {
            this.sortedList = new SortedList<T, T>(capacity, comparer);
        }

        public void Push(T v)
        {
            sortedList.Add(v,v);
        }

        public T Pop()
        {
            var v = Top();
            return v;
        }

        public T Top()
        {
            if (Count > 0)
            {
                return sortedList.Values[0];
            }

            throw new InvalidOperationException("");
        }

        public int Count {
            get { return sortedList.Count; }
        }
    }
}