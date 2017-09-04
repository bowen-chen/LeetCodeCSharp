/*
284. Peeking Iterator
Given an Iterator class interface with methods: next() and hasNext(), design and implement a PeekingIterator that support the peek() operation -- it essentially peek() at the element that will be returned by the next call to next().

Here is an example. Assume that the iterator is initialized to the beginning of the list: [1, 2, 3].

Call next() gets you 1, the first element in the list.

Now you call peek() and it returns 2, the next element. Calling next() after that still return 2.

You call next() the final time and it returns 3, the last element. Calling hasNext() after that should return false.

Follow up: How would you extend your design to be generic and work with all types, not just integer?
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public interface Iterator<T>
    {
        T next();
        bool hasNext();
    }

    // Java Iterator interface reference:
    // https://docs.oracle.com/javase/8/docs/api/java/util/Iterator.html
    public class PeekingIterator: Iterator<int>
    {
        private int? theNext = null;
        private Iterator<int> iter;

        public PeekingIterator(Iterator<int> iterator) {
            // initialize any member here.
            iter = iterator;
            if (iter.hasNext())
            {
                theNext = iter.next();
            }
        }

        // Returns the next element in the iteration without advancing the iterator.
        public int peek() {
            return theNext.Value;
        }

        // hasNext() and next() should behave the same as in the Iterator interface.
        // Override them if needed.
        public int next() {
            int? res = theNext;
            theNext = iter.hasNext() ? (int?)iter.next() : null;
            return res.Value;
        }
        
        public bool hasNext() {
            return theNext != null;
        }
    }
}
